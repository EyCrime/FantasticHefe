using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SignalObject : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>();

    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);
    }
    
    public void DeRegisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
    
    public void Raise()
    {
        for (var i = listeners.Count-1; i >= 0 ; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }
}