using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ControlPanel : MonoBehaviour, IControlPanel
{
    [Inject]
    private ControlPanelController _controlPanelControllers;

    //Events generated in the control panel 
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

    /// <summary>
    /// Генирирует событие для движения башни крана 
    /// </summary>
    /// <param name="active"> Нажат переключатель или нет</param>
    /// <param name="type"> Тип переключателя </param>
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

    /// <summary>
    /// Генирирует событие для движения лебедки 
    /// </summary>
    /// <param name="active"> Нажат переключатель или нет</param>
    /// <param name="type"> Тип переключателя </param>
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

    /// <summary>
    /// Генирирует событие для движения магнита
    /// </summary>
    /// <param name="active"> Нажат переключатель или нет</param>
    /// <param name="type"> Тип переключателя </param>
    public void ActiveMagnet(bool active, TypeSwitch.Type type)
    {
        switch (type) {
            case TypeSwitch.Type.Magnet:
                OnActiveMagnet?.Invoke(active);
                break;
        }
    }

    public class ControlPanelFabrik : PlaceholderFactory<ControlPanelController, ControlPanel>
    {

    }
}
