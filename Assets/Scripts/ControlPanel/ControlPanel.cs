using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ControlPanel : MonoBehaviour
{
    [Inject]
    private GameControllers _gameControllers;

    [Inject]
    public ControlCrane _unit;

    [SerializeField]
    private List<ISwitch> _switches;

    public void MoveUnitForward()
    {
        _unit.MoveForward();
    }

    public void MoveUnitBack()
    {
        _unit.MoveBack();
    }
}
