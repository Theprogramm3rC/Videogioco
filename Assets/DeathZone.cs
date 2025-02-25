using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Logica per la morte del personaggio
            Destroy(other.gameObject);
            // Puoi aggiungere altre azioni, come ricaricare la scena o mostrare un messaggio di Game Over
        }
    }
}