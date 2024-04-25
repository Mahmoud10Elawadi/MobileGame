using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class Knight : MonoBehaviour
{
    public float walkSpeed = 3f;

    Rigidbody2D rb;
    TouchingDirections touchingDirections;

    public enum WalkableDirection { Right, Left }

    private WalkableDirection _walkDirection; // Default walk direction is right
    private Vector2 walkDirectionVector = Vector2.right; // Define walkDirectionVector here

    public WalkableDirection WalkDirection
    {
        get { return _walkDirection; }
        set
        {
            if (_walkDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if (value == WalkableDirection.Right)
                {
                    walkDirectionVector = Vector2.right;
                }
                else if (value == WalkableDirection.Left)
                {
                    walkDirectionVector = Vector2.left;

                }
            }
            _walkDirection = value;

        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    private void FixedUpdate()
    {
        // Check if the character is about to fall off the ground and flip direction
        if (touchingDirections.IsGrounded && !touchingDirections.IsOnWall && rb.velocity.y <= 0)
        {
            RaycastHit2D groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, LayerMask.GetMask("Ground"));
            if (groundCheck.collider == null)
            {
                FlipDirection();
            }
        }
        else
        {
            // Stop movement if direction is flipped
            if (rb.velocity.x != 0 && Mathf.Sign(rb.velocity.x) != Mathf.Sign(walkSpeed * walkDirectionVector.x))
            {
                rb.velocity = Vector2.zero;
            }

            rb.velocity = new Vector2(walkSpeed * walkDirectionVector.x, rb.velocity.y);
        }
    }





    private void FlipDirection()
    {
        if (WalkDirection == WalkableDirection.Right)
        {
            WalkDirection = WalkableDirection.Left;
        }
        else if (WalkDirection == WalkableDirection.Left)
        {
            WalkDirection = WalkableDirection.Right;
        }
        else
        {
            Debug.LogError("Current walkable direction is neither right or left");
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
