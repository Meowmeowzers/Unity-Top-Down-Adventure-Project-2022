using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public void ResumeButton()
    {
        GameManager.ResumeGame();
    }

    public void PauseButton()
    {
        GameManager.PauseGame();
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        gameManager.PauseMenu.SetActive(false);
        gameManager.SystemCamera.SetActive(false);
        gameManager.GameControlsMenu.SetActive(false);
        gameManager.gameObject.SetActive(false);
        SceneManager.LoadScene("StartScene");
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;
        int index = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log(index);
        gameManager.PauseMenu.SetActive(false);
        gameManager.gameObject.SetActive(true);
        SceneManager.LoadScene(index);
    }
}

/*
  [SerializeField] private GameObject uiEnable;
    [SerializeField] private GameObject uiDisable;

    void OnPause()
    {
        Time.timeScale = 0f;
        uiEnable.SetActive(true);
        uiDisable.SetActive(false);
    }

*/