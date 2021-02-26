using UnityEngine;
using Zenject;

public class Switch : MonoBehaviour, ISwitch
{
    [Inject]
    private ControlPanel _controlPanel;

    public void OnActive()
    {
        Debug.Log("On actived Switch");
    }
}
