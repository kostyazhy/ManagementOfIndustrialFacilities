using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ControlPanel : MonoBehaviour, IControlPanel
{
    [Inject]
    private ControlPanelController _controlPanelControllers;

    [SerializeField]
    private List<ISwitch> _switches;

    public int Value { get; set; }

    public void MoveUnitForward()
    {
        //_unit.MoveThere();
    }

    public void MoveUnitBack()
    {
        //_unit.MoveBack();
    }

    void OnActive()
    {

    }

    public class ControlPanelFabrik : PlaceholderFactory<ControlPanelController, ControlPanel>
    {

    }
}
