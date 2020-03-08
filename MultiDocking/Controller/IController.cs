using System;

namespace MultiDocking.Controller
{
    public abstract class AController
    {
        private int _processedItems = 0;
        private int _remainingItems = 0;
        private DateTime _startEta;
        private Action<int, string> _onRefresh;
        protected void StartEta(int numberOfItems, Action<int, string> onRefreshAction)
        {
            _startEta = DateTime.Now;
            _remainingItems = numberOfItems;
            _onRefresh = onRefreshAction;
        }

        protected void AddOneProcessedItemAndRefreshEta()
        {
            _processedItems++;
            _remainingItems--;
            var now = DateTime.Now;
            var totalTime = (now - _startEta).TotalSeconds;
            var timePerItem = totalTime / _processedItems;
            var eta = _remainingItems * timePerItem;
            var percent = (double)_processedItems / (_processedItems + _remainingItems) * 100;
            _onRefresh?.Invoke((int)percent, "" + eta);
        }
    }
}
