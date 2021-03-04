using UnityEngine;
using Zenject;

/// <summary>
/// Создан для отслеживания глобальных событий.
/// Инициализация объектов, Пауза, Выход
/// </summary>
public class GameControllers : MonoBehaviour
{
    [Inject]
    private CraneController _craneController;

    [Inject]
    private ControlPanelController _controlPanelController;

    public void Start()
    {
        Init();
    }

    /// <summary>
    /// Создает кран и панель управление 
    /// </summary>
    private void Init()
    {
        _craneController.Init();
        _controlPanelController.Init();
    }
}
