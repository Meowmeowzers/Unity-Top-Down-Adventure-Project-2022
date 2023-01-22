using UnityEngine;

public class LevelData : MonoBehaviour
{
    public static bool[] area = new bool[5] { true, false, false, false, false };

    public static bool[] portal = new bool[25] { false, false, false, false, false,
                                                 false, false, false, false, false,
                                                 false, false, false, false, false,
                                                 false, false, false, false, false,
                                                 false, false, false, false, false };

    private void Awake()
    {
        area[0] = true;
        area[1] = true;
        area[2] = true;
        area[3] = true;
        area[4] = true;
        portal[0] = true;
        portal[1] = true;
        portal[2] = true;
        portal[3] = true;
        portal[4] = true;
        portal[5] = true;
        portal[6] = true;
        portal[7] = true;
        portal[8] = true;
        portal[9] = true;
        portal[10] = true;
        portal[11] = true;
        portal[12] = true;
        portal[13] = true;
        portal[14] = true;
        portal[15] = true;
        portal[16] = true;
        portal[17] = true;
        portal[18] = true;
        portal[19] = true;
        portal[20] = true;
        portal[21] = true;
        portal[22] = true;
        portal[23] = true;
        portal[24] = true;
    }

    public bool[] GetAreaData()
    {
        // Debug.Log(area);
        return area;
    }

    public bool[] GetPortalData()
    {
        // Debug.Log(portal);
        return portal;
    }
}