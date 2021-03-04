using Zenject;


/// <summary>
/// Создает кран и все его комплектующие
/// </summary>
public class CraneController
{
    [Inject]
    private GameConfig _config;
    [Inject]
    private ControlCrane.CraneFabrik _craneFabrik;
    [Inject]
    private Tower.TowerFabrik _towerFabrik;
    [Inject]
    private Windlass.WindlassFabrik _windlassFabrik;
    [Inject]
    private Magnet.MagnetFabrik _magnetFabrik;

    /// <summary>
    /// Инициирует создание крана
    /// </summary>
    public void Init()
    {
        CreateCrane();
    }

    /// <summary>
    /// Создает кран и его комплектующие: башню, лебедку, магнит
    /// и располагает на сцене
    /// </summary>
    /// <returns> Возвращает экземпляр класса кран </returns>
    private ControlCrane CreateCrane()
    {
        var magnet = CreateMagnet();

        var windlass = CreateWindlass(magnet);
        
        var tower = CreateTower();
        
        var crane = _craneFabrik.Create(tower, windlass, magnet);

        crane.transform.position = _config.PosCrane;

        magnet.transform.SetParent(windlass.transform);
        magnet.transform.localPosition = _config.StartPositionMagnet;

        windlass.transform.SetParent(tower.transform);
        windlass.transform.localPosition = _config.StartPositionWindlass;

        tower.transform.SetParent(crane.transform);
        tower.transform.localPosition = _config.StartPositionTower;

        return crane;
    }

    /// <summary>
    /// Содает башню
    /// </summary>
    /// <returns> Возвращает экземпляр класса башня - Tower </returns>
    private Tower CreateTower()
    {
        return _towerFabrik.Create(_config.SpeedTowerCrane, this);
    }

    /// <summary>
    /// Создает лебедку
    /// </summary>
    /// <param name="magnet"> Получает параметр экземпляр магнита </param>
    /// <returns> Возвращает экземпляр класса лебедки - Windlass </returns>
    private Windlass CreateWindlass(Magnet magnet)
    {
        return _windlassFabrik.Create(_config.SpeedWindlass, _config.SpeedMagnet, magnet, this);
    }

    /// <summary>
    /// Создает магнит
    /// </summary>
    /// <returns> Возвращает экземпляр класса магнит - Magnet </returns>
    private Magnet CreateMagnet()
    {
        return _magnetFabrik.Create(_config.MagnetPower, this);
    }
}
