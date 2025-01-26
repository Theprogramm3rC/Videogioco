using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Android : MonoBehaviour
{
    
    public bool facingleft = true;
    public float moveSpeed = 2f;
    public Transform checkPoint;
    public float distance = 1f;
    public LayerMask layerMask;
    public bool inRange = false;
    public Transform player;
    public float attackRange = 10f;
    public float retrieveDistance = 2.5f;
    public float chaseSpeed = 4f;
    public Animator animator;
    
    public Transform AttackPoint;
    public float attackRadius = 1f;
    public LayerMask attackLayer;


    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) <= attackRange ){
            inRange = true;
        }

        else{
            inRange = false;
        }
        if(inRange){
            if(player.position.x > transform.position.x && facingleft == true){
                transform.eulerAngles = new Vector3(0, -180, 0);
                facingleft = false;
            }
            else if(player.position.x < transform.position.x && facingleft == false){
                transform.eulerAngles = new Vector3(0, 0,0);
                facingleft = true;
            }



            if(Vector2.Distance(transform.position, player.position) > retrieveDistance){
                animator.SetBool("Attack 1", false);
                transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime );

            }
            else{
                animator.SetBool("Attack 1", true);


            }


        }
        else {
            transform.Translate(Vector2.left* Time.deltaTime * moveSpeed);

            RaycastHit2D hit = Physics2D.Raycast(checkPoint.position, Vector2.down, distance, layerMask);

            if(hit == false && facingleft){
               transform.eulerAngles = new Vector3(0, -180, 0);
               facingleft = false;

            
            }
            else if(hit == false && facingleft == false){
                transform.eulerAngles = new Vector3(0, 0, 0);
                facingleft = true;

            }
        }

            
    }


    public void Attack(){

        Collider2D collInfo = Physics2D.OverlapCircle(AttackPoint.position, attackRadius, attackLayer);
        if(collInfo){
            if( collInfo.gameObject.GetComponent<PlayerA>() != null){
                collInfo.gameObject.GetComponent<PlayerA>().TakeDamage(1);
            }
        }
    }



      
    

    private void OnDrawGizmosSelected(){
        if(checkPoint == null){
            return;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(checkPoint.position, Vector2.down * distance);
        
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, attackRange);

        if(AttackPoint == null) return;
        Gizmos.color= Color.red;
        Gizmos.DrawWireSphere(AttackPoint.position, attackRadius);
    }
    
}

