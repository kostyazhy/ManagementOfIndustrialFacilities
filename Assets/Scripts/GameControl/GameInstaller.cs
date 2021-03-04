using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Inject]
    private GameConfig _config;

    public struct SignalCheckpointReached { }

    public override void InstallBindings()
    {
        // Create controllers
        Container.Bind<CraneController>().AsSingle();
        Container.Bind<ControlPanelController>().AsSingle();

        // Create objects for crane
        Container.BindFactory<IMobileUnit, IWindlass, Magnet, ControlCrane, ControlCrane.CraneFabrik>()
            .FromComponentInNewPrefab(_config.prefabCrane);
        Container.BindFactory<float, CraneController, Tower, Tower.TowerFabrik>()
            .FromComponentInNewPrefab(_config.prefabTower);
        Container.BindFactory<float, Vector3, Magnet, CraneController, Windlass, Windlass.WindlassFabrik>()
            .FromComponentInNewPrefab(_config.prefabWindlass);
        Container.BindFactory<float, CraneController, Magnet, Magnet.MagnetFabrik>()
            .FromComponentInNewPrefab(_config.prefabMagnet);

        // Create objects for control panel
        Container.BindFactory<ControlPanelController, ControlPanel, ControlPanel.ControlPanelFabrik>()
            .FromComponentInNewPrefab(_config.prefabControlPanel);
        Container.BindFactory<ControlPanelController, SwitchTower, SwitchTower.SwitchForwardFabrik>()
            .FromComponentInNewPrefab(_config.prefabSwitchForward);
        Container.BindFactory<ControlPanelController, SwitchWindlass, SwitchWindlass.SwitchBackFabrik>()
            .FromComponentInNewPrefab(_config.prefabWindlassLeft);
        Container.BindFactory<ControlPanelController, ButtonWindlassY, ButtonWindlassY.ButtonForWindlassFabrik>()
            .FromComponentInNewPrefab(_config.prefabButtonForWindlass);
        Container.BindFactory<ControlPanelController, ButtonMagnet, ButtonMagnet.ButtonMagnetFabrik>()
            .FromComponentInNewPrefab(_config.prefabButtonForMagnet);
    }

    
}
