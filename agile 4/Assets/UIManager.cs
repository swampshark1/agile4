using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Method to be called by the save button in the pause menu
    public void OnSaveButtonClicked()
    {
        GameManager.Instance.SaveGame();
    }

    // Method to be called by the load button in the main menu
    public void OnLoadButtonClicked()
    {
        GameManager.Instance.LoadGame();
    }

    // Method to quit to the main menu
    public void OnQuitToMainMenu()
    {
        // Optionally save the game state before quitting
        GameManager.Instance.SaveGame();

        // Load the main menu scene
        SceneManager.LoadScene("MainMenu");
    }

    // Method to start a new game and load Level 1
    public void OnPlayButtonClicked()
    {
        // Clear any existing save data (optional)
        GameManager.Instance.currentSaveData = null;

        // Load Level 1
        SceneManager.LoadScene("Level1");
    }
}
