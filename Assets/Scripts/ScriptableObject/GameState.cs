using UnityEngine;

[CreateAssetMenu(menuName = "CustomAsset/GameState")]
public class GameState : ScriptableObject
{
    public string currentScene;
    public float gameTime;
}