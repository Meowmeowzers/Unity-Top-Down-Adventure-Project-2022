using UnityEngine;

public class BookButton : MonoBehaviour
{
    public void ShowBookPanel()
    {
        GameManager.Instance.ShowBookPanel();
    }

    public void HideBookPanel()
    {
        GameManager.Instance.HideBookPanel();
    }
}