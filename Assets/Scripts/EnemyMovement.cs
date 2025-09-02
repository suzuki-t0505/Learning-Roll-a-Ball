using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    /// <summary>
    /// PlayerゲームオブジェクトのTransformコンポーネントを保持する変数
    /// </summary>
    public Transform player;

    /// <summary>
    /// NavMeshAgentコンポーネントを保持する変数
    /// </summary>
    private NavMeshAgent _navMeshAgent;
    
    void Start()
    {
        // このオブジェクトにアタッチされたNavMeshAgentコンポーネントを取得して変数に割当する
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // プレイヤーへの参照がある場合に処理をする
        if (player != null)
        {
            // このオブジェクト（敵）の目的地をプレイヤーの現在位置に設定する
            _navMeshAgent.SetDestination(player.position);
        }
    }
}
