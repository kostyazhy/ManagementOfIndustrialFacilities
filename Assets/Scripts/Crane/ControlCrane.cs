using UnityEngine;
using Zenject;


/// <summary>
/// Управляет поведением составляющих крана через события
/// </summary>
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

    /// <summary>
    /// Подписываемся на события
    /// </summary>
    private void OnEnable()
    {
        ControlPanel.OnMoveForwardTower += MoveForwardTower;
        ControlPanel.OnMoveBackTower += MoveBackTower;
        ControlPanel.OnMoveLeftWindlass += MoveLeftWindlass;
        ControlPanel.OnMoveRightWindlass += MoveRightWindlass;
        ControlPanel.OnMoveUpWindlass += MoveUpWindlass;
        ControlPanel.OnMoveDownWindlass += MoveDownWindlass;
        ControlPanel.OnActiveMagnet += OnActiveMagnet;
    }

    /// <summary>
    /// Отписываемся от событий
    /// </summary>
    private void OnDisable()
    {
        ControlPanel.OnMoveForwardTower -= MoveForwardTower;
        ControlPanel.OnMoveBackTower -= MoveBackTower;
        ControlPanel.OnMoveLeftWindlass -= MoveLeftWindlass;
        ControlPanel.OnMoveRightWindlass -= MoveRightWindlass;
        ControlPanel.OnMoveUpWindlass -= MoveUpWindlass;
        ControlPanel.OnMoveDownWindlass -= OnActiveMagnet;
    }

    /// <summary>
    /// Сообщаем башне, что переключатель "Вперед" поменял состояние
    /// </summary>
    /// <param name="active"> Состояние переключателя </param>
    private void MoveForwardTower(bool active)
    {
        _tower.MoveForwardFlag = active;
    }

    /// <summary>
    /// Сообщаем башне, что переключатель "Назад" поменял состояние
    /// </summary>
    /// <param name="active"> Состояние переключателя </param>
    private void MoveBackTower(bool active)
    {
        _tower.MoveBackFlag = active;
    }

    /// <summary>
    /// Сообщаем лебедке, что переключатель "Влево" поменял состояние
    /// </summary>
    /// <param name="active"> Состояние переключателя </param>
    private void MoveLeftWindlass(bool active)
    {
        _windlass.MoveBackFlag = active;
    }

    /// <summary>
    /// Сообщаем лебедке, что переключатель "Вправо" поменял состояние
    /// </summary>
    /// <param name="active"> Состояние переключателя </param>
    private void MoveRightWindlass(bool active)
    {
        _windlass.MoveForwardFlag = active;
    }

    /// <summary>
    /// Сообщаем лебедке, что переключатель "Вверх" поменял состояние
    /// </summary>
    /// <param name="active"> Состояние переключателя </param>
    private void MoveUpWindlass(bool active)
    {
        _windlass.MoveUpFlag = active;
    }

    /// <summary>
    /// Сообщаем лебедке, что переключатель "Вниз" поменял состояние
    /// </summary>
    /// <param name="active"> Состояние переключателя </param>
    private void MoveDownWindlass(bool active)
    {
        _windlass.MoveDownFlag = active;
    }

    /// <summary>
    /// Сообщаем магниту его состояние
    /// </summary>
    /// <param name="active"> Состояние переключателя </param>
    private void OnActiveMagnet(bool active)
    {
        _magnet.ActiveMagnetFlag = active;
    }

    /// <summary>
    /// Создаем объект - управление краном
    /// </summary>
    /// <params>
    /// IMobileUnit - _tower
    /// IWindlass - _windlass
    /// </params>
    public class CraneFabrik : PlaceholderFactory<IMobileUnit, IWindlass, Magnet, ControlCrane>
    {

    }
}
