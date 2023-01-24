using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
    [SerializeField] private GameObject dropper;

    public void StartDrop()
    {
        Instantiate(dropper, gameObject.transform.position, Quaternion.identity);
    }
}
