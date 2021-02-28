using UnityEngine;
using Zenject;

public class SwitchBack : MonoBehaviour, ISwitch
{
    [Inject]
    private ControlPanel _controlPanel;

    public void OnActive()
    {
        _controlPanel.MoveUnitBack();
        _controlPanel.Value = 2;
    }
}
