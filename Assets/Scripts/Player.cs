using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2f;
    public float jumpForce = 5f;
    private Rigidbody2D _rigidbody2D;
    
    [SerializeField]
    private bool betterJump = false;
    private float fallForceMultiplier = 0.5f;
    private float lowJumpForceMultiplier = 1f;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        Jump();
        
    }

    private void Jump()
    {
        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        }

        if (betterJump)
        {
            if (_rigidbody2D.velocity.y < 0 && !Input.GetKey("space"))
            {
                _rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallForceMultiplier) * Time.deltaTime;
            }
            if (_rigidbody2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                _rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpForceMultiplier) * Time.deltaTime;
            }
        }
    }
    void MovePlayer()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), _rigidbody2D.velocity.y);
    }
}
