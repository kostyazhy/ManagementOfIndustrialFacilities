using UnityEngine;
using Zenject;

public class Switch : MonoBehaviour, ISwitch
{
    [Inject]
    private IControlPanel _controlPanel;

    [Inject]
    private ControlPanel _ControlPanel;

    public void OnActive()
    {
        Debug.Log("On actived Switch");
        _controlPanel.Value = 1;
    }
}
