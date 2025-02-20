using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockbackForce = 10f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 difference = transform.position - collision.transform.position;
            difference = difference.normalized * knockbackForce;
            GetComponent<Rigidbody2D>().AddForce(difference, ForceMode2D.Impulse);
        }
    }
}
