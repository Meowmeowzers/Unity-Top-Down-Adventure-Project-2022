using UnityEngine;

[CreateAssetMenu(menuName = "CustomAsset/MusicClip")]
public class MusicClip : ScriptableObject
{
    public AudioClip menu;
    public AudioClip normal1;
    public AudioClip normal2;
    public AudioClip battle1;
    public AudioClip battle2;
    public AudioClip safe;
}
