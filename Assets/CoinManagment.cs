using UnityEngine;
using UnityEngine.UI;

public class CoinManagment :MonoBehaviour
{
   public int CoinCount;
   public Text coinText;
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text=CoinCount.ToString();
        
        
    }
}
