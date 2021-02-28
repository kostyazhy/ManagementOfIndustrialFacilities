using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ControlCrane : MonoBehaviour
{
    [Inject]
    private GameConfig _config;

    public bool activeForwardSwitch = false;
    public bool activeBackSwitch = false;

    private ITower _tower;

    [Inject]
    private Vector3 _startPosTower;

    private void Start()
    {
        //Init();
    }

    private void Update()
    {
        if (activeBackSwitch)
            _tower.MoveBack();
        else if (activeForwardSwitch)
            _tower.MoveThere();
    }

    /*public void Init()
    {
        CreateTower();
    }*/

    public void Reset()
    {
        _startPosTower = _config.StartPositionTower;
    }

    public class CraneFabrik : Factory<Vector3, ControlCrane>
    {

    }


}
