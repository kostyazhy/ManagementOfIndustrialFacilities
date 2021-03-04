using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSwitch : ReactionSwitch
{
    private Transform _switch;
    private bool _active = false;

    private void Start()
    {
        _switch = transform;
    }

    public override void ActiveReaction()
    {
        _switch.transform.eulerAngles = new Vector3(-45, 0, 0);
    }

    public override void DeactiveReaction()
    {
        _switch.transform.eulerAngles = new Vector3(45, 0, 0);
    }
}
