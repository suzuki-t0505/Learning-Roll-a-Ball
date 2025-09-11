using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody _rb;

    private float _movmentX;

    private float _movmentY;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movmentValue)
    {
        Vector2 movmentVector = movmentValue.Get<Vector2>();
        _movmentX = movmentVector.x;
        _movmentY = movmentVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movment = new Vector3(x: _movmentX, y: 0.0f, z: _movmentY);
        _rb.AddForce(movment * speed);
    }
}
