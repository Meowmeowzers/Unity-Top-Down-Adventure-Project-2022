using TMPro;
using UnityEngine;

public class MessagePanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tm;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ShowMessagePanel(string message)
    {
        tm.text = message;
    }

    public void HideMessagePanel()
    {
        gameManager.HideMessagePanel();
    }
}