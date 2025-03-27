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
           SceneManager.LoadScene(3);
    }  

    public void DescriptionA(){
           SceneManager.LoadScene(2);
    }
    public void DescriptionL(){
           SceneManager.LoadScene(5);
    }

       public void DescriptionG(){
           SceneManager.LoadScene(4);
    }

    public void Scena1A(){
              SceneManager.LoadScene(6);          
    }

    public void Scene1F(){
           SceneManager.LoadScene(7);
    }

    public void Scene1L(){
           SceneManager.LoadScene(9);
    }

    public void Scene1G(){
           SceneManager.LoadScene(8);
    }        
}
