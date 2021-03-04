using UnityEngine;
using Zenject;

public class SwitchBehaviour : Switch, ISwitch
{
    [Inject]
    private ControlPanelController _controlPanelControllers;

    /*public delegate void SwitchActive(bool active);
    public static event SwitchActive OnMoveTowerForward;*/

    private bool _active = false;

    public override void OnActive()
    {
        _active = !_active;

    }

    public class Factory : PlaceholderFactory<SwitchBehaviour>
    {
    }
}
