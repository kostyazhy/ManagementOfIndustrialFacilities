using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionJoint3D : MonoBehaviour
{
    [Range(0, 1)]
    public float Friction;
    private Rigidbody _rgb;

    private void Awake()
    {
        _rgb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _rgb.velocity = _rgb.velocity * (1 - Friction);
        _rgb.angularVelocity = _rgb.angularVelocity * (1 - Friction);
    }
}
