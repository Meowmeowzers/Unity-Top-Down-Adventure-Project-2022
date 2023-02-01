using UnityEngine;

public class UINavigate : MonoBehaviour
{
    [SerializeField] GameObject enableUI;
    [SerializeField] GameObject currentUI;

    public void Navigate()
    {
        currentUI.SetActive(false);
        enableUI.SetActive(true);
    }
}
