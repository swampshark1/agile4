using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        TogglePlayerControls(true);
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        TogglePlayerControls(false);
        isPaused = true;
    }

    public void QuitToMainMenu()
    {
        // Ensure game state is saved or any necessary cleanup is done
        Time.timeScale = 1f; // Resume time in case it's paused
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with your actual main menu scene name
    }

    private void TogglePlayerControls(bool enable)
    {
        var playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = enable;
        }

        var gun = FindObjectOfType<Gun>();
        if (gun != null)
        {
            gun.enabled = enable;
        }

        var enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in enemies)
        {
            enemy.enabled = enable;
        }
    }
}
