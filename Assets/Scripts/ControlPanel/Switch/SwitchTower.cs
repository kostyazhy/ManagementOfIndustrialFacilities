using UnityEngine;
using Zenject;

public class SwitchTower : Switch, ISwitch
{
    [Inject]
    private ControlPanelController _controlPanelControllers;

    public override void OnActive()
    {
        active = true;
        _controlPanelControllers.MoveTower(active, type);
    }

    public override void OnDeactive()
    {
        active = false;
        _controlPanelControllers.MoveTower(active, type);
    }

    public class SwitchForwardFabrik : Factory<ControlPanelController, SwitchTower>
    {

    }
}
