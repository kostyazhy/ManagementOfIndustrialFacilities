using Zenject;


/// <summary>
/// Создает панель управления и все его комплектующие
/// </summary>
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



    /// <summary>
    /// Инициирует создание панели управления
    /// </summary>
    public void Init()
    {
        CreateControlPanel();
    }

    /// <summary>
    /// Создает панель управления и его комплектующие: рубильники двигающие башню вперед/назад,
    /// рубильники двигающие лебедку влево/вправо, кнопки двигающие магнит вверх/вниз,
    /// кнопка активации магнита.
    /// А таже метод располагает объекты на сцене
    /// </summary>
    /// <returns>Возвращает экземпляр панели управления - ControlPanel </returns>
    public ControlPanel CreateControlPanel()
    {
        var controlPanel = _controlPanelFabrik.Create(this);
        controlPanel.transform.position = _config.StartPositionControlPanel;

        var switchForward = CreateSwitchTower(controlPanel);
        var switchBack = CreateSwitchTower(controlPanel);
        var switchLest = CreateSwitchWindlass(controlPanel);
        var switchRight = CreateSwitchWindlass(controlPanel);
        var buttonWindlassDown = CreateButtonWindlass(controlPanel);
        var buttonWindlassUp = CreateButtonWindlass(controlPanel);
        var buttonMagnet = CreateButtonActiveMagnet(controlPanel);

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

    /// <summary>
    /// Создает переключатель для управления башней
    /// </summary>
    /// <param name="controlPanel"> Экземпляр класса панели управления </param>
    /// <returns> Экземпляр класса SwitchTower </returns>
    public SwitchTower CreateSwitchTower(ControlPanel controlPanel)
    {
        return _switchForwardFabrik.Create(controlPanel);
    }


    /// <summary>
    /// Создает переключатель для управления лебедкой
    /// </summary>
    /// <param name="controlPanel"> Экземпляр класса панели управления </param>
    /// <returns> Экземпляр класса SwitchWindlass </returns>
    public SwitchWindlass CreateSwitchWindlass(ControlPanel controlPanel)
    {
        return _switchBackFabrik.Create(controlPanel);
    }

    /// <summary>
    /// Создает переключатель для управления тросом лебедки
    /// </summary>
    /// <param name="controlPanel"> Экземпляр класса панели управления </param>
    /// <returns> Экземпляр класса ButtonWindlassY </returns>
    public ButtonWindlassY CreateButtonWindlass(ControlPanel controlPanel)
    {
        return _buttonForWindlassFabrik.Create(controlPanel);
    }

    /// <summary>
    /// Создает переключатель для управления магнитом
    /// </summary>
    /// <param name="controlPanel"> Экземпляр класса панели управления </param>
    /// <returns> Экземпляр класса ButtonMagnet </returns>
    public ButtonMagnet CreateButtonActiveMagnet(ControlPanel controlPanel)
    {
        return _buttonForMagnetFabrik.Create(controlPanel);
    }
}
