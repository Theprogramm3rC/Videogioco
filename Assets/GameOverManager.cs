using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button retryButton;

    void Start()
    {
        // Assicurati che il pannello GameOver sia disattivato all'inizio
        gameOverPanel.SetActive(false);

        // Aggiungi un listener al pulsante Retry
        retryButton.onClick.AddListener(RetryGame);
    }

    // Funzione per mostrare il pannello GameOver
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    // Funzione per ricaricare la scena attuale (Retry)
    void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
