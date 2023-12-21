using System.Collections.Generic;
//KOPIRANO SA VEZBI
namespace CLI.Observer
{
    public class ObserverSubject
    {
        private List<IObserver> _observers;

        public ObserverSubject()
        {
            _observers = new List<IObserver>();
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }

        }
    }
}
