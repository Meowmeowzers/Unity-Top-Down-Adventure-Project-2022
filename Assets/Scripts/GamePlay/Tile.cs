using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isActive = false;
    [SerializeField] private string message = "Hello World";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerStats>() != null && !isActive)
        {
            isActive = true;
            GameManager.ShowTextPanel(message);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerStats>() != null && isActive)
        {
            isActive = false;
            GameManager.HideTextPanel();
        }
    }
}