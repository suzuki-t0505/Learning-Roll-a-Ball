using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame　// 60fps->1秒間に60回実行される
    void Update()
    {
        // 指定された量だけx,y,z軸上でオブジェクトを回転させる
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
