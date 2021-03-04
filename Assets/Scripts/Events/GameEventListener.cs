using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;
    public EventSwitch Respone;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(bool active)
    {
        //Debug.Log("Respon " + active);
        Respone.active = active;
        Respone.Invoke(active);
    }
}

[System.Serializable]
public class EventSwitch : UnityEvent<bool>
{
    public bool active;
}
