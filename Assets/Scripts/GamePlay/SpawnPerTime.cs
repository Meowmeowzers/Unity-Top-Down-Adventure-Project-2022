using UnityEngine;

public class SpawnPerTime : MonoBehaviour
{
    private SpawnObject script;
    private Transform tf;
    private BoxCollider2D col;
    private bool isIn = false;

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
        tf = GetComponent<Transform>();
        script = GetComponent<SpawnObject>();
        InvokeRepeating("TriggerScript", 1f, 5f);
        InvokeRepeating("changeIsIn", 6f, 60);
    }

    private void FixedUpdate()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision != GetComponent<EnemySlime>() && !isIn)
        {
            isIn = true;
            TriggerScript();
        }
        */
    }

    private void TriggerScript()
    {
        if (isIn)
        {
            Debug.Log("Called");
            script.SpawnInArea();
        }
    }

    private void changeIsIn()
    {
        if (!isIn)
        {
            isIn = true;
        }
        else
        {
            isIn = false;
        }
    }
}