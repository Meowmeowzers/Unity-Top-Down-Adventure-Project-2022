using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowShortSavedData : MonoBehaviour
{
    [SerializeField] private int saveSlot;
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private TextMeshProUGUI scene;
    [SerializeField] private bool isLoadButton = false;
    private StoredSessionData storedSessionData;

    private void Start()
    {
        storedSessionData = SaveAndLoadSystem.LoadGameData(saveSlot);
        if (storedSessionData != null)
        {
            time.text = storedSessionData.gameTime.ToString();
            scene.text = storedSessionData.scene.ToString();
            Debug.Log(storedSessionData.gameTime);
            Debug.Log(storedSessionData.scene);
        }
        else
        {
            if (isLoadButton)
            {
                this.GetComponent<Button>().interactable = false;
            }
        }
    }
}