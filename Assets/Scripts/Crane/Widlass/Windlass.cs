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

    private Transform _transform;
    [SerializeField]
    private Transform _cable;
    [SerializeField]
    private FixedJoint _bracing;

    // states for changing the movement
    public bool MoveForwardFlag { get; set; } = false;

    public bool MoveBackFlag { get; set; } = false;

    public bool MoveUpFlag { get; set; } = false;
    
    public bool MoveDownFlag { get; set; } = false;

    private void Start()
    {
        _transform = transform;
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
    }

    /// <summary>
    /// Двигает лебедку влево
    /// </summary>
    public void MoveBack()
    {
        _transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    /// <summary>
    /// Двигает лебедку вправо
    /// </summary>
    public void MoveForward()
    {
        _transform.Translate(Vector3.right * _speed * Time.deltaTime);
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
        Debug.Log("Stop");
        MoveBackFlag = false;
        MoveForwardFlag = false;
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
