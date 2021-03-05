using UnityEngine;
using Zenject;

/// <summary>
/// Задет поведение переключателя для башни
/// </summary>
public class SwitchTower : Switch, ISwitch
{
    [Inject]
    private ControlPanel _controlPanel;

    /// <summary>
    /// Активирует движение башни
    /// </summary>
    public override void OnActive()
    {
        active = true;
        _controlPanel.MoveTower(active, type);
    }

    /// <summary>
    /// Деактивирует движение башни
    /// </summary>
    public override void OnDeactive()
    {
        active = false;
        _controlPanel.MoveTower(active, type);
    }

    /// <summary>
    /// Создает кнопку
    /// <params> ControlPanelController - _controlPanelControllers </params>
    /// </summary>
    public class SwitchForwardFabrik : PlaceholderFactory<IControlPanel, SwitchTower>
    {

    }
}
