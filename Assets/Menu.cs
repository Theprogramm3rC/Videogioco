using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void PlayGame(){
           SceneManager.LoadScene(1);
    }  
    
    public void Settings(){
              
    }

    public void Exit(){
              SceneManager.LoadScene(1);        
    }

    public void DescriptionF(){
           SceneManager.LoadScene(2);
    }  

    public void DescriptionA(){
           SceneManager.LoadScene(3);
    }
    public void DescriptionL(){
           SceneManager.LoadScene(4);
    }

       public void DescriptionG(){
           SceneManager.LoadScene(5);
    }

    public void Inizia(){
              SceneManager.LoadScene(6);          
    }  
}
