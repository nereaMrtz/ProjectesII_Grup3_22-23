using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _currentSpeed = 75;

    private Vector2 movementDirection;

    private float _movementX;
    private float _movementY;

    // Update is called once per frame
    void Update()
    {
        _movementX = 0;
        _movementY = 0;
        if (Input.GetKey(KeyCode.A))
        {
            _movementX += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _movementX += 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            _movementY += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _movementY += -1;
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        movementDirection = new Vector3(_movementX, _movementY).normalized;
        _rigidbody2D.AddForce(movementDirection * _currentSpeed, ForceMode2D.Force);
    }
}