using UnityEngine;

// Book class contains data about players progress on collecting the pages/scroll/etc
// Next time change this into something more universal(name, structure, scripttable object)
// Next time change this into scriptable object

public class Book : MonoBehaviour
{
    private GameManager gameManager;
    private string textTitle = "";
    private string textContent = "";

    private const uint minPageNumber = 0;
    private const uint maxPageNumber = 32;
    public uint MaxPageNumber { get { return maxPageNumber; } }
    private uint currentPageNumber = 0;
    public uint CurrentPageNumber { get { return currentPageNumber; }  set { currentPageNumber = value; } }

    //public Content[] contents = new Content[maxPageNumber];
    public ScrollData[] scrolls = new ScrollData[maxPageNumber];

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void DisplayPage()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
        textTitle = scrolls[currentPageNumber].title;
        textContent = scrolls[currentPageNumber].content;
        GameManager.ChangeContentBookPanel(textTitle, textContent, currentPageNumber);
        Debug.Log(currentPageNumber);
    }

    public void NextPage()
    {
        // check if page number is less than max page number before incrementing page number
        if (currentPageNumber < maxPageNumber) currentPageNumber++;

        // check if page number is greater than max page number
        // if page number is greater than max page number, set it back to max page number minus 1 (due to array index)
        if (currentPageNumber >= maxPageNumber) currentPageNumber = maxPageNumber - 1;

        // if page number is unlocked, then display. If not, then iterate through all pages to find next unlocked page
        // if none then do nothing (dont move page)
        if (scrolls[currentPageNumber].isUnlocked)
        {
            DisplayPage();
        }
        else if (!scrolls[currentPageNumber].isUnlocked && currentPageNumber <= 31)
        {
            for (uint i = currentPageNumber; i < maxPageNumber; i++)
            {
                if (scrolls[i].isUnlocked)
                {
                    currentPageNumber = i;
                    DisplayPage();
                    break;
                }
            }
        }
    }

    public void PrevPage()
    {
        // check if page number is less than max page number before incrementing page number
        if (currentPageNumber > minPageNumber) currentPageNumber--;

        // check if page number is greater than max page number
        // if page number is greater than max page number, set it back to max page number minus 1 (due to array index)
        if (currentPageNumber < minPageNumber) currentPageNumber = minPageNumber;

        // if page number is unlocked, then display. If not, then iterate through all pages to find previous unlocked page
        // if none then do nothing (dont move page)
        if (scrolls[currentPageNumber].isUnlocked)
        {
            DisplayPage();
        }
        else if (!scrolls[currentPageNumber].isUnlocked && currentPageNumber <= 31)
        {
            for (uint i = currentPageNumber; i >= 0; i--)
            {
                if (scrolls[i].isUnlocked)
                {
                    currentPageNumber = i;
                    DisplayPage();
                    break;
                }
            }
        }
    }

    public void UnlockBookPage(uint index)
    {
        scrolls[index].isUnlocked = true;
    }

    public void LockBookPage(uint index)
    {
        scrolls[index].isUnlocked = false;
    }

    public void ResetData()
    {
        // Set main book data from loaded data
        for (int i = 1; i < scrolls.Length; i++)
        {
            scrolls[i].isUnlocked = false;
        }
        currentPageNumber = 0;
    }

    public void InitData(bool[] values)
    {
       
        Debug.Log("Leo - Resetting book data");
        for (int i = 0; i < scrolls.Length; i++)
        {
            scrolls[i].isUnlocked = values[i];
            if (scrolls[i].isUnlocked)
            {
                Debug.Log(i);
            }
        }
    }
}

/*
 * 
 public class Content
    {
        public string title;
        public string content;
        public bool isUnlocked = false;

        public Content(string a, string b)
        {
            this.title = a;
            this.content = b;
        }
    }
    private void Awake()
    {
        Content content0 = new("Computer Science Front Page", "This is the front page lol");
        Content content1 = new("Introduction", "Insert Text");
        Content content2 = new("History", "adf");
        Content content3 = new("Topic 3", "adf");
        Content content4 = new("Topic 4", "adf");
        Content content5 = new("Programming", "Insert Text");
        Content content6 = new("Programming", "adf");
        Content content7 = new("Programming", "adf");
        Content content8 = new("Object Oriented Programming", "Insert short related topics...");
        Content content9 = new("Object Oriented Programming", "adf");
        Content content10 = new("Object Oriented Programming", "adf");
        Content content11 = new("Object Oriented Programming", "adf");
        Content content12 = new("Data Structures", "Insert Text");
        Content content13 = new("Data Structures", "adf");
        Content content14 = new("Data Structures", "adf");
        Content content15 = new("Algorithms and Complexities", "adf");
        Content content16 = new("Algorithms and Complexities", "adf");
        Content content17 = new("Architecture and Organization", "adf");
        Content content18 = new("Architecture and Organizations", "adf");
        Content content19 = new("Automata Theory", "adf");
        Content content20 = new("Automata Theory", "adf");
        Content content21 = new("Operating Systems", "adf");
        Content content22 = new("Operating Systems", "adf");
        Content content23 = new("Human Computer Interaction", "adf");
        Content content24 = new("Human Computer Interaction", "adf");
        Content content25 = new("Intelligent Systems", "adf");
        Content content26 = new("Intelligent Systems", "adf");
        Content content27 = new("Computer Graphics", "adf");
        Content content28 = new("Computer Graphics", "Insert Text");
        Content content29 = new("Information Security and Assurance", "adf");
        Content content30 = new("Information Security and Assurance", "adf");
        Content content31 = new("Meow Page", "Insert Text");

        contents[0] = content0;
        contents[1] = content1;
        contents[2] = content2;
        contents[3] = content3;
        contents[4] = content4;
        contents[5] = content5;
        contents[6] = content6;
        contents[7] = content7;
        contents[8] = content8;
        contents[9] = content9;
        contents[10] = content10;
        contents[11] = content11;
        contents[12] = content12;
        contents[13] = content13;
        contents[14] = content14;
        contents[15] = content15;
        contents[16] = content16;
        contents[17] = content17;
        contents[18] = content18;
        contents[19] = content19;
        contents[20] = content20;
        contents[21] = content21;
        contents[22] = content22;
        contents[23] = content23;
        contents[24] = content24;
        contents[25] = content25;
        contents[26] = content26;
        contents[27] = content27;
        contents[28] = content28;
        contents[29] = content29;
        contents[30] = content30;
        contents[31] = content31;

        contents[0].isUnlocked = true;
    }

*/