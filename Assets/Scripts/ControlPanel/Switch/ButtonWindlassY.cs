using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ButtonWindlassY : Switch, ISwitch
{
    [Inject]
    private ControlPanelController _controlPanelControllers;

    public override void OnActive()
    {
        active = true;
        _controlPanelControllers.MoveWindlass(active, type);
    }

    public override void OnDeactive()
    {
        active = false;
        _controlPanelControllers.MoveWindlass(active, type);
    }

    public class ButtonForWindlassFabrik : Factory<ControlPanelController, ButtonWindlassY>
    {

    }
}
