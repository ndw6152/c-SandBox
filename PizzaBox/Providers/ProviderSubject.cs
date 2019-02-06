using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBox
{
    /// <summary>
    /// Following the Observer Design Pattern from 
    /// https://docs.microsoft.com/en-us/dotnet/standard/events/observer-design-pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ProviderSubject<T> : ISubject<T>
    {
        private List<IObserver<T>> _observers;

        public ProviderSubject()
        {
            _observers = new List<IObserver<T>>();
        }

        public void OnCompleted()
        {
            foreach (var obs in _observers)
            {
                obs.OnCompleted();
            }
        }

        public void OnError(Exception error)
        {
            foreach (var obs in _observers)
            {
                obs.OnError(error);
            }
        }

        public void OnNext(T value)
        {
            foreach(var obs in _observers)
            {
                obs.OnNext(value);
            } 
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (_observers.Contains(observer) == false)
                _observers.Add(observer);

            return new Unsubscriber<T>(_observers, observer);
        }

        public bool Unsubscribe(IObserver<T> observer)
        {
            if(_observers.Contains(observer))
            {
                _observers.Remove(observer);
                return true;
            }
            return false;
        }
    }

    internal class Unsubscriber<T> : IDisposable
    {
        private List<IObserver<T>> _observers;
        private IObserver<T> _observer;

        public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
