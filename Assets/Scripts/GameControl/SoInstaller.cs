using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SoInstaller", menuName = "Installers/SoInstaller")]
public class SoInstaller : ScriptableObjectInstaller<SoInstaller>
{
    [SerializeField]
    private GameConfig _config;
    [SerializeField]
    private GameObject _prefabCrane;
    [SerializeField]
    private GameObject _prefabTower;
    [SerializeField]
    private GameObject _prefabWindlass;
    [SerializeField]
    private GameObject _prefabMagnet;


    public override void InstallBindings()
    {
        Container.BindInstance(_config);
        //Container.BindInstance(_prefabCrane);
        //Container.BindInstance(_prefabTower);
        /*Container.BindInstance(_prefabWindlass);
        Container.BindInstance(_prefabMagnet);*/
    }
}