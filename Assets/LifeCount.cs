using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemainig;

    public void LoseLife(){

        if(livesRemainig==0){
            return;
        }
        livesRemainig--;

        lives[livesRemainig].enabled = false;

        if(livesRemainig==0){
            Debug.Log("you lost");
        }
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            LoseLife();
        }
    }

 



    
}
