using UnityEngine;
using UnityEngine.AI;

public class EnemyMovment : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent _navMeshAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!System.Object.ReferenceEquals(player.gameObject, null))
        {
            _navMeshAgent.SetDestination(player.position);
        }
    }
}
