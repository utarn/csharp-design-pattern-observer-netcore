using System;
using System.Collections.Generic;

namespace pattern_observer_netcore
{
    public class StockProvider : IObservable<Stock>
    {
        private List<IObserver<Stock>> _observers;
        private List<Stock> _stocks;
        public StockProvider()
        {
            _observers = new List<IObserver<Stock>>();
            _stocks = new List<Stock>();
        }
        public IDisposable Subscribe(IObserver<Stock> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return new Unsubscriber(_observers, observer);
        }

        public void AddStock(Stock value)
        {
            if (_stocks.Contains(value))
            {
                _stocks.Remove(value);
            }
            _stocks.Add(value);
            NotifyObserver(value);
        }
        private void NotifyObserver(Stock value)
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(value);
            }
        }

        public void EndNotifyObserver()
        {
            foreach (var observer in _observers)
            {
                observer.OnCompleted();
            }
        }

    }
}