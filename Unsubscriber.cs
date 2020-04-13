using System;
using System.Collections.Generic;

namespace pattern_observer_netcore
{
    public class Unsubscriber : IDisposable
    {
        private List<IObserver<Stock>> _observers;
        private IObserver<Stock> _observer;

        public Unsubscriber(List<IObserver<Stock>> observers, IObserver<Stock> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers != null)
            {
                _observers.Remove(_observer);
            }
        }
    }
}