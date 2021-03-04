using UnityEngine;
using Zenject;

public class ControlPanelController
{
    [Inject]
    private GameConfig _config;

    [Inject]
    private ControlPanel.ControlPanelFabrik _controlPanelFabrik;
    [Inject]
    private SwitchTower.SwitchForwardFabrik _switchForwardFabrik;
    [Inject]
    private SwitchWindlass.SwitchBackFabrik _switchBackFabrik;
    [Inject]
    private ButtonWindlassY.ButtonForWindlassFabrik _buttonForWindlassFabrik;
    [Inject]
    private ButtonMagnet.ButtonMagnetFabrik _buttonForMagnetFabrik;

    public delegate void SwitchActiveForward(bool active);
    public static event SwitchActiveForward OnMoveForwardTower;

    public delegate void SwitchActiveBack(bool active);
    public static event SwitchActiveBack OnMoveBackTower;

    public delegate void SwitchActiveLeft(bool active);
    public static event SwitchActiveLeft OnMoveLeftWindlass;

    public delegate void SwitchActiveRight(bool active);
    public static event SwitchActiveRight OnMoveRightWindlass;

    public delegate void SwitchActiveUp(bool active);
    public static event SwitchActiveUp OnMoveUpWindlass;

    public delegate void SwitchActiveDown(bool active);
    public static event SwitchActiveDown OnMoveDownWindlass;

    public delegate void SwitchActiveMagnet(bool active);
    public static event SwitchActiveMagnet OnActiveMagnet;

    public void Init()
    {
        CreateControlPanel();
    }

    public ControlPanel CreateControlPanel()
    {
        var controlPanel = _controlPanelFabrik.Create(this);
        controlPanel.transform.position = _config.StartPositionControlPanel;

        var switchForward = _switchForwardFabrik.Create(this);
        var switchBack = _switchForwardFabrik.Create(this);
        var switchLest = _switchBackFabrik.Create(this);
        var switchRight = _switchBackFabrik.Create(this);
        var buttonWindlassDown = _buttonForWindlassFabrik.Create(this);
        var buttonWindlassUp = _buttonForWindlassFabrik.Create(this);
        var buttonMagnet = _buttonForMagnetFabrik.Create(this);

        // Setting switches
        // SwitchForward
        switchForward.transform.SetParent(controlPanel.transform);
        switchForward.type = TypeSwitch.Type.Forward;
        switchForward.transform.localPosition = _config.StartPositionSwitchForward;
        // SwitchBack
        switchBack.transform.SetParent(controlPanel.transform);
        switchBack.transform.localPosition = _config.StartPositionSwitchBack;
        switchBack.type = TypeSwitch.Type.Back;
        // SwitchLeft
        switchLest.transform.SetParent(controlPanel.transform);
        switchLest.transform.localPosition = _config.StartPositionWindlassLeft;
        switchLest.type = TypeSwitch.Type.Left;
        // SwitchRight
        switchRight.transform.SetParent(controlPanel.transform);
        switchRight.transform.localPosition = _config.StartPositionWindlassRight;
        switchRight.type = TypeSwitch.Type.Right;
        // SwitchDown
        buttonWindlassDown.transform.SetParent(controlPanel.transform);
        buttonWindlassDown.transform.localPosition = _config.StartPositionButtonDownForWindlass;
        buttonWindlassDown.type = TypeSwitch.Type.Down;
        // SwitchUp
        buttonWindlassUp.transform.SetParent(controlPanel.transform);
        buttonWindlassUp.transform.localPosition = _config.StartPositionButtonUpForWindlass;
        buttonWindlassUp.type = TypeSwitch.Type.Up;
        // Button magnet
        buttonMagnet.transform.SetParent(controlPanel.transform);
        buttonMagnet.transform.localPosition = _config.StartPositionButtonMagnet;
        buttonMagnet.type = TypeSwitch.Type.Magnet;

        return controlPanel;
    }

    public void MoveTower(bool active, TypeSwitch.Type type)
    {
        switch (type) {
            case TypeSwitch.Type.Forward:
                OnMoveForwardTower?.Invoke(active);
                break;
            case TypeSwitch.Type.Back:
                OnMoveBackTower?.Invoke(active);
                break;
        }
    }

    public void MoveWindlass(bool active, TypeSwitch.Type type)
    {
        switch (type) {
            case TypeSwitch.Type.Left:
                OnMoveLeftWindlass?.Invoke(active);
                break;
            case TypeSwitch.Type.Right:
                OnMoveRightWindlass?.Invoke(active);
                break;
            case TypeSwitch.Type.Up:
                OnMoveUpWindlass?.Invoke(active);
                break;
            case TypeSwitch.Type.Down:
                OnMoveDownWindlass?.Invoke(active);
                break;
        }
    }

    public void ActiveMagnet(bool active, TypeSwitch.Type type)
    {
        switch (type) {
            case TypeSwitch.Type.Magnet:
                OnActiveMagnet?.Invoke(active);
                break;
        }
    }
}
