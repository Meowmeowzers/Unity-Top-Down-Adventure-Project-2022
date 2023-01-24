using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private GameObject itemDrop;
    private WaitForSeconds dropTime;
    
    private int rng;

    private void Awake()
    {
        dropTime = new WaitForSeconds(1f);
    }

    private void OnEnable()
    {
        rng = Random.Range(0, 15);
        Debug.Log(rng);
        if (rng <= 4)
        {
            //Debug.Log("item drop");
            StartCoroutine(CStartDrop());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator CStartDrop()
    {
        yield return dropTime;
        //Debug.Log("item drop");

        Instantiate(itemDrop, gameObject.transform.position, Quaternion.identity);
        yield return null;

        Destroy(gameObject);
        yield break;
    }
}
