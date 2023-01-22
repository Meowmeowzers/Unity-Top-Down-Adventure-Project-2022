using UnityEngine;

public class Travel : MonoBehaviour
{
    
    [SerializeField] private string sceneNameToLoad;

    public string SceneNameToLoad
    { get { return sceneNameToLoad; } set { sceneNameToLoad = value; } }

    [SerializeField] private PortalCoordinates[] worldTransform = new PortalCoordinates[5];

    private CurrentGameState gameState;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameState = FindObjectOfType<CurrentGameState>();
    }

    private void Update()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }

    public void TravelToScene()
    {
        GameManager.IsNewGame(false);
        //StoredSessionData data = SaveAndLoadSystem.LoadGameData(SaveAndLoadSystem.saveSlot);

        if (sceneNameToLoad == "Area1")
        {
            //GameManager.TravelToNewSceneData(worldTransform[0].position, sceneNameToLoad);
            gameState.playerTransform.x = worldTransform[0].position.x;
            gameState.playerTransform.y = worldTransform[0].position.y;
        }
        else if (sceneNameToLoad == "Area2")
        {
            //GameManager.TravelToNewSceneData(worldTransform[1].position, sceneNameToLoad);
            gameState.playerTransform.x = worldTransform[0].position.x;
            gameState.playerTransform.y = worldTransform[0].position.y;
        }
        else if (sceneNameToLoad == "Area3")
        {
            //GameManager.TravelToNewSceneData(worldTransform[2].position, sceneNameToLoad);
            gameState.playerTransform.x = worldTransform[0].position.x;
            gameState.playerTransform.y = worldTransform[0].position.y;
        }
        else if (sceneNameToLoad == "Area4")
        {
            //GameManager.TravelToNewSceneData(worldTransform[3].position, sceneNameToLoad);
            gameState.playerTransform.x = worldTransform[0].position.x;
            gameState.playerTransform.y = worldTransform[0].position.y;
        }
        else if (sceneNameToLoad == "Area5")
        {
            //GameManager.TravelToNewSceneData(worldTransform[4].position, sceneNameToLoad);
            gameState.playerTransform.x = worldTransform[0].position.x;
            gameState.playerTransform.y = worldTransform[0].position.y;
        }
        else
        {
            Debug.Log("Unknown scene name to load...");
        }
        gameState.GetComponent<CurrentGameState>().GetAllCurrentData();
        gameState.GetComponent<CurrentGameState>().SaveCurrentGameState();
        SceneLoader.LoadScene(sceneNameToLoad);
    }
}