using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisable : MonoBehaviour
{
    private void OnDisable()
    {
        GetComponent<Button>().interactable = false;
    }
}
