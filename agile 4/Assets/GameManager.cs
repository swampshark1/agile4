using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public SaveData currentSaveData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Save the current game state
    public void SaveGame()
    {
        if (Player.Instance != null)
        {
            SaveData data = new SaveData
            {
                currentLevel = SceneManager.GetActiveScene().name,
                playerPositionX = Player.Instance.transform.position.x,
                playerPositionY = Player.Instance.transform.position.y,
                playerPositionZ = Player.Instance.transform.position.z
            };

            SaveSystem.SaveGame(data);
        }
        else
        {
            Debug.LogWarning("Player.Instance is not set.");
        }
    }

    // Load the saved game state
    public void LoadGame()
    {
        currentSaveData = SaveSystem.LoadGame();
        if (currentSaveData != null)
        {
            if (!string.IsNullOrEmpty(currentSaveData.currentLevel))
            {
                SceneManager.LoadScene(currentSaveData.currentLevel);
            }
            else
            {
                Debug.LogWarning("Invalid scene name in save data.");
            }
        }
        else
        {
            Debug.LogWarning("No save data found.");
        }
    }

    // Called when a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (currentSaveData != null)
        {
            if (Player.Instance != null)
            {
                Vector3 playerPosition = new Vector3(currentSaveData.playerPositionX, currentSaveData.playerPositionY, currentSaveData.playerPositionZ);
                Player.Instance.transform.position = playerPosition;
            }
            else
            {
                Debug.LogWarning("Player.Instance is not set.");
            }
        }
        else
        {
            Debug.LogWarning("currentSaveData is null.");
        }
    }
}
