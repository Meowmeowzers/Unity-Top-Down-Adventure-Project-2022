using UnityEngine;

public class StartPortalArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.GetComponent<PlayerStats>())
        {
            GameManager.ShowStartPortalPanel();
        }
    }
}