using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10; // Salute del nemico
    public GameObject deathPrefab; // Prefab da istanziare alla morte

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Istanzia il prefab di morte nella posizione del nemico
        if (deathPrefab != null)
        {
            Instantiate(deathPrefab, transform.position, transform.rotation);
        }

        // Distruggi il nemico
        Destroy(gameObject);
    }
}
