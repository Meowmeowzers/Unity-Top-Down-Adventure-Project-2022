using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnable : MonoBehaviour
{
    [SerializeField] private Button button;

    public void EnableButton(bool value)
    {
        button.interactable = value;
    }
}
