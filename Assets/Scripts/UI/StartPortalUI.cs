using UnityEngine;
using UnityEngine.UI;

public class StartPortalUI : MonoBehaviour
{
    private LevelData savedLevelData;
    [SerializeField] private GameObject[] areaButtons;
    [SerializeField] private GameObject[] portalButtons;
    [SerializeField] private GameObject portalPanel;
    private bool[] currentAreaData;
    private bool[] currentPortalData;

    private void Awake()
    {
        savedLevelData = FindObjectOfType<LevelData>();
    }

    public void CloseUI()
    {
        GameManager.HideStartPortalPanel();
        portalPanel.SetActive(false);
        gameObject.SetActive(false);
    }

    public void OpenUI()
    {
        gameObject.SetActive(true);

        GetData();

        for (int x = 0; x < areaButtons.Length; x++)
        {
            //Debug.Log(currentAreaData[x]);
            if (currentAreaData[x] == true)
            {
                areaButtons[x].GetComponent<Button>().interactable = true;
            }
        }
    }

    private void GetData()
    {
        currentAreaData = savedLevelData.GetAreaData();
        currentPortalData = savedLevelData.GetPortalData();
    }

    private void ShowAvailablePortal(int areaIndex)
    {
        // Show portal panel and available portals in area.
        portalPanel.SetActive(true);

        // Quick guide I made for myself for area index to portal index.
        // Area  Min     Max
        //   0 =  0   to  4
        //   1 =  5   to  9
        //   2 =  10  to  14
        //   3 =  15  to  19
        //   4 =  20  to  24

        for (int i = areaIndex * 5, buttonIndex = 0; i < (areaIndex + 1) * 5; i++, buttonIndex++)
        {
            // Change scene to load of portal buttons depending on areaIndex. In this game its from 0 to 4 plus 1.
            portalButtons[buttonIndex].GetComponent<Travel>().SceneNameToLoad = "Area" + (areaIndex + 1);

            // Check if portal is unlocked from <LevelData>. If yes, make button interactable.
            if (currentPortalData[i] == true)
            {
                portalButtons[buttonIndex].GetComponent<Button>().interactable = true;
            }
            else
            {
                portalButtons[buttonIndex].GetComponent<Button>().interactable = false;
            }
        }
    }
}