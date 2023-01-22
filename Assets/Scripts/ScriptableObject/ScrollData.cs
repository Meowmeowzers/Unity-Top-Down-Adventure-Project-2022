using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CustomAsset/ScrollItemData")]
public class ScrollData : ScriptableObject
{
	[TextArea(3,5)]
    public string title;
	[TextArea(15,20)]
    public string content;
    public bool isUnlocked = false;

    public ScrollData(string a, string b)
    {
        this.title = a;
        this.content = b;
    }
}
