using TMPro;
using UnityEngine;

public class TextPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tm;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ShowTextPanel(string message)
    {
        tm.text = message;
    }

    public void HideTextPanel()
    {
        this.gameObject.SetActive(false);
        GameManager.HideTextPanel();
    }
}