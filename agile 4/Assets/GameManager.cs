using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public string saveFileName = "savefile.json";
    private string currentSceneName;

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

    public void SaveGame()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            PlayerDatas playerData = new PlayerDatas(player.transform.position, player.transform.rotation, SceneManager.GetActiveScene().name);
            string json = JsonConvert.SerializeObject(playerData, Formatting.Indented);
            File.WriteAllText(GetSaveFilePath(), json);
            Debug.Log("Game saved: " + json);
        }
    }

    public void LoadGame()
    {
        if (File.Exists(GetSaveFilePath()))
        {
            string json = File.ReadAllText(GetSaveFilePath());
            PlayerDatas playerData = JsonConvert.DeserializeObject<PlayerDatas>(json);
            if (playerData != null)
            {
                Vector3 playerPosition = playerData.position.ToVector3();
                Quaternion playerRotation = playerData.rotation.ToQuaternion();
                GameObject player = GameObject.Find("Player");
                if (player != null)
                {
                    player.transform.position = playerPosition;
                    player.transform.rotation = playerRotation;
                    currentSceneName = playerData.currentMap; // Save the current map name
                    Debug.Log("Game loaded: Player position = " + playerPosition + ", rotation = " + playerRotation);
                }
                else
                {
                    Debug.LogWarning("Player GameObject not found during load.");
                }
            }
            else
            {
                Debug.LogWarning("Failed to deserialize PlayerDatas.");
            }
        }
        else
        {
            Debug.LogWarning("No save file found.");
        }
    }

    public string GetCurrentSceneName()
    {
        return currentSceneName;
    }

    private string GetSaveFilePath()
    {
        return Path.Combine(Application.persistentDataPath, saveFileName);
    }
}
