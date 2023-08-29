using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerT : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] float _jumpPower = 5f;
    [SerializeField] float m_gravityDrag = .8f;
    Rigidbody2D _rb;
    private bool _isjumping = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = _rb.velocity;
        velocity.x = h * _moveSpeed;
        _rb.velocity = velocity;
        if (Input.GetKeyDown(KeyCode.Space) && !_isjumping)
        {
            _rb.velocity = Vector3.up * _jumpPower;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("ground"))
        _isjumping = false;

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("ground"))
        {
            _isjumping = true;
        }
    }
}