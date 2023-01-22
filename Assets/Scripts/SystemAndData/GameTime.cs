using UnityEngine;

public class GameTime : MonoBehaviour
{
    private static GameTime instance;
    public static GameTime Instance
    { get { return instance; } }

    [SerializeField] private static float gameTime = 0f;
    public static float TimeValue
    { get { return gameTime; } set { gameTime = value; } }

    [SerializeField] public static bool isActive = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (isActive)
        {
            gameTime += Time.deltaTime;
        }
    }

    public static void StartTime(bool value)
    {
        isActive = value;
        Debug.Log(value + " " + isActive);
    }

    public static void LogTime(bool value)
    {
        isActive = value;
        if (isActive)
        {
            Debug.Log(gameTime);
        }
    }
}