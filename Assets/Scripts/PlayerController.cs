using UnityEngine;
// PlayerゲームオブジェクトにアタッチしたPlayerInputからの入力を受け付けるために必要な名前空間
// キーボード/ゲームパッド → Actions（ProjectビューにあるInputSystem_Actionsファイル） →
// PlayerゲームオブジェクトにアタッチしたPlyaerInput → このスクリプト
using UnityEngine.InputSystem;

public class PlayerContrller : MonoBehaviour
{
    /// <summary>
    /// Playerの移動速度を保存する変数
    /// </summary>
    public float speed = 5f;

    // private（プライベート）で定義する変数の名前は最初に_（アンダーバー）を付けます。
    // private変数は他のスクリプトファイルから値を取得・変更させることができない変数です。

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
        // PlayerにアタッチされたRigidbodyを取得し変数_rbに保存します。
        _rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// プレイヤーのキーボード（WASD）/ゲームパッド（Lスティック）の入力があった際に呼び出される関数です。
    /// </summary>
    /// <param name="movementValue">入力デバイスのX方向とY方向の値を持っています。</param>
    void OnMove(InputValue movementValue)
    {
        // Vecotr2（2次元座標：X座標/Y座標）型の変数movementVecotrにmovementValueをVector2（2次元座標）に変換し保存します。
        Vector2 movementVector = movementValue.Get<Vector2>();

        // movementVectorのX座標・Y座標をそれぞれに変数に保存します。
        _movementX = movementVector.x;
        _movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        // _movmentXをX軸の値に_movmentYをZ軸の値にした3次元座標に変換し変数momventに保存します。
        Vector3 movement = new Vector3(x: _movementX, y: 0.0f, z: _movementY);

        // RigidbodyのAddFrouce関数に3次元座標を渡し、指定した方向に力を加えます。
        // movment（力）にspeed（移動速度）掛け合わせます。
        _rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        // プレイヤーが衝突したオブジェクトにPickUpタグが付いているか確認します。
        if (other.gameObject.CompareTag("PickUp"))
        {
            // 衝突したオブジェクトを非アクティブ化します。（非表示になる）
            other.gameObject.SetActive(false);
        }
    }
}