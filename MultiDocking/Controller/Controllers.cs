namespace MultiDocking.Controller
{
    static class Controllers
    {
        public static string WorkSpacePath = "";
        public static readonly RcsbController RcsbController= new RcsbController();
        public static readonly RemoveLigandsController RemoveLigandsController = new RemoveLigandsController();
        public static readonly PrepareReceptorController PrepareReceptorController = new PrepareReceptorController();
        public static readonly DockingVinaController DockingVinaController = new DockingVinaController();
    }
}
