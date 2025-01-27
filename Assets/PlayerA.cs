using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerA : MonoBehaviour
{
    public int MaxHealth = 3;
    public Text Health;
    public Animator animator;
    public Rigidbody2D rb;
    public float jumpHeight = 5f;
    public bool isGround= true;
    private float movement;
    public float moveSpeed = 5f;
    private bool facingRight = true;

    public Transform attackPoint;
    public float attackRadius = 1f;
    public LayerMask attackLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(MaxHealth <= 0){
            Die();
        }

        Health.text = MaxHealth.ToString();

        movement = Input.GetAxis("Horizontal"); 

        if(movement < 0f && facingRight){
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
            facingRight = false;

        }
        else if(movement > 0f && facingRight == false){
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            facingRight = true;

        }

        if(Input.GetKey(KeyCode.Space) && isGround){
            Jump();
            isGround = false;
            animator.SetBool("Jump", true);
        }

        if(Mathf.Abs(movement) > .1f){
            animator.SetFloat("Run", 1f);
        }
        else if(movement < .1f){
            animator.SetFloat("Run", 0f);
        }

        if(Input.GetMouseButtonDown(0)){
            animator.SetTrigger("Attack");

        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(movement, 0f, 0f) * Time.fixedDeltaTime * moveSpeed;
    }

    void Jump(){
        rb.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground"){
            isGround = true;
            animator.SetBool("Jump", false);
        }
    }


    public void Attack(){
        Collider2D collInfo = Physics2D.OverlapCircle(attackPoint.position, attackRadius, attackLayer);
        if(collInfo){

        }
    }

    void OnDrawGizmosSelected(){
        if(attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);

    }

    public void TakeDamage(int damage){
        if(MaxHealth <= 0){
            return;
        }
        MaxHealth -= damage;
    }

    void Die(){
        Debug.Log("Player Died");
    }
}
