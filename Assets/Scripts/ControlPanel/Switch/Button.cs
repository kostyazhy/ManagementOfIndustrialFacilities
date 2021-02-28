using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, ISwitch
{
    public void OnActive()
    {
        Debug.Log("On actived Button");
    }
}
