using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement7 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LoadLevel();
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(10);
    }
}

