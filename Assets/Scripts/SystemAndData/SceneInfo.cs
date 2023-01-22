using UnityEngine;

public class SceneInfo : MonoBehaviour
{
    //public enum SceneInfoEnum { s , f};
    [SerializeField] private AudioClip mainMusic;

    [SerializeField] private bool isMainMenu = false;

    private GameManager gameManager;

    private bool isRead = false;

    private void Start()
    {
        if (!isMainMenu)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }

    private void Update()
    {
        if (gameManager == null && !isMainMenu)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
        if (!isRead && !isMainMenu)
        {
            StartScene();
        }
    }

    private void StartScene()
    {
        GameManager.ShowGameControlsUI();
        isRead = true;
    }
}