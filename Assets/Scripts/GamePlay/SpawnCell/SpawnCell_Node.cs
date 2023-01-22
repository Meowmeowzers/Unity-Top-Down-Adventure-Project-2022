using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCell_Node : MonoBehaviour
{
    [SerializeField] private GameObject entity;
    [SerializeField] private SpawnCell_Spawner spawner;

    private BaseObjectStats entityStats;
    private WaitForSeconds wait;

    public bool isActive = false;
    private bool isAlive = false;
    public bool IsAlive { get { return isAlive; } set { isAlive = value; } }

    private void Awake()
    {
        wait = new WaitForSeconds(2);
    }

    private void Start()
    {
        spawner = GetComponentInParent<SpawnCell_Spawner>();
        entityStats = entity.GetComponent<BaseObjectStats>();
    }

    public void EnableSpawn()
    {
        if(!isActive)
        {
            entity.transform.position = this.transform.position;
            entityStats.ObjectHP = entityStats.ObjectMaxHP;
            entity.GetComponent<EnemyBasic>().SetState(0);
            entity.SetActive(true);
            isActive = true;
            isAlive = true;            
            spawner.spawnCurrentActive++;
            StartCoroutine(MonitorSpawn());
        }
    }

    private IEnumerator MonitorSpawn()
    {
        while (isActive)
        {
            if (!isAlive)
            {
                spawner.spawnCurrentActive--;
                isActive = false;
                yield break;
            }
            yield return wait;
        }
    }
}
