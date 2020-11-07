using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace MultiDocking.Controller
{
    class RmsdController : AController
    {
        public class Atom
        {
            public int Id;
            public string Name;
            public double X;
            public double Y;
            public double Z;
        }

        public static double Distance(Atom atom1, Atom atom2)
        {
            return Math.Sqrt(
                (atom1.X - atom2.X) * (atom1.X - atom2.X) +
                (atom1.Y - atom2.Y) * (atom1.Y - atom2.Y) +
                (atom1.Z - atom2.Z) * (atom1.Z - atom2.Z));
        }

        public class Structures
        {
            public readonly Dictionary<string, Structure> DictStructures = new Dictionary<string, Structure>();

            public Structure GetOrCreateStructure(string ligandName)
            {
                if (!DictStructures.ContainsKey(ligandName))
                {
                    DictStructures[ligandName] = new Structure();
                }

                return DictStructures[ligandName];
            }

            public Structures()
            {
            }

            public Structures(string file)
            {
                Read(file);
            }

            public void Read(string file)
            {
                var lines = File.ReadAllLines(file);

                var atomLines = new List<string>();
                foreach (var line in lines)
                {
                    if (line.StartsWith("HETATM"))
                    {
                        atomLines.Add(line);
                    }
                }

                var id = 0;
                var digits = new[] { ' ', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                foreach (var atomLine in atomLines)
                {
                    if(atomLine.Contains("HOH"))
                        continue;
                    
                    var xString = atomLine.Substring(30, 8);
                    var yString = atomLine.Substring(38, 8);
                    var zString = atomLine.Substring(46, 8);

                    var atomName = atomLine.Substring(13, 2);
                    atomName = atomName.TrimEnd(digits);
                    if(atomName=="H")
                        continue;
                    double x = Convert.ToDouble(xString);
                    double y = Convert.ToDouble(yString);
                    double z = Convert.ToDouble(zString);

                    var ligandName = atomLine.Substring(21, 5);

                    GetOrCreateStructure(ligandName).Atoms.Add(new Atom()
                    {
                        Id = id++,
                        Name = atomName,
                        X = x,
                        Y = y,
                        Z = z
                    });
                }
            }
        }

        public class Structure
        {
            public Structure()
            {

            }

            public Structure(string file)
            {
                Read(file);
            }

            public List<Atom> Atoms = new List<Atom>();

            public void Read(string file)
            {
                var lines = File.ReadAllLines(file);

                var atomLines = new List<string>();
                foreach (var line in lines)
                {
                    if (line.StartsWith("ATOM")|| line.StartsWith("HETATM"))
                    {
                        atomLines.Add(line);
                    }

                    if (line.StartsWith("ENDMDL"))
                    {
                        break;
                    }
                }

                var id = 0;
                var digits = new[] { ' ', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                foreach (var atomLine in atomLines)
                {
                    var xString = atomLine.Substring(30, 8);
                    var yString = atomLine.Substring(38, 8);
                    var zString = atomLine.Substring(46, 8);

                    var atomName = atomLine.Substring(13, 2);
                    atomName = atomName.TrimEnd(digits);
                    if (atomName == "H")
                        continue;
                    double x = Convert.ToDouble(xString);
                    double y = Convert.ToDouble(yString);
                    double z = Convert.ToDouble(zString);

                    Atoms.Add(new Atom()
                    {
                        Id = id++,
                        Name = atomName,
                        X = x,
                        Y = y,
                        Z = z
                    });

                }
            }

            public Atom CalculateCenterOfMass()
            {
                return new Atom()
                {
                    X = Atoms.Select(a => a.X).Sum() / Atoms.Count,
                    Y = Atoms.Select(a => a.Y).Sum() / Atoms.Count,
                    Z = Atoms.Select(a => a.Z).Sum() / Atoms.Count
                };
            }

            public Structure AlignedStructure(Structure str)
            {
                var atomNames = Atoms.Select(a=>a.Name).Distinct().ToList();
                HashSet<int> prosesedIds1 = new HashSet<int>();
                HashSet<int> prosesedIds2 = new HashSet<int>();
                Dictionary<int,int> match = new Dictionary<int, int>();
                foreach (var atomName in atomNames)
                {
                    var atoms1WithName = Atoms.Where(a => a.Name == atomName).ToList();
                    var atoms2WithName = str.Atoms.Where(a => a.Name == atomName).ToList();
                    
                    foreach (var myAtom in atoms1WithName)
                    {
                        var bestDistance = double.MaxValue;
                        var id1 = myAtom.Id;
                        var id2 = -1;
                        foreach (var atom in atoms2WithName.Where(a => !prosesedIds2.Contains(a.Id)))
                        {
                            var distance = Distance(myAtom, atom);
                            if (distance < bestDistance)
                            {
                                id2 = atom.Id;
                                bestDistance = distance;
                            }
                        }

                        prosesedIds2.Add(id2);
                        match[id1] = id2;
                    }
                }

                var strResult = new Structure();

                for (int i = 0; i < str.Atoms.Count; i++)
                {
                    var id = match[i];

                    var atom = str.Atoms.First(a => a.Id == id);
                    strResult.Atoms.Add(new Atom()
                    {
                        Id = atom.Id,
                        Name = atom.Name,
                        X = atom.X,
                        Y = atom.Y,
                        Z = atom.Z
                    });
                }

                return strResult;
            }

        }

        public Dictionary<string, double> RunRmsds(List<FileInfo> resultList, string pdbProteinFolder, Action<int, string> onRefreshAction,
            Action onFinish, Func<bool> abortFunc)
        {
            var pdbFolder = pdbProteinFolder;
            var results = new Dictionary<string, double>();

            StartEta(resultList.Count, onRefreshAction);
            foreach (var fileInfo in resultList)
            {
                var fileName = fileInfo.Name;
                var pdb = fileName.Split('.')[0];

                var pdbName = pdb + ".pdb";
                var pdbFileName = Path.Combine(pdbFolder, pdbName);

                if (!File.Exists(pdbFileName))
                {
                    using (var client = new WebClient())
                    {
                        try
                        {
                            client.DownloadFile("http://files.rcsb.org/download/" + pdbName,
                                Path.Combine(pdbFolder, pdbName));
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                var rmsd = Controllers.RmsdController.CalculateRmsdPdbqtPdb(fileInfo.FullName, pdbFileName);
                results[pdb] = rmsd;

                if (abortFunc != null)
                {
                    if (abortFunc.Invoke())
                    {
                        goto Finish;
                    }
                }

                AddOneProcessedItemAndRefreshEta();
            }

            Finish:
            onFinish?.Invoke();
            return results;
        }

        public double CalculateRmsdPdbqtPdb(string pdbqtLigandResult, string pdbProtein)
        {
            double rmsd = double.PositiveInfinity;
            var structure1 = new Structure(pdbqtLigandResult);
            var structures2 = new Structures(pdbProtein);
            var validLigands = structures2.DictStructures.Values.Where(s => s.Atoms.Count >= 4).ToList();
            foreach (var str in validLigands)
            {
                double rmsdLocal = 0;
                try
                {
                    var str2 = structure1.AlignedStructure(str);

                    double sum = 0;
                    for (int i = 0; i < structure1.Atoms.Count; i++)
                    {
                        sum += (structure1.Atoms[i].X - str2.Atoms[i].X) * (structure1.Atoms[i].X - str2.Atoms[i].X) +
                               (structure1.Atoms[i].Y - str2.Atoms[i].Y) * (structure1.Atoms[i].Y - str2.Atoms[i].Y) +
                               (structure1.Atoms[i].Z - str2.Atoms[i].Z) * (structure1.Atoms[i].Z - str2.Atoms[i].Z);
                    }

                    sum = sum / structure1.Atoms.Count;

                    rmsdLocal = Math.Sqrt(sum);
                }
                catch (Exception e)
                {

                    var centerMass1 = structure1.CalculateCenterOfMass();
                    var centerMass2 = str.CalculateCenterOfMass();

                    rmsdLocal = Math.Sqrt(
                        (centerMass1.X - centerMass2.X) * (centerMass1.X - centerMass2.X) +
                        (centerMass1.Y - centerMass2.Y) * (centerMass1.Y - centerMass2.Y) +
                        (centerMass1.Z - centerMass2.Z) * (centerMass1.Z - centerMass2.Z));
                }

                if (rmsdLocal < rmsd)
                {
                    rmsd = rmsdLocal;
                }
            }
            
            return rmsd;
        }
    }
}
