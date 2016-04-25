using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Titans
{
    public class Subjector : Subject
    {
        Location location;
        List<Observer> observers;

        public Subjector()
        { observers = new List<Observer>(); }

        public void registerObserver(Observer observer)
        { observers.Add(observer); }

        public void removeObserver(Observer observer)
        {
            if (observers.Contains(observer))
                observers.Remove(observer);
        }

        public void notifyObservers()
        {
            foreach (Observer observer in observers)
                observer.updateAndSwarm(this.location);
        }
    }
}
