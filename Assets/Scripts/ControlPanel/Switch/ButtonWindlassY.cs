using Zenject;

/// <summary>
/// Задет поведение переключателя для лебедки
/// </summary>
public class ButtonWindlassY : Switch, ISwitch
{
    [Inject]
    private ControlPanelController _controlPanelControllers;

    private TapButton _tap;

    private void Start()
    {
        _tap = GetComponent<TapButton>();
    }

    /// <summary>
    /// Активирует движение лебедки
    /// </summary>
    public override void OnActive()
    {
        active = true;
        _controlPanelControllers.MoveWindlass(active, type);
        _tap.Tap();
    }

    /// <summary>
    /// Деактивирует движение лебедки
    /// </summary>
    public override void OnDeactive()
    {
        active = false;
        _controlPanelControllers.MoveWindlass(active, type);
        _tap.ReleaseButton();
    }

    /// <summary>
    /// Создает кнопку
    /// <params> ControlPanelController - _controlPanelControllers </params>
    /// </summary>
    public class ButtonForWindlassFabrik : PlaceholderFactory<ControlPanelController, ButtonWindlassY>
    {

    }
}
