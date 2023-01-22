using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject systemCamera;
    [SerializeField] private GameObject ui;
    [SerializeField] private GameTime gameTime;
    [SerializeField] private CurrentGameState gameState;

    private void Awake()
    {
        gameManager = FindObjectOfType<MainSystem>().gameManager;
        systemCamera = FindObjectOfType<MainSystem>().systemCamera;
        ui = FindObjectOfType<MainSystem>().ui;
        gameTime = FindObjectOfType<GameTime>();
        gameState = FindObjectOfType<CurrentGameState>();
    }

    private void Update()
    {
        if (gameManager == null || systemCamera == null || ui == null || gameTime == null || gameState == null)
        {
            gameManager = FindObjectOfType<MainSystem>().gameManager;
            systemCamera = FindObjectOfType<MainSystem>().systemCamera;
            ui = FindObjectOfType<MainSystem>().ui;
            gameTime = FindObjectOfType<GameTime>();
            gameState = FindObjectOfType<CurrentGameState>();
            Debug.Log("Attempted to find missing references, start game");
        }
    }

    public void InitializeLoadedGame()
    {
        GameManager.Instance.gameObject.SetActive(true);
        GameManager.Instance.newGame = false;
        gameState.LoadGameSession(SaveAndLoadSystem.saveSlot);
        SceneManager.LoadScene(gameState.currentScene);
        Debug.Log("Loaded Scene, initialize loaded game");
    }
}