using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCell_Main : MonoBehaviour
{
    [SerializeField] private SpawnCell_Gate[] gate;
    [SerializeField] private SpawnCell_Trigger[] trigger;
    [SerializeField] private SpawnCell_Spawner spawner;

    private WaitForSeconds wait;
    public float cooldown = 60f;

    private WaitForSeconds waitSeconds;

    public bool isActive = false;
    public bool isReady = true;

    private void Start()
	{
		wait = new WaitForSeconds(cooldown);
		waitSeconds = new WaitForSeconds(2f);
	}

    public void StartSpawnCell()
    {
        if (!isActive)
        {
            isActive = true;
            isReady = false;
            StartCoroutine(Spawn());
            AudioManager.Instance.PlayMusic(3);
        }
    }

    private IEnumerator Spawn()
    {
		Debug.Log("Spawn Started");
        for (int i = 0; i < gate.Length; i++)
        {
            gate[i].IsEnabled(true);
            spawner.Spawn();
        }

        yield return null;
        StartCoroutine(Monitor());            
    }

    private IEnumerator Monitor()
    {
        while (isActive)
        {
            if (!spawner.isActive)
            {
                for (int i = 0; i < gate.Length; i++)
                {
                    gate[i].IsEnabled(false);
                }
                for (int i = 0; i < trigger.Length; i++)
                {
                    trigger[i].isReady = true;
                }
                AudioManager.Instance.PlayMusic(1);
                isActive = false;
            }
            yield return waitSeconds;
        }
        yield return wait;
        isReady = true;
        Debug.Log("Spawn Ready");
        StopCoroutine(Monitor());
    }
}
