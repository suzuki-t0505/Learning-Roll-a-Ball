using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Plyaerゲームオブジェクトを保存する変数
    /// </summary>
    public GameObject player;

    /// <summary>
    /// Playerゲームオブジェクトとカメラの距離を保存するための変数
    /// </summary>
    private Vector3 _offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // カメラのPositionからPlyaerのPositionを引くことで距離を求める
        _offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // Playerの移動に合わせてカメラを移動させる。
        // また、Playerのとカメラの距離を一定に保つために、_offsetを足している
        transform.position = player.transform.position + _offset;
    }
}
