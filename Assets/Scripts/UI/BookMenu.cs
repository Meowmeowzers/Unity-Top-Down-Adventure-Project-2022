using TMPro;
using UnityEngine;

public class BookMenu : MonoBehaviour
{
    private GameManager gameManager;
    private ScrollMainData scrollsData;

    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI content;
    [SerializeField] private TextMeshProUGUI page;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        scrollsData = FindObjectOfType<ScrollMainData>();
    }

    public void Close()
    {
        //Debug.Log("Closed");
        gameManager.HideBookPanel();
    }

    public void Next()
    {
        //Debug.Log("Next");
        scrollsData.NextPage();
    }

    public void Prev()
    {
        //Debug.Log("Prev");
        scrollsData.PrevPage();
    }

    public void ChangeTitle(string text)
    {
        title.text = text;
    }

    public void ChangeContent(string text)
    {
        content.text = text;
    }

    public void ChangePage(int text)
    {
        page.text = text.ToString() + " / " + (scrollsData.MaxPageNumber - 1);
    }
}