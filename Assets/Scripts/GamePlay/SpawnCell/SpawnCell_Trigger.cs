using UnityEngine;

public class SpawnCell_Trigger : MonoBehaviour
{
    private SpawnCell_Main main;
    public bool isReady = true;

    private void Start()
    {
        main = GetComponentInParent<SpawnCell_Main>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerStats>() && isReady && main.isReady)
        {
            isReady = false;
            main.StartSpawnCell();
        }
    }
}
