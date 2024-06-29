using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementScript : MonoBehaviour
{
    public UnityEvent<GameObject> OnPlayerCollisionEnter = new UnityEvent<GameObject>();
    public Rigidbody2D Rigidbody = null;

    public float MovementSpeed = 0.0f;
    public float JumpForce = 0.0f;
    public bool VerticalMovementEnabled = false;
    public bool JumpLimiter = true;
    public bool CanJump = true;
    
    void Start()
    {
        
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        Vector3 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }

        if (VerticalMovementEnabled)
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                direction += Vector3.up;
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                direction += Vector3.down;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        transform.position += direction * MovementSpeed * Time.deltaTime;
    }

    void Jump()
    {
        if (!CanJump)
        {
            return;
        }

        Rigidbody.velocity = Vector2.up * JumpForce;
        if (JumpLimiter)
        {
            CanJump = false;
        }
    }

    void ResetJump()
    {
        CanJump = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject CollidedGameObject = collision.gameObject;
        if (CollidedGameObject.tag == "Platform")
        {
            ResetJump();
        }

        OnPlayerCollisionEnter.Invoke(CollidedGameObject);
    }
}
