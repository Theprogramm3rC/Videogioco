using UnityEngine;

public class ProjectileA : MonoBehaviour
{
    public float speed = 5f; // Velocità del proiettile
    public float lifeTime = 3f; // Durata del proiettile prima della distruzione automatica

    void Start()
    {
        Destroy(gameObject, lifeTime); // Distruggi il proiettile dopo `lifeTime` secondi
    }

    void Update()
    {
        // Muovi il proiettile in avanti
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Controlla se il proiettile colpisce il player
        {
            PlayerA player = collision.GetComponent<PlayerA>();
            if (player != null)
            {
                player.TakeDamage(1); // Infliggi danno al player
            }
            Destroy(gameObject); // Distruggi il proiettile dopo l'impatto
        }
    }
}

