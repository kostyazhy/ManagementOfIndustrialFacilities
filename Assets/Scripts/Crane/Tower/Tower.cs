using UnityEngine;
using Zenject;


/// <summary>
/// Задает поведение движения башни
/// </summary>
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

    /// <summary>
    /// Двигает башню назад
    /// </summary>
    public void MoveBack()
    {
        _transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    /// <summary>
    /// Двигает башню вперед
    /// </summary>
    public void MoveForward()
    {
        _transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    /// <summary>
    /// Останавливает башню перед ограничителем
    /// </summary>
    public void Stop()
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
