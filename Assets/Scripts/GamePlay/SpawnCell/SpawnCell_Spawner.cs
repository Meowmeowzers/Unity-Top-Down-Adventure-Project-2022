using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCell_Spawner : MonoBehaviour
{
    [SerializeField] private SpawnCell_Node[] spawnTransform;
    private WaitForSeconds wait;

    public int spawnCurrentActive;
    public bool isActive = false;


    private void Awake()
    {
        wait = new WaitForSeconds(2);
    }

    public void Spawn()
    {
        for (int i = 0;i < spawnTransform.Length; i++)
        {
            spawnTransform[i].EnableSpawn();
        }
        StartCoroutine(MonitorSpawns());
    }

    private IEnumerator MonitorSpawns()
    {
        isActive = true;
        while (isActive)
        {
            if(spawnCurrentActive == 0)
            {
                isActive = false;
                Debug.Log("Spawner is inactive");
            }
            yield return wait;
        }
    }
}
