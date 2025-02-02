using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public float health;

    public void loseHealth(int value){
        if(health<=0){
            return;
        }
        health -= value;
        fillBar.fillAmount = health / 100;

        if(health<=0){

        }



    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            loseHealth(25);
        }
        

    }
}


    

