using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Subject for observer pattern
/// </summary>
public class Subject
{
    private List<Observer> observers = new List<Observer>();

    /// <summary>
    /// Notifys observers
    /// </summary>
    public void Notify()
    {
            for (int i = 0; i < observers.Count; i++)
            {
                observers[i].OnNotify();
            }
    }
    
    /// <summary>
    /// Add Observer
    /// </summary>
    /// <param name="observer"></param>
    public void AddObserver(Observer observer){
        observers.Add(observer);
    }

    /// <summary>
    /// Remove Observer
    /// </summary>
    /// <param name="observer"></param>
    public void RemoveObserver(Observer observer){
        observers.Remove(observer);
    }
}
