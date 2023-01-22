using UnityEngine;

public class SpawnCell_Gate : MonoBehaviour
{
    public void IsEnabled(bool value)
    {
        if(value)
        {
            gameObject.SetActive(true);
            Debug.Log("Gate Enabled");
        }
        else
            gameObject.SetActive(false);
            Debug.Log("Gate Disabled");
    }
}
