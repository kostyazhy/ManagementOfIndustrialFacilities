﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    private ISwitch _activeSwitch;

    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            GameObject hitObject = RaycastPlayer();
            _activeSwitch = hitObject.GetComponent<ISwitch>();
            if (_activeSwitch != null) {
                _activeSwitch.OnActive();
            }
            
        } else if (Input.GetMouseButtonUp(0)) {
            if (_activeSwitch != null) {
                _activeSwitch.OnDeactive();
            }
        }
    }

    private GameObject RaycastPlayer()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        Ray ray = _camera.ScreenPointToRay(point);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
             return hit.transform.gameObject;
        return null;
    }

    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*"); 
    }
}
