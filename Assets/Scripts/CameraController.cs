using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Playerゲームオブジェクトを保存する変数
    /// </summary>
    public GameObject player;

    /// <summary>
    /// Playerゲームオブジェクトとカメラの距離を保存する変数
    /// </summary>
    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + _offset;
    }
}
