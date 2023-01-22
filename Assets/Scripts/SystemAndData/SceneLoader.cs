using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void LoadScene(string sceneName)
    {
        GameTime.isActive = false;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Scene loaded, scene loader");
    }
}