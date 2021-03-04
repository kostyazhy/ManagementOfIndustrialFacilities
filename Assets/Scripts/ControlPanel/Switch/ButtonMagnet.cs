using Zenject;

/// <summary>
/// Описывает поведение кнопки активации магнита
/// </summary>
public class ButtonMagnet : Switch, ISwitch
{
    [Inject]
    private ControlPanelController _controlPanelControllers;
    private TapButton _tap;

    private void Start()
    {
        _tap = GetComponent<TapButton>();
    }

    /// <summary>
    /// Активирует и деактивирует магнит
    /// </summary>
    public override void OnActive()
    {
        active = !active;
        _controlPanelControllers.ActiveMagnet(active, type);
        _tap.Tap();
        _tap.ReleaseButton();
    }

    /// <summary>
    /// НЕ деактивирует магнит - отключена
    /// </summary>
    public override void OnDeactive()
    {

    }

    /// <summary>
    /// Создает кнопку
    /// <params> ControlPanelController - _controlPanelControllers </params>
    /// </summary>
    public class ButtonMagnetFabrik : PlaceholderFactory<ControlPanelController, ButtonMagnet>
    {

    }
}
