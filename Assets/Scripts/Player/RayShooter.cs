﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
            Vector3 point = new Vector3( _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point); 
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                GameObject hitObject = hit.transform.gameObject; 
                ISwitch _switch = hitObject.GetComponent<ISwitch>();
                if (_switch != null) {
                    _switch.OnActive();
                } 
            }
        }
    }

    void OnGUI()
    {
        int size = 15;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*"); 
    }
}
