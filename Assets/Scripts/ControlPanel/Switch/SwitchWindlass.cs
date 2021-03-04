using Zenject;

/// <summary>
/// Задет поведение переключателя для лебедки
/// </summary>
public class SwitchWindlass : Switch, ISwitch
{
    [Inject]
    private ControlPanelController _controlPanelControllers;

    /// <summary>
    /// Активирует движение башни
    /// </summary>
    public override void OnActive()
    {
        active = true;
        _controlPanelControllers.MoveWindlass(active, type);
    }
    /// <summary>
    /// Деактивирует движение башни
    /// </summary>
    public override void OnDeactive()
    {
        active = false;
        _controlPanelControllers.MoveWindlass(active, type);
    }

    /// <summary>
    /// Создает кнопку
    /// <params> ControlPanelController - _controlPanelControllers </params>
    /// </summary>
    public class SwitchBackFabrik : PlaceholderFactory<ControlPanelController, SwitchWindlass>
    {

    }
}
