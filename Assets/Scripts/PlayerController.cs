using UnityEngine;
// PlayerゲームオブジェクトにアタッチしたPlayerInputから入力を受け付けるために必要な名前空間
/*
キーボード・ゲームパッド
↓
Actions
↓
PlayerゲームオブジェクトにアタッチしたPlayerInput
↓
このスクリプト
*/
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // private変数は他のスクリプトから値を取得・変更させることができない変数のことです。
    // privateで変数を定義する場合は変数名の最初に_（アンダーバー）をつけます。

    /// <summary>
    /// X方向の移動量を保存する変数
    /// </summary>
    private float _movmentX;

    /// <summary>
    /// Y方向の移動量を保存する変数
    /// </summary>
    private float _movmentY;

    /// <summary>
    /// PlayerにアタッチされているRigidbodyを保存する変数
    /// </summary>
    private Rigidbody _rb;

    private int _count;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    
    /// <summary>
    /// Playerの移動速度を保存する変数
    /// </summary>
    public float speed = 5f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    /// <summary>
    /// プレイヤーのキーボード（WASD）/ゲームパッド（Lスティック）の入力があった際に呼び出される関数です。
    /// </summary>
    /// <param name="movementValue">入力デバイスのX方向とY方向の値を持っています。</param>
    void OnMove(InputValue movementValue)
    {

        Vector2 movementVector = movementValue.Get<Vector2>();
        _movmentX = movementVector.x;
        _movmentY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(_movmentX, 0.0f, _movmentY);

        _rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            _count += 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + _count.ToString();

        if (_count >= 10)
        {
            winTextObject.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }
}
