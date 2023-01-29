using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    public Vector2 targetPosition;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerStats>())
        {
            targetPosition = collision.transform.position;
            //enemy.HasTarget(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerStats>())
        {
            //enemy.HasTarget(false);
        }
    }
}

/*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerStats>() &&
            Vector2.Distance(gameObject.transform.position, target.position) <= 0.8f)
        {
            canMove = false;
            if (attackSpeed <= attackReady && !enemySlime.isDead)
            {
                collision.gameObject.GetComponent<PlayerStats>().TakeDamage(enemySlime.attackDamage);
                attackReady = 0f;
            }
        }
        else if (attackReady <= attackSpeed)
        {
            attackReady += Time.deltaTime;
            canMove = true;
        }
    }

*/