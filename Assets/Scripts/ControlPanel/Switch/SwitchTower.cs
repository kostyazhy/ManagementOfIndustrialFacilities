using Zenject;

/// <summary>
/// Задет поведение переключателя для башни
/// </summary>
public class SwitchTower : Switch, ISwitch
{
    [Inject]
    private ControlPanelController _controlPanelControllers;

    /// <summary>
    /// Активирует движение башни
    /// </summary>
    public override void OnActive()
    {
        active = true;
        _controlPanelControllers.MoveTower(active, type);
    }

    /// <summary>
    /// Деактивирует движение башни
    /// </summary>
    public override void OnDeactive()
    {
        active = false;
        _controlPanelControllers.MoveTower(active, type);
    }

    /// <summary>
    /// Создает кнопку
    /// <params> ControlPanelController - _controlPanelControllers </params>
    /// </summary>
    public class SwitchForwardFabrik : PlaceholderFactory<ControlPanelController, SwitchTower>
    {

    }
}
