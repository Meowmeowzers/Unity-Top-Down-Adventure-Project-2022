using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    //Singleton Pattern
    //Prevents Game Object from having more than one instance
    //Also Not Destroyed on Load

    private static DontDestroyOnLoad instance = null;

    public static DontDestroyOnLoad Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}