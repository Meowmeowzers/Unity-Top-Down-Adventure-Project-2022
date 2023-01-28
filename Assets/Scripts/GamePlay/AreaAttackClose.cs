using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaAttackClose : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void StartAttack(float damage)
    {
        anim.SetTrigger("Active");
        FindObjectOfType<PlayerStats>().TakeDamage(damage);
    }
}
