using UnityEngine;

/// <summary>
/// Описывает простое движение игрока
/// </summary>
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour, IMovePlayer
{
    [SerializeField]
    private float _speed = 6.0f;
    [SerializeField]
    private float _gravity = -9.8f;
    private Transform _transform;
    private CharacterController _charController;

    void Start()
    {
        _transform = transform;
        _charController = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        Move();
    }

    /// <summary>
    /// Реагирует на ввод с клавы и перемещает игрока
    /// </summary>
    public void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ = Input.GetAxis("Vertical") * _speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, _speed);
        movement.y = _gravity;
        movement *= Time.deltaTime;
        movement = _transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
