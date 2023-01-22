using UnityEngine;

public class NPCChat : MonoBehaviour
{
    private GameManager gameManager;
    private bool isActive = false;
    [SerializeField] public string text = "Hello World";

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerStats>() != null && !isActive)
        {
            isActive = true;
            gameManager.ShowMessagePanel(text);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerStats>() != null && isActive)
        {
            isActive = false;
            gameManager.HideMessagePanel();
        }
    }
}