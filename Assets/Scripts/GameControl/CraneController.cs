using Zenject;

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

    public void Init()
    {
        CreateCrane();
    }

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

    private Tower CreateTower()
    {
        return _towerFabrik.Create(_config.SpeedTowerCrane, this);
    }

    private Windlass CreateWindlass(Magnet magnet)
    {
        return _windlassFabrik.Create(_config.SpeedWindlass, _config.SpeedMagnet, magnet, this);
    }

    private Magnet CreateMagnet()
    {
        return _magnetFabrik.Create(_config.MagnetPower, this);
    }
}
