using System;
using System.Collections.Generic;

namespace pattern_observer_netcore
{
    public class StockBar : IObserver<Stock>
    {
        private List<Stock> _stocks = new List<Stock>();
        private IDisposable _unsubscriber;
        public void AddStock(Stock stock)
        {
            if (_stocks.Contains(stock))
            {
                _stocks.Remove(stock);
            }
            _stocks.Add(stock);
        }

        public void OnCompleted()
        {
            Console.WriteLine("Done!");
        }

        public void OnError(Exception error)
        {
            // Do nothing
        }

        public void OnNext(Stock value)
        {
            AddStock(value);
            Show();
        }

        public void Show()
        {
            Console.WriteLine("===== STOCK LIST =========");
            foreach (var stock in _stocks)
            {
                Console.WriteLine("STOCK BAR:" + stock);
            }
            Console.WriteLine("==========================");
        }

        public void Subscribe(IObservable<Stock> provider)
        {
            _unsubscriber = provider.Subscribe(this);
        }

        public void Unsubscribe()
        {
            if (_unsubscriber != null)
            {
                _unsubscriber.Dispose();
            }
        }
    }
}