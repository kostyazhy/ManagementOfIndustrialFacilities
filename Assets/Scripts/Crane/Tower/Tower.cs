using UnityEngine;
using Zenject;


/// <summary>
/// Задает поведение движения башни
/// </summary>
public class Tower : MonoBehaviour, IMobileUnit
{
    private Transform _transform;
    private Rigidbody _rgb;
    [Inject]
    private float _speed;
    [Inject]
    private CraneController _craneController;

    public bool MoveForwardFlag { get; set; } = false;

    public bool MoveBackFlag { get; set; } = false;
    public bool MoveStopFlag { get; set; } = false;

    private void Start()
    {
        _transform = transform;
        _rgb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (MoveForwardFlag) {
            MoveBack();
        } else if (MoveBackFlag) {
            MoveForward();
        }

        if (MoveStopFlag) {
            Stop();
        }
    }

    /// <summary>
    /// Двигает башню назад
    /// </summary>
    public void MoveBack()
    {
        _rgb.AddForce(Vector3.left * _speed);
    }

    /// <summary>
    /// Двигает башню вперед
    /// </summary>
    public void MoveForward()
    {
        _rgb.AddForce(Vector3.right * _speed);
    }

    /// <summary>
    /// Останавливает башню перед ограничителем
    /// </summary>
    public void Stop()
    {
        _rgb.velocity = Vector3.zero;
    }

    /// <summary>
    /// Создаем объект - башни
    /// </summary>
    /// <params>
    /// float - _speed
    /// CraneController - _craneController
    /// </params>
    public class TowerFabrik : PlaceholderFactory<float, CraneController, Tower>
    {


    }
}
