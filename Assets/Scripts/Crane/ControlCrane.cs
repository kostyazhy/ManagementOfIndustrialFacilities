using UnityEngine;
using Zenject;

public class ControlCrane : MonoBehaviour
{
    [Inject]
    private GameConfig _config;
    [Inject]
    private IMobileUnit _tower;
    [Inject]
    private IWindlass _windlass;
    [Inject]
    private Magnet _magnet;

    private void OnEnable()
    {
        ControlPanelController.OnMoveForwardTower += MoveForwardTower;
        ControlPanelController.OnMoveBackTower += MoveBackTower;
        ControlPanelController.OnMoveLeftWindlass += MoveLeftWindlass;
        ControlPanelController.OnMoveRightWindlass += MoveRightWindlass;
        ControlPanelController.OnMoveUpWindlass += MoveUpWindlass;
        ControlPanelController.OnMoveDownWindlass += MoveDownWindlass;
        ControlPanelController.OnActiveMagnet += OnActiveMagnet;
    }

    private void OnDisable()
    {
        ControlPanelController.OnMoveForwardTower -= MoveForwardTower;
        ControlPanelController.OnMoveBackTower -= MoveBackTower;
        ControlPanelController.OnMoveLeftWindlass -= MoveLeftWindlass;
        ControlPanelController.OnMoveRightWindlass -= MoveRightWindlass;
        ControlPanelController.OnMoveUpWindlass -= MoveUpWindlass;
        ControlPanelController.OnMoveDownWindlass -= OnActiveMagnet;
    }

    private void MoveForwardTower(bool active)
    {
        _tower.MoveForwardFlag = active;
    }

    private void MoveBackTower(bool active)
    {
        _tower.MoveBackFlag = active;
    }

    private void MoveLeftWindlass(bool active)
    {
        _windlass.MoveBackFlag = active;
    }

    private void MoveRightWindlass(bool active)
    {
        _windlass.MoveForwardFlag = active;
    }

    private void MoveUpWindlass(bool active)
    {
        _windlass.MoveUpFlag = active;
    }

    private void MoveDownWindlass(bool active)
    {
        _windlass.MoveDownFlag = active;
    }

    private void OnActiveMagnet(bool active)
    {
        _magnet.ActiveMagnetFlag = active;
    }

    public class CraneFabrik : Factory<IMobileUnit, IWindlass, Magnet, ControlCrane>
    {

    }
}
