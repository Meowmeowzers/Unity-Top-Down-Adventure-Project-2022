using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentGameState : MonoBehaviour
{
    private StoredSessionData data;
    public ScrollMainData scrollData;

    public float playerHP;
    public Vector2 playerTransform;
    public string currentScene;
     
    public float gameTime;
                      
    public bool[] isScrollDataUnlocked;

    private void Awake()
    {
        isScrollDataUnlocked = new bool[scrollData.MaxPageNumber];
    }

    private void GetBookData()
    { 
        for(int i = 0; i < isScrollDataUnlocked.Length; i++)
        {
            isScrollDataUnlocked[i] = scrollData.scrolls[i].isUnlocked;
        }
    }

    public void GetAllCurrentData()
    {
        playerHP = FindObjectOfType<PlayerStats>().ObjectHP;
        //playerTransform.x = FindObjectOfType<PlayerStats>().transform.position.x;
        //playerTransform.y = FindObjectOfType<PlayerStats>().transform.position.y;
        currentScene = SceneManager.GetActiveScene().name;
        gameTime = GameTime.TimeValue;
        GetBookData();
    }

    public void SaveCurrentGameState()
    {
        //GetCurrentData();
        SaveAndLoadSystem.SaveGameData(this);
        //Debug.Log("leo - Save and load system, save");
    }

    public void LoadGameSession(int slot)
    {
        //Debug.Log("Leo - Load game session");

        data = SaveAndLoadSystem.LoadGameData(slot);

        if (data != null)
        {
            playerHP = data.playerHP;
            playerTransform.x = data.playerTransform[0];
            playerTransform.y = data.playerTransform[1];
            currentScene = data.scene;
            gameTime = data.gameTime;

            for (int i = 0; i < scrollData.MaxPageNumber; i++)
            {
                isScrollDataUnlocked[i] = data.isScrollDataUnlocked[i];
            }
        }

        //Debug.Log("Leo - " + playerTransform);
        //Debug.Log("Leo - " + playerHP);
        //Debug.Log("Leo - " + gameTime);
    }
}