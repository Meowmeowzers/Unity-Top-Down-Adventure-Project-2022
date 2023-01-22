using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeGame : MonoBehaviour
{
    private CurrentGameState gameState;
    private GameTime gameTime;
    private GameObject player;
    private bool isDone = false;
    [SerializeField] private bool isMainMenu = false;

    private void Start()
    {
        if (isMainMenu)
        {
            gameObject.SetActive(false);
        }
        else if (!isMainMenu)
        {
            gameState = FindObjectOfType<CurrentGameState>();
            gameTime = FindObjectOfType<GameTime>();
            player = FindObjectOfType<PlayerStats>().gameObject;
            Debug.Log(gameState + " " + gameTime + " " + player);
        }
    }

    private void Update()
    {
        if ((player == null) && !isMainMenu)
        {
            player = FindObjectOfType<PlayerStats>().gameObject;
            Debug.LogError("Leo - Attempted to find missing references, initialize game");
        }
    }

    private IEnumerator SetPlayerState(float time)
    {
        Debug.LogError("Leo - Setting up player state");
        Debug.Log(player.GetComponent<PlayerStats>().ObjectHP);
        Debug.Log(player.transform.position);
        if (!isDone && gameState != null)
        {
            player.transform.position = gameState.playerTransform;
            Debug.Log("modifying player hp by " + gameState.playerHP);
            player.GetComponent<PlayerStats>().ObjectHP = gameState.playerHP;
            GameTime.TimeValue = gameState.gameTime;
            isDone = true;
            Debug.Log("Leo - player transform " + gameState.playerTransform);
            Debug.Log("Leo - player hp " + gameState.playerHP);
            Debug.Log("Leo - game time " + gameState.gameTime);
        }
        Debug.Log(player.GetComponent<PlayerStats>().ObjectHP);
        Debug.Log(player.transform.position);
        Debug.LogError("leo - Done setting up player state");

        yield return new WaitForSeconds(time);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!isMainMenu)
        {
            Debug.LogError("Initialize Game");
            gameState = FindObjectOfType<CurrentGameState>();
            gameTime = FindObjectOfType<GameTime>();
            player = FindObjectOfType<PlayerStats>().gameObject;
            StartCoroutine(SetPlayerState(0f));
        }
    }
}