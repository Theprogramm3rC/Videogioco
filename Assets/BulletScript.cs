using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        // Add a Rigidbody2D component and set collision detection to Continuous
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.gravityScale = 0; // Imposta la gravità a zero per evitare che il proiettile cada
        rb.linearVelocity = transform.right * speed; // Muovi il proiettile orizzontalmente

        // Se desideri che il proiettile si muova in base alla direzione del firePoint, usa:
        // rb.velocity = firePoint.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Destroy the bullet if it hits an enemy or goes out of bounds
        if (other.CompareTag("Enemy") || other.CompareTag("Bounds"))
        {
            Destroy(gameObject);
        }
    }
}
