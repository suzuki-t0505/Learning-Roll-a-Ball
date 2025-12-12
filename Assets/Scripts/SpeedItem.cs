using UnityEngine;

public class SpeedItem : MonoBehaviour
{
    [SerializeField]
    private float _addSpeed = 5f;

    [SerializeField]
    private float _duration = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        PlayerController playerController = other.GetComponent<PlayerController>();
        playerController.SeedUp(_addSpeed, _duration);
        this.gameObject.SetActive(false);
    }
}
