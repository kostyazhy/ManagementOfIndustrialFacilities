using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCrane : MonoBehaviour, IMobileUnit
{
    private Transform _transform;

    public bool activeForwardSwitch = false;
    public bool activeBackSwitch = false;

    private void Update()
    {
        if (activeBackSwitch)
            MoveBack();
        else if (activeForwardSwitch)
            MoveForward();
    }

    public void MoveForward()
    {
        Debug.Log("MoveForward");
        transform.Translate(Vector3.forward);
    }

    public void MoveBack()
    {
        Debug.Log("MoveBack");
        transform.Translate(Vector3.back);
    }

    public void MoveLeft()
    {
        throw new System.NotImplementedException();
    }

    public void MoveRight()
    {
        throw new System.NotImplementedException();
    }

    public void MoveUp()
    {
        throw new System.NotImplementedException();
    }

    public void MoveDown()
    {
        throw new System.NotImplementedException();
    }
}
