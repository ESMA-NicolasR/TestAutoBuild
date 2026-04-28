using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _rb.AddForce(Vector2.right * speed);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            _rb.AddForce(Vector2.left * speed);
        }
    }
}
