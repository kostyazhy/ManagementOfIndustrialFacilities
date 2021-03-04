using UnityEngine;
using Zenject;


/// <summary>
/// Создает конфиг симулятора и помещает его в зависимости
/// </summary>
[CreateAssetMenu(fileName = "SoInstaller", menuName = "Installers/SoInstaller")]
public class SoInstaller : ScriptableObjectInstaller<SoInstaller>
{
    [SerializeField]
    private GameConfig _config;

    public override void InstallBindings()
    {
        Container.BindInstance(_config);
    }
}