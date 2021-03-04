using UnityEngine;

/// <summary>
/// Формирует общие методы и переменные для переключателей
/// </summary>
public abstract class Switch: MonoBehaviour
{
    protected bool active = false;

    public TypeSwitch.Type type;
    
    /// <summary>
    /// Изменяет состояние переключателя на активный
    /// </summary>
    public virtual void OnActive()
    {
        active = true; 
    }

    /// <summary>
    /// Изменяет состояние переключателя на не активный
    /// </summary>
    public virtual void OnDeactive()
    {
        active = false;
    }
}
