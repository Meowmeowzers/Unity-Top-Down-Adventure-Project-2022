using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public static GameManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("GameManager Instance Destroyed");
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    [SerializeField] private GameObject player;

    public GameObject Player
    { get { return player; } set { player = value; } }

    [SerializeField] private GameObject pauseMenu;

    public GameObject PauseMenu
    { get { return pauseMenu; } }

    [SerializeField] private GameObject gameControlsMenu;
    [SerializeField] private GameObject textPanelUI;
    [SerializeField] private GameObject messagePanelUI;
    [SerializeField] private GameObject bookPanelUI;
    [SerializeField] private GameObject startPortalPanelUI;
    [SerializeField] private GameObject systemCamera;
    [SerializeField] private GameObject gameState;
    [SerializeField] private GameObject quizPanelUI;

    public GameObject GameControlsMenu
    { get { return gameControlsMenu; } }

    public GameObject SystemCamera
    { get { return systemCamera; } }

    [SerializeField] private UI ui;

    public GameObject Ui
    { get { return ui.gameObject; } }

    [SerializeField] private AudioManager audioManager;
    public static Vector2 checkpointTransform;
    public static bool isPaused;
    public bool newGame = true;

    private static Vector2 playerTransform;

    public Vector2 PlayerTransform
    { get { return playerTransform; } set { playerTransform = value; } }

    private Vector2 travelToTransform = new(0f, 0f);

    public Vector2 TravelToTransform
    { get { return travelToTransform; } set { travelToTransform = value; } }

    public void RespawnPlayer()
    {
        Invoke(nameof(RespawnLogic), 5);
    }

    private void RespawnLogic()
    {
        //player.GetComponent<PlayerStats>().Respawn(checkpointTransform);

        // This code is from StartGame.cs, this is to instantly load the save state. Im too lazy so i just copied it.
        Instance.gameObject.SetActive(true);
        Instance.newGame = false;
        gameState.GetComponent<CurrentGameState>().LoadGameSession(SaveAndLoadSystem.saveSlot);
        SceneManager.LoadScene(gameState.GetComponent<CurrentGameState>().currentScene);
        Debug.Log("Loaded Scene, initialize loaded game");
    }

    public static void PauseGame()
    {
        isPaused = true;
        Instance.pauseMenu.SetActive(true);
        Instance.gameControlsMenu.SetActive(false);
        Time.timeScale = 0;
    }

    public static void ResumeGame()
    {
        isPaused = false;
        Instance.pauseMenu.SetActive(false);
        Instance.gameControlsMenu.SetActive(true);
        Time.timeScale = 1;
    }

    public static void ShowTextPanel(string text)
    {
        Instance.gameControlsMenu.SetActive(false);
        Instance.textPanelUI.SetActive(true);
        Instance.textPanelUI.GetComponent<TextPanel>().ShowTextPanel(text);
        Time.timeScale = 0;
    }

    public static void HideTextPanel()
    {
        Instance.gameControlsMenu.SetActive(true);
        Instance.textPanelUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowMessagePanel(string text)
    {
        gameControlsMenu.SetActive(false);
        messagePanelUI.SetActive(true);
        messagePanelUI.GetComponent<MessagePanel>().ShowMessagePanel(text);
    }

    public void HideMessagePanel()
    {
        gameControlsMenu.SetActive(true);
        messagePanelUI.SetActive(false);
    }

    public static void ShowGameControlsUI()
    {
        Instance.gameControlsMenu.SetActive(true);
    }

    public static void HideGameControlsUI()
    {
        Instance.gameControlsMenu.SetActive(false);
    }

    public void ShowBookPanel()
    {
        bookPanelUI.SetActive(true);
        gameControlsMenu.SetActive(false);
        Time.timeScale = 0;
    }

    public void HideBookPanel()
    {
        bookPanelUI.SetActive(false);
        gameControlsMenu.SetActive(true);
        Time.timeScale = 1;
    }

    public static void ChangeContentBookPanel(string textTitle, string textContent, uint currentPageNumber)
    {
        Instance.bookPanelUI.GetComponent<BookMenu>().ChangeTitle(textTitle);
        Instance.bookPanelUI.GetComponent<BookMenu>().ChangeContent(textContent);
        Instance.bookPanelUI.GetComponent<BookMenu>().ChangePage((int)currentPageNumber);
    }

    public static void TravelToNewSceneData(Vector2 transform, string sceneName)
    {
        Instance.TravelToTransform = transform;
        SceneManager.LoadScene(sceneName);
    }

    public static void ShowStartPortalPanel()
    {
        Instance.gameControlsMenu.SetActive(false);
        Instance.startPortalPanelUI.GetComponent<StartPortalUI>().OpenUI();
    }

    public static void HideStartPortalPanel()
    {
        Instance.gameControlsMenu.SetActive(true);
        //startPortalPanelUI.SetActive(false);
    }

    public void ShowQuizPanel()
    {
        quizPanelUI.SetActive(true);
        gameControlsMenu.SetActive(false);
    }

    public void HideQuizPanel()
    {
        quizPanelUI.SetActive(false);
        gameControlsMenu.SetActive(true);
    }
    public void MovePlayer(Vector2 playerPosition)
    {
        Player.transform.position = playerPosition;
    }

    public Transform FindPlayer()
    {
        return FindObjectOfType<PlayerStats>().gameObject.transform;
    }

    public GameObject FindPlayerObject()
    {
        Player = FindObjectOfType<PlayerStats>().gameObject;
        return FindObjectOfType<PlayerStats>().gameObject;
    }

    public static void IsNewGame(bool value)
    {
        Instance.newGame = value;
    }
}

/*
    pauseMenu = ui.PauseMenu;
        gameControlsMenu = ui.GameControlsMenu;
        textPanelUI = ui.TextPanelUI;
        messagePanelUI = ui.MessagePanelUI;
        bookPanelUI = ui.BookPanelUI;
        startPortalPanelUI = ui.StartPortalPanelUI;

 if (Player == null)
        {
            Player = FindObjectOfType<PlayerStats>().gameObject;
            //playerTransform = Player.transform.position;
        }
        if (pauseMenu == null || gameControlsMenu == null || bookPanelUI == null || textPanelUI == null || messagePanelUI == null)
        {
            pauseMenu = ui.PauseMenu;
            gameControlsMenu = ui.GameControlsMenu;
            textPanelUI = ui.TextPanelUI;
            messagePanelUI = ui.MessagePanelUI;
            bookPanelUI = ui.BookPanelUI;
        }

if (pauseMenu == null || gameControlsMenu == null || bookPanelUI == null || textPanelUI == null || messagePanelUI == null)
        {
            audioManager = AudioManager.Instance;
            ui = UI.Instance;
            pauseMenu = ui.PauseMenu;
            gameControlsMenu = ui.GameControlsMenu;
            textPanelUI = ui.TextPanelUI;
            messagePanelUI = ui.MessagePanelUI;
            bookPanelUI = ui.BookPanelUI;
        }
*/