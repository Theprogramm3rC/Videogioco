using UnityEngine;
using UnityEngine.UI;

public class Coinmanager3 : MonoBehaviour
{
    public int coinCount;
    public Text coinText;

    public GameObject door;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Robot Parts: " + coinCount.ToString();

        if(coinCount == 5){
            Destroy(door);

        }
        
    }
}
