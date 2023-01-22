using UnityEngine;

public class SpawnCell_Monitor : MonoBehaviour
{
    [SerializeField] private SpawnCell_Node node;

    private void OnEnable()
    {
        node.IsAlive = true;
    }

    private void OnDisable()
    {
        node.IsAlive = false;
    }
}
