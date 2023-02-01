using UnityEngine;

public class SceneInitialize : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private CurrentGameState gameState;
#pragma warning disable IDE0052 // Remove unread private members
    [SerializeField] private bool isDone = false;
#pragma warning restore IDE0052 // Remove unread private members
    [SerializeField] private bool isFinalQuiz = false;

    private StoredSessionData data;

    private void Start()
    {
        gameState = MainSystem.Instance.gameState.GetComponent<CurrentGameState>();
        MainSystem.Instance.ui.SetActive(true);
        MainSystem.Instance.systemCamera.SetActive(true);
        GameManager.Instance.gameObject.SetActive(true);

        if (isFinalQuiz)
        {
            GameManager.Instance.ShowQuizPanel();
            GameManager.HideGameControlsUI();
            AudioManager.Instance.PlayMusic(5);
        }
        else if (GameManager.Instance.newGame)
        {
            player = GameManager.Instance.FindPlayerObject();
            player.transform.position = new Vector2(-31.5f, -29);
            GameTime.TimeValue = 0f;

            GameManager.Instance.newGame = false;
            gameState.scrollData.ResetData();

            GameManager.ShowGameControlsUI();
            AudioManager.Instance.PlayMusic(1);
        }
        else if (!GameManager.Instance.newGame)
        {
            data = SaveAndLoadSystem.LoadGameData(SaveAndLoadSystem.saveSlot);
            player = GameManager.Instance.FindPlayerObject();
            player.transform.position = new Vector2(data.playerTransform[0], data.playerTransform[1]);
            player.GetComponent<PlayerStats>().ObjectHP = data.playerHP;
            GameTime.TimeValue = data.gameTime;

            // Set main book data from loaded state
            gameState.scrollData.InitData(data.isScrollDataUnlocked);

            GameManager.ShowGameControlsUI();
            AudioManager.Instance.PlayMusic(1);
        }


        GameTime.isActive = true;
        isDone = true;
    }
}