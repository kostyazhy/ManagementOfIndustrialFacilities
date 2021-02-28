using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SwitchForward : MonoBehaviour, ISwitch
{
    [Inject]
    private ControlPanel _controlPanel;

    public void OnActive()
    {
        _controlPanel.MoveUnitForward();
        Debug.Log("On actived Switch");
    }

}
