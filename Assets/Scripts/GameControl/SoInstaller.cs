using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SoInstaller", menuName = "Installers/SoInstaller")]
public class SoInstaller : ScriptableObjectInstaller<SoInstaller>
{
    [SerializeField]
    private GameConfig _config;

    /*[SerializeField]
    private GameEvent _gameEventMoveTowerForward;*/
    /*
    [SerializeField]
    private GameEvent _gameEventMoveTowerBack;*/

    public override void InstallBindings()
    {
        Container.BindInstance(_config);
        //Container.BindInstance(_gameEventMoveTowerForward);
        //Container.BindInstance(_gameEventMoveTowerBack);
    }
}