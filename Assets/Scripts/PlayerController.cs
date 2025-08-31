using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContrller : MonoBehaviour
{
    /// <summary>
    /// Playerの移動速度を保存する変数
    /// </summary>
    public float speed = 5f;

    /// <summary>
    /// PlayerにアタッチされたRigidbodyを保存する変数
    /// </summary>
    private Rigidbody _rb;

    /// <summary>
    /// X方向の移動量を保存する変数
    /// </summary>
    private float _movementX;

    /// <summary>
    /// Y方向の移動量を保存する変数
    /// </summary>
    private float _movementY;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// プレイヤーのキーボード（WASD）/ゲームパッド（Lスティック）の入力があった際に呼び出される関数です。
    /// </summary>
    /// <param name="movementValue">入力デバイスのX方向とY方向の値を持っています。</param>
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(x: _movementX, y: 0.0f, z: _movementY);
        _rb.AddForce(movement * speed);
    }
}