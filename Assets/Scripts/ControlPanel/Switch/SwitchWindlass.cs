using UnityEngine;
using Zenject;

public class SwitchWindlass : Switch, ISwitch
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

    public class SwitchBackFabrik : Factory<ControlPanelController, SwitchWindlass>
    {

    }
}
