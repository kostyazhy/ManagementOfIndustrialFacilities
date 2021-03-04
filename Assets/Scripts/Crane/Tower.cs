using UnityEngine;
using System.Collections;
using Zenject;

public class Tower : MonoBehaviour, IMobileUnit
{
    private Transform _transform;
    [Inject]
    private float _speed;
    [Inject]
    private CraneController _craneController;

    public bool MoveForwardFlag { get; set; } = false;

    public bool MoveBackFlag { get; set; } = false;

    private void Start()
    {
        _transform = transform;
    }

    void FixedUpdate()
    {
        if (MoveForwardFlag) {
            MoveBack();
        } else if (MoveBackFlag) {
            MoveForward();
        }
    }

    public void MoveBack()
    {
        _transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    public void MoveForward()
    {
        _transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    public void StopUnit()
    {
        Debug.Log("Stop");
        MoveBackFlag = false;
        MoveForwardFlag = false;
        /*if (MoveBackFlag) {
            MoveBackFlag = false;
            MoveForward();
        } else if (MoveForwardFlag) {
            MoveForwardFlag = false;
            MoveBack();
        }*/
    }

    public class TowerFabrik : Factory<float, CraneController, Tower>
    {

    }
}
