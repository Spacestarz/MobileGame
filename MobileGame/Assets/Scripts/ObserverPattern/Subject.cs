using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{

    //code from yt https://www.youtube.com/watch?v=NY_fzd8g5MU&t=588s

    //a collection of all the observer of this subject
    private List<IObserver> _observers = new List<IObserver>();
    
    //add the observer to the subjects collection
    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    //remove the observer from the subjects collection
    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    //notify each observer that an event has occured
    protected void NotifyObservers() 
    {
        _observers.ForEach(observer => observer.OnNotify());
    }
    
}
