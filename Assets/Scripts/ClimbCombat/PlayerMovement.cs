using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask platformLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    private void Awake()
    {
        // Grab references for Rigidbody2D and Animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Flip Player when moving left - right
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // Set Animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        // If no input is detected, freeze the horizontal movement
        if (horizontalInput == 0 && !Input.GetMouseButton(0))
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }

        // Wall Jump Logic
        if (wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;

                // Rotate player based on movement direction
                if (horizontalInput > 0.01f)
                    transform.eulerAngles = new Vector3(0, 0, 90);
                else if (horizontalInput < -0.01f)
                    transform.eulerAngles = new Vector3(0, 0, -90);

                // Calculate the direction perpendicular to the wall
                Vector2 wallNormal = new Vector2(transform.localScale.x, 0).normalized;

                // Move the player along the wall
                body.AddForce(-wallNormal * speed * horizontalInput, ForceMode2D.Impulse);
            }
            else
                body.gravityScale = 12;

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCooldown += Time.deltaTime;

        // Constrain rotation
        ConstrainRotation();
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCooldown = 0;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, platformLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }

    private void ConstrainRotation()
    {
        // Check if the player is moving vertically (upward or downward)
        if (Mathf.Abs(body.velocity.y) > 0.1f)
        {
            // Clamp the player's rotation on the z-axis to prevent flipping
            float desiredAngle = Mathf.Clamp(transform.eulerAngles.z, -45f, 45f);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, desiredAngle);
        }
    }
}
