using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody _rb;

    private float _movmentX;

    private float _movmentY;

    private int _count;

    private bool _isJump;
    private bool _isInterbal;

    [SerializeField]
    private float _jumpPower;

    public TextMeshProUGUI countText;

    public GameObject winTextObject;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();
        _isJump = false;
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movmentValue)
    {
        Vector2 movmentVector = movmentValue.Get<Vector2>();
        _movmentX = movmentVector.x;
        _movmentY = movmentVector.y;
    }

    void OnJump()
    {
        if (_isInterbal) return;
        _isJump = true;
        _isInterbal = true;
    }

    IEnumerator SetJumpInterbalCoroutine()
    {
        yield return new WaitForSeconds(2f);
        _isInterbal = false;
        yield break;
    }

    void FixedUpdate()
    {
        if (_isJump)
        {
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
            _isJump = false;
            StartCoroutine(SetJumpInterbalCoroutine());
        }
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
        }
    }

    private void SetCountText()
    {
        countText.text = "Count: " + _count.ToString();

        if (_count >= 12)
        {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
}
