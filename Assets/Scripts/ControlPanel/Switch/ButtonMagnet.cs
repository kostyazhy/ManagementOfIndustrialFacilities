using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ButtonMagnet : Switch, ISwitch
{
    [Inject]
    private ControlPanelController _controlPanelControllers;

    public override void OnActive()
    {
        active = !active;
        _controlPanelControllers.ActiveMagnet(active, type);
    }

    public override void OnDeactive()
    {

    }

    public class ButtonMagnetFabrik : Factory<ControlPanelController, ButtonMagnet>
    {

    }
}
