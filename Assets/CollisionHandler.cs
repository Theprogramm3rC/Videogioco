using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collisione rilevata con: " + other.name);
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Il player ha colpito il nemico!");
            Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
            GetComponent<PlayerKnockback>().ApplyKnockback(knockbackDirection);
        }
    }
}