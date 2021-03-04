using System.Collections.Generic;
using UnityEngine;
using Zenject;


/// <summary>
/// Описывает поведение магнита
/// </summary>
public class Magnet : MonoBehaviour
{
    [Inject]
    private CraneController _craneController;
    [Inject]
    private float _magnetPower;

    private Transform _magnetPoint;

    private List<Rigidbody> _rgbObjects = new List<Rigidbody>();

    public bool ActiveMagnetFlag { get; set; } = false;

    private void Start()
    {
        _magnetPoint = transform;
    }

    /// <summary>
    /// Если магнит активен, то притягиваем все объекты попавшие в его триггер
    /// </summary>
    void FixedUpdate()
    {
        if (ActiveMagnetFlag) {
            if (_rgbObjects != null) {
                foreach (var rgbObject in _rgbObjects) {
                    rgbObject.AddForce((_magnetPoint.position - rgbObject.position) * _magnetPower * Time.deltaTime);
                }
            }
        }
    }

    /// <summary>
    /// Если объект попал в триггер магнита, то добавляем в список
    /// </summary>
    /// <param name="other"> Объект который попал в триггер </param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IMagnetObject>() != null) {
            _rgbObjects.Add(other.GetComponent<Rigidbody>());
        }
    }

    /// <summary>
    /// Если объект вышел из триггера магнита, то удаляем из списока
    /// </summary>
    /// <param name="other"> Объект который вышел из триггера </param>
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IMagnetObject>() != null) {
            _rgbObjects.Remove(other.GetComponent<Rigidbody>());
        }
    }

    /// <summary>
    /// Создаем объет магнит
    /// </summary>
    /// <params>
    /// float - _magnetPower; 
    /// CraneController - _craneController
    /// </params>
    public class MagnetFabrik : PlaceholderFactory<float, CraneController, Magnet>
    {

    }
}
