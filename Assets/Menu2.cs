using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void descriptionF() {
        SceneManager.LoadScene(2);
    }
    
    public void descriptionA() {
        SceneManager.LoadScene(3);
    }

    public void descriptionL() {
        SceneManager.LoadScene(4);        
    }

    public void descriptionG() {
        SceneManager.LoadScene(5);        
    }
}
