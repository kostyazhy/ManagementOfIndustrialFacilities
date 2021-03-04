using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMagnet : MonoBehaviour
{
    [SerializeField]
    private float _magnetPower;

    [SerializeField]
    private Transform _magnetPoint;

    private List<Rigidbody> _rgbObjects = new List<Rigidbody>();

    void FixedUpdate()
    {
        if (_rgbObjects != null)
            foreach (var rgbObject in _rgbObjects) {
                rgbObject.AddForce((_magnetPoint.position - rgbObject.position) * _magnetPower * Time.deltaTime);
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

}

