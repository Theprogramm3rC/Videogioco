using UnityEngine;


public class Coin : MonoBehaviour
{
    public CoinManager cm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Coin")){
            Destroy(other.gameObject);
            cm.coinCount++;

        }
    }
}
