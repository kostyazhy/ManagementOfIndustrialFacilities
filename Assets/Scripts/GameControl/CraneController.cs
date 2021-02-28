using UnityEngine;
using Zenject;

public class CraneController
{
    [Inject]
    private GameConfig _config;

    [Inject]
    private ControlCrane.CraneFabrik _craneFabrik;
    [Inject]
    private Tower.TowerFabrik _towerFabrik;

    public void Init()
    {
        CreateCrane();
    }

    /*private void CreateCrane()
    {
        //var crane = GameObject.Instantiate(_prefabCrane, _config.PosCrane, Quaternion.identity);
        ControlCrane controlCrane = crane.GetComponent<ControlCrane>();
        controlCrane.Init();
        //GameObject.Instantiate(_prefabTower);
    }*/

    private ControlCrane CreateCrane()
    {
        var tower = CreateTower();
        var crane = _craneFabrik.Create(_config.PosCrane);
        crane.transform.position = _config.PosCrane;
        return crane;
    }

    private Tower CreateTower()
    {
        return _towerFabrik.Create(_config.SpeedTowerCrane, _config.minDistanceForDeadLine, this);
    }
}
