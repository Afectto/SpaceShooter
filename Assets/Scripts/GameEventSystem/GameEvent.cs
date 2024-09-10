using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "SO/Create Game Event")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> _listeners = new List<GameEventListener>();

    public void AddListener(GameEventListener listener)
    {
        _listeners.Add(listener);
    }
    
    public void RemoveListener(GameEventListener listener)
    {
        _listeners.Remove(listener);
    }

    public void Init()
    {
        foreach (var listener in _listeners)
        {
            listener.EventRaised();
        }
    }
}
