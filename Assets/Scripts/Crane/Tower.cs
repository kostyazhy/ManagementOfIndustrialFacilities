using UnityEngine;
using Zenject;

public class Tower : MonoBehaviour, IMobileUnit
{
    private Transform _transform;

    /*[Inject]
    private GameConfig _config;*/
    [Inject]
    private float _speed;
    /*[Inject]
    private Vector3 deadLinePos;*/
    /*[Inject]
    private ControlCrane _controlCrane;*/
    [Inject]
    private CraneController _craneController;

    [Inject]
    private float minDistanceForDeadLine = 0.5f;

    private void Start()
    {
        //speed = _config.SpeedTowerCrane;
        _transform = transform;
        Debug.Log(_speed);
    }

    /*void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log(_controlCrane.activeForwardSwitch);
        }
    }*/

    public void MoveBack()
    {
        Debug.Log("MoveBack");
        _transform.Translate(Vector3.back * _speed * Time.deltaTime);
    }

    public void MoveThere()
    {
        Debug.Log("MoveThere");
        _transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void StopUnit()
    {
        //_controlCrane
        Debug.Log("Stop");
    }

    /*public bool IsDeadLine()
    {
        float dist = Vector3.Distance(deadLinePos, _transform.position);
        if (dist < minDistanceForDeadLine) {
            return true;
        } else {
            return false;
        } 
    }*/

    public class TowerFabrik : Factory<float, float, CraneController, Tower>
    {

    }
}
