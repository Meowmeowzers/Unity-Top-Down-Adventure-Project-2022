using UnityEngine;

public class MainMenuTransitions : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject gameSelectionScreen;
    [SerializeField] private GameObject newGameScreen;
    [SerializeField] private GameObject newGameSelectSlot;
    [SerializeField] private GameObject newGameSelectSlot2;
    [SerializeField] private GameObject loadGameScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject creditsScreen;

    public void DisableTitleScreen()
    {
        titleScreen.SetActive(false);
    }

    public void EnableTitleScreen()
    {
        titleScreen.SetActive(true);
    }

    public void DisableGameSelectionScreen()
    {
        gameSelectionScreen.SetActive(false);
    }

    public void EnableGameSelectionScreen()
    {
        gameSelectionScreen.SetActive(true);
    }

    public void EnableNewGameScreen()
    {
        newGameScreen.SetActive(true);
    }

    public void DisableNewGameScreen()
    {
        newGameScreen.SetActive(false);
    }

    public void EnableNewGameSelectSlot()
    {
        newGameSelectSlot.SetActive(true);
    }

    public void DisableNewGameSelectSlot()
    {
        newGameSelectSlot.SetActive(false);
    }

    public void EnableNewGameSelectSlot2()
    {
        newGameSelectSlot2.SetActive(true);
    }

    public void DisableNewGameSelectSlot2()
    {
        newGameSelectSlot2.SetActive(false);
    }

    public void DisableLoadGameScreen()
    {
        loadGameScreen.SetActive(false);
    }

    public void EnableLoadGameScreen()
    {
        loadGameScreen.SetActive(true);
    }
	public void DisableSettingsScreen()
    {
        settingsScreen.SetActive(false);
    }

    public void EnableSettingsScreen()
    {
        settingsScreen.SetActive(true);
    }
    public void DisableCreditsScreen()
    {
        creditsScreen.SetActive(false);
    }

    public void EnableCreditsScreen()
    {
        creditsScreen.SetActive(true);
    }
}