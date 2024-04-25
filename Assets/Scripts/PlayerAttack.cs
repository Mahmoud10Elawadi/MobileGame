using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Collider2D attackCollider; // Reference to the attack collider
    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }

    // This method is called when the player's attack animation starts
    public void StartAttackAnimation()
    {
        // Activate the attack collider when the attack animation starts
        attackCollider.enabled = true;
    }

    // This method is called when the player's attack animation ends
    public void EndAttackAnimation()
    {
        // Deactivate the attack collider when the attack animation ends
        attackCollider.enabled = false;
    }

    // This method is called when the attack collider intersects with another collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is an enemy
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy");
            // Access the health component of the enemy and decrease its health
            enemyHealth enemyHealth = other.GetComponent<enemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1); // You might want to pass the amount of damage here
            }
        }
    }
}
