using System;
using UnityEngine;
using Zenject;

public abstract class Switch: MonoBehaviour
{
    protected bool active = false;

    public TypeSwitch.Type type;

    public virtual void OnActive()
    {
        active = true; 
    }

    public virtual void OnDeactive()
    {
        active = false;
    }
}
