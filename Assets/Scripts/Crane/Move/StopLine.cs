using UnityEngine;

/// <summary>
/// Стопор для движущихся объектов
/// </summary>
public class StopLine : MonoBehaviour, IStopLine
{
    /// <summary>
    /// Если объект соприкаснулся с тригером линии, то у обетка вызываеться 
    /// метод - StopUnit
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        var unit = other.GetComponent<IMobileUnit>();
        if (unit != null) {
            Debug.Log(other.name);
            unit.Stop();
        }
    }
}
