using UnityEngine;

public class Trap : MonoBehaviour
{
    private bool active = true;
    private float damage = 5f;
    private readonly float damageRate = 0.8f;
    private float damageReady = 0f;

    private void FixedUpdate()
    {
        if (damageReady <= damageRate)
        {
            damageReady += Time.fixedDeltaTime;
            //Debug.Log("trap readying" + damageReady);
        }
        else if (damageReady >= damageRate && !active)
        {
            active = true;
            //Debug.Log("trap ready");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerStats>() && active)
        {
            HitPlayer(collision);
        }
    }

    private void HitPlayer(Collider2D col)
    {
        col.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        active = false;
        damageReady = 0f;
    }
}