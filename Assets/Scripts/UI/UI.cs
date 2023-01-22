using Unity.VisualScripting;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI instance;
    public static UI Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] private GameObject pauseMenu;
    public GameObject PauseMenu
    { get { return Instance.pauseMenu; } }

    [SerializeField] private GameObject gameControlsMenu;

    public GameObject GameControlsMenu
    { get { return this.gameControlsMenu; } }

    [SerializeField] private GameObject textPanelUI;

    public GameObject TextPanelUI
    { get { return this.textPanelUI; } }

    [SerializeField] private GameObject messagePanelUI;

    public GameObject MessagePanelUI
    { get { return this.messagePanelUI; } }

    [SerializeField] private GameObject bookPanelUI;

    public GameObject BookPanelUI
    { get { return this.bookPanelUI; } }

    [SerializeField] private GameObject startPortalPanelUI;

    public GameObject StartPortalPanelUI
    { get { return this.startPortalPanelUI; } }

    [SerializeField] private GameObject quizPanelUI;

    public GameObject QuizPanelUI
    { get { return this.quizPanelUI; } }
}