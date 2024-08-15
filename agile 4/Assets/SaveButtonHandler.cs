using UnityEngine;
using UnityEngine.UI;

public class SaveButtonHandler : MonoBehaviour
{
    public Button saveButton;

    private void Start()
    {
        if (saveButton != null)
        {
            saveButton.onClick.AddListener(OnSaveButtonClick);
        }
    }

    private void OnSaveButtonClick()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SaveGame();
        }
        else
        {
            Debug.LogWarning("GameManager instance is not found.");
        }
    }
}
