using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Logica per far perdere tutte le vite al personaggio
            PlayerA player = other.GetComponent<PlayerA>();
            if (player != null)
            {
                player.MaxHealth = 0; // Riduce le vite a zero
                player.TakeDamage(1); // Chiama il metodo per aggiornare la salute del player e farlo morire
            }
        }
    }
}
