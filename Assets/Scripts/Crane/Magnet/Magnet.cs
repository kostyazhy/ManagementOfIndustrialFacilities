using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

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

    void FixedUpdate()
    {
        if (ActiveMagnetFlag) {
            if (_rgbObjects != null) {
                //Debug.Log("Active magnet");
                foreach (var rgbObject in _rgbObjects) {
                    rgbObject.AddForce((_magnetPoint.position - rgbObject.position) * _magnetPower * Time.deltaTime);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IMagnetObject>() != null) {
            _rgbObjects.Add(other.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<IMagnetObject>() != null) {
            _rgbObjects.Remove(other.GetComponent<Rigidbody>());
        }
    }

    public class MagnetFabrik : Factory<float, CraneController, Magnet>
    {

    }
}
