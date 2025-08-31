using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        // フレームレートに合わせて指定された量だけ、X,Y,Z軸上でオブジェクトを回転させる
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
