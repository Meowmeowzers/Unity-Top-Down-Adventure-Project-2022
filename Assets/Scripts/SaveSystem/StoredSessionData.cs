[System.Serializable]
public class StoredSessionData
{
    public float playerHP;
    public float[] playerTransform = new float[3];

    public string scene;
    public float gameTime;

    public bool[] isScrollDataUnlocked;

    public StoredSessionData(CurrentGameState gameState)
    {
        playerHP = gameState.playerHP;
        playerTransform[0] = gameState.playerTransform.x;
        playerTransform[1] = gameState.playerTransform.y;
        scene = gameState.currentScene;
        gameTime = gameState.gameTime;

        isScrollDataUnlocked = new bool[gameState.isScrollDataUnlocked.Length];

        for (int i = 0; i < gameState.isScrollDataUnlocked.Length; i++)
        {
            isScrollDataUnlocked[i] = gameState.isScrollDataUnlocked[i];
        }
    }
}