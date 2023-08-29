using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{


    
    Rigidbody2D _rb2d = default;
    [SerializeField] float _speed = 5f;
    float _junpPower = 5f;
    Vector2 _input2d = Vector2.zero;
    public bool _isGround = true;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        _input2d.x = Input.GetAxis("Horizontal");
        _input2d.y = Input.GetAxis("Vertical");
            
    }
    private void FixedUpdate()
    {
        if (_input2d == Vector2.zero) _rb2d.Sleep();
        if (_rb2d.IsSleeping()) _rb2d.WakeUp();
        Vector2 moveVec2d = new(_input2d.x, y: _input2d.y);
        _rb2d.AddForce(moveVec2d, ForceMode2D.Impulse);
        moveVec2d.Normalize();
        moveVec2d *= (_speed * Time.deltaTime);
        _rb2d.AddForce(moveVec2d, ForceMode2D.Impulse);
    }
}