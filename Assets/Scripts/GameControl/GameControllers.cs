using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Создан для отслеживания глобальных событий.
/// Инициализация, Пауза, Выход
/// </summary>
public class GameControllers : MonoBehaviour
{
    [Inject]
    private CraneController _craneController;

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
    }
}
