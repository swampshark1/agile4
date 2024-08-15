using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button startNewGameButton;
    public Button saveGameButton;
    public Button loadGameButton;

    private void Start()
    {
        if (startNewGameButton != null)
        {
            startNewGameButton.onClick.AddListener(StartNewGame);
        }

        if (saveGameButton != null)
        {
            saveGameButton.onClick.AddListener(SaveGame);
        }

        if (loadGameButton != null)
        {
            loadGameButton.onClick.AddListener(LoadGame);
        }
    }

    public void StartNewGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartNewGame();
        }
        else
        {
            Debug.LogWarning("GameManager instance is not found.");
        }
    }

    private void SaveGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SaveGame();
            Debug.Log("Game saved successfully.");
        }
        else
        {
            Debug.LogWarning("GameManager instance is not found.");
        }
    }

    private void LoadGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoadGame();
            Debug.Log("Game loaded successfully.");
        }
        else
        {
            Debug.LogWarning("GameManager instance is not found.");
        }
    }
}
