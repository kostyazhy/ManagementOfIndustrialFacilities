using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "Create game event")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> _listeners =
        new List<GameEventListener>();
    public bool active;

    public void Raise(bool _active)
    {
        //Debug.Log("Game event " + _active);
        for (int i = _listeners.Count - 1; i >= 0; i--) {
            _listeners[i].OnEventRaised(_active);
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        _listeners.Remove(listener);
    }
}
