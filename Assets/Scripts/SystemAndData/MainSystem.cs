using UnityEngine;

public class MainSystem : MonoBehaviour
{
    //Singleton Pattern
    //Prevents Game Object from having more than one instance
    //Also Not Destroyed on Load

    private static MainSystem instance = null;

    public static MainSystem Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("Instance Destroyed");
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public GameObject gameManager;
    public GameObject systemCamera;
    public GameObject ui;
    public GameObject gameState;
}