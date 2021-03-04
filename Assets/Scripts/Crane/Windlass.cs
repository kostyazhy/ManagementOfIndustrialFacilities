using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Windlass : MonoBehaviour, IWindlass, IMobileUnit
{
    [Inject]
    private CraneController _craneController;
    [Inject]
    private float _speed;
    [Inject]
    private Vector3 speedMagnet;
    [Inject]
    private Magnet _magnet;

    private Transform _transform;
    [SerializeField]
    private Transform _cable;
    [SerializeField]
    private FixedJoint _bracing;

    public bool MoveForwardFlag { get; set; } = false;

    public bool MoveBackFlag { get; set; } = false;

    public bool MoveUpFlag { get; set; } = false;

    public bool MoveDownFlag { get; set; } = false;

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (MoveForwardFlag) {
            MoveForward();
        } else if (MoveBackFlag) {
            MoveBack();
        }
        if (MoveDownFlag) {
            MoveDown();
        } else if (MoveUpFlag) {
            MoveUp();
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

    public void MoveUp()
    {
        if (_bracing.connectedBody == null)
            SetJointBody();

        _cable.localScale = _cable.localScale + speedMagnet;
    }

    public void MoveDown()
    {
        if (_bracing.connectedBody == null)
            SetJointBody();

        _cable.localScale = _cable.localScale - speedMagnet;
    }

    public void StopUnit()
    {
        Debug.Log("Stop");
        MoveBackFlag = false;
        MoveForwardFlag = false;
    }

    public void SetJointBody()
    {
        _bracing.connectedBody = _magnet.GetComponent<Rigidbody>();
    }

    public class WindlassFabrik : Factory<float, Vector3, Magnet, CraneController, Windlass>
    {

    }
}
