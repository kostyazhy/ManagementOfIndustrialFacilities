using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Inject]
    private GameConfig _config;

    public override void InstallBindings()
    {
        Container.Bind<CraneController>().AsSingle();

        Container.BindFactory<Vector3, ControlCrane, ControlCrane.CraneFabrik>().FromComponentInNewPrefab(_config.prefabCrane);
        Container.BindFactory<float, float, CraneController, Tower, Tower.TowerFabrik>().FromComponentInNewPrefab(_config.prefabTower);
       
    }
}
