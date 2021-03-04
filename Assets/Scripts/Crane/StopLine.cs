using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLine : MonoBehaviour, IStopLine
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IMobileUnit>() != null) {
            var unit = other.gameObject.GetComponent<IMobileUnit>();
            unit.StopUnit();
        }
    }
}
