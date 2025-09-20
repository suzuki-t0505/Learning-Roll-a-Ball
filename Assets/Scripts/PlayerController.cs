using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody _rb;

    private float _movmentX;

    private float _movmentY;

    private int _count;

    public TextMeshProUGUI countText;

    public GameObject winTextObject;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movmentValue)
    {
        Vector2 movmentVector = movmentValue.Get<Vector2>();
        _movmentX = movmentVector.x;
        _movmentY = movmentVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movment = new Vector3(x: _movmentX, y: 0.0f, z: _movmentY);
        _rb.AddForce(movment * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            _count = _count + 1; // _count++;
            SetCountText();
            // Debug.Log($"count = {_count}");
        }
    }

    private void SetCountText()
    {
        countText.text = "Count: " + _count.ToString();

        if (_count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }
}
