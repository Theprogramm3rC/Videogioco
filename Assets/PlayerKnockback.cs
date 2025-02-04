using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    public Animator animatori;
    public float knockbackForce = 10f; // Forza del knockback
    public float knockbackDuration = 0.2f; // Durata del knockback

    private Rigidbody2D rb;
    private bool isKnockedback;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ApplyKnockback(Vector2 direction)
    {
        if (!isKnockedback)
        {
            isKnockedback = true;
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(-direction * knockbackForce, ForceMode2D.Impulse);
            Invoke("EndKnockback", knockbackDuration);
        }
    }

    void EndKnockback()
    {
        animatori.SetTrigger("Knockback");
        isKnockedback = false;
        

    }
}