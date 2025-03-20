using UnityEngine;

public class BossShooter : MonoBehaviour
{
    public Transform player; // Riferimento al Transform del player
    public Transform firePoint; // Punto di sparo dei proiettili
    public GameObject projectilePrefab; // Prefab del proiettile
    public float attackRange = 10f; // Raggio d'azione per rilevare il player
    public float fireRate = 5f; // Intervallo di tempo tra i colpi
    private float nextFireTime = 0f; // Timer per il prossimo colpo

    void Update()
    {
        // Verifica se il player si trova nel raggio d'azione
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            // Controlla se è il momento di sparare
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate; // Aggiorna il timer per il prossimo colpo
            }
        }
    }

    void Shoot()
    {
        Debug.Log("Il boss sta sparando!");
        // Crea il proiettile al punto di sparo con la rotazione del firePoint
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }

    void OnDrawGizmosSelected()
    {
        // Visualizza il raggio d'azione nel Scene View per facilitare il debug
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
