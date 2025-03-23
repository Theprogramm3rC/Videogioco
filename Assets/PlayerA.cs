using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = System.Random;

public class PlayerA : MonoBehaviour
{
    public int MaxHealth = 3;
    public Text Health;
    public Animator animator;
    public Rigidbody2D rb;
    public float jumpHeight = 5f;
    public bool isGround = true;
    private float movement;
    public float moveSpeed = 5f;
    private bool facingRight = true;

    public Transform attackPoint;
    public float attackRadius = 1f;
    public LayerMask attackLayer;
   
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Transform feetPoint;
    [SerializeField] private Image[] hearts;

    

    public GameOverManager gameOverManager; // Aggiungi questa riga

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (MaxHealth <= 0)
        {
            Die();
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < MaxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        movement = Input.GetAxis("Horizontal");

        if (movement < 0f && facingRight)
        {
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
            facingRight = false;
        }
        else if (movement > 0f && facingRight == false)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            facingRight = true;
        }

        if (Input.GetKey(KeyCode.Space) && isGround)
        {
            Jump();
            isGround = false;
            animator.SetBool("Jump", true);
        }

        if (Mathf.Abs(movement) > .1f)
        {
            animator.SetFloat("Run", 1f);
        }
        else if (movement < .1f)
        {
            animator.SetFloat("Run", 0f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }

    

    private void FixedUpdate()
    {
        transform.position += new Vector3(movement, 0f, 0f) * Time.fixedDeltaTime * moveSpeed;
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            animator.SetBool("Jump", false);
        }

    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Heart")
        {
            if (MaxHealth >= 4)
            {
                return;
            }
            else
            {
                MaxHealth += 1;
                other.gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("HeartFadeout");
                Destroy(other.gameObject, 1f);
            }
        }

        if (other.gameObject.tag == "VictoryPoint")
        {
            FindAnyObjectByType<SceneManagement>().LoadLevel();
        }
    }

    public void Attack()
    {
        Collider2D collInfo = Physics2D.OverlapCircle(attackPoint.position, attackRadius, attackLayer);
        if (collInfo)
        {
            if (collInfo.gameObject.GetComponent<Android>() != null)
            {
                collInfo.gameObject.GetComponent<Android>().TakeDamage(1);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    public void TakeDamage(int damage)
    {
        if (MaxHealth <= 0)
        {
            return;
        }
        MaxHealth -= damage;
    }

    



    void Die()
    {
        FindAnyObjectByType<GameManager>().isGameActive = false;

        Instantiate(explosionPrefab, feetPoint.position, Quaternion.identity);

        // Chiamare la funzione ShowGameOver del GameOverManager
        gameOverManager.ShowGameOver();

        Destroy(this.gameObject);
    }

    


}
