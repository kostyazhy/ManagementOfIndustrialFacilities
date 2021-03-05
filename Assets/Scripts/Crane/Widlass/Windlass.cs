using UnityEngine;
using Zenject;


/// <summary>
/// Задает поведение движения лебедки
/// </summary>
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

    [SerializeField]
    private Transform _cable;
    [SerializeField]
    private FixedJoint _bracing;

    private Rigidbody _rgb;

    // states for changing the movement
    public bool MoveForwardFlag { get; set; } = false;

    public bool MoveBackFlag { get; set; } = false;

    public bool MoveUpFlag { get; set; } = false;
    
    public bool MoveDownFlag { get; set; } = false;

    public bool MoveStopFlag { get; set; } = false;

    private void Start()
    {
        _rgb = GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
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
        if (MoveStopFlag) {
            Stop();
        }
    }

    /// <summary>
    /// Двигает лебедку влево
    /// </summary>
    public void MoveBack()
    {
        _rgb.AddForce(Vector3.forward * _speed);
    }

    /// <summary>
    /// Двигает лебедку вправо
    /// </summary>
    public void MoveForward()
    {
        _rgb.AddForce(Vector3.back * _speed);
    }

    /// <summary>
    /// Двигает трос с магнитом вверх
    /// </summary>
    public void MoveUp()
    {
        if (_bracing.connectedBody == null)
            SetJointBody();

        _cable.localScale = _cable.localScale + speedMagnet;
    }

    /// <summary>
    /// Двигает трос с магнитом вниз
    /// </summary>
    public void MoveDown()
    {
        if (_bracing.connectedBody == null)
            SetJointBody();

        _cable.localScale = _cable.localScale - speedMagnet;
    }

    /// <summary>
    /// Останавливает лебедку
    /// </summary>
    public void Stop()
    {
        _rgb.velocity = Vector3.zero;
    }

    /// <summary>
    /// Привязываем магнит к тосу
    /// </summary>
    public void SetJointBody()
    {
        _bracing.connectedBody = _magnet.GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Создаем объект - лебедки
    /// </summary>
    /// <params>
    /// float - _speed
    /// CraneController - _craneController
    /// </params>
    public class WindlassFabrik : PlaceholderFactory<float, Vector3, Magnet, CraneController, Windlass>
    {

    }
}
