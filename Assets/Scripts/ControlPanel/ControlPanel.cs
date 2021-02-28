using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ControlPanel : MonoBehaviour, IControlPanel
{
    [Inject]
    private GameControllers _gameControllers;

    /*[Inject]
    public ControlCrane _unit;*/

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
}
