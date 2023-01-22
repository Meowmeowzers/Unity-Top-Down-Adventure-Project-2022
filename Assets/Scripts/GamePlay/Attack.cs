using UnityEngine;

public class Attack : MonoBehaviour
{
    private PlayerStats player;
    public LayerMask layerMask;

    private void Start()
    {
        player = GetComponentInParent<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<BaseObjectStats>() &&
            !collision.gameObject.GetComponent<PlayerStats>())
        {
            collision.gameObject.GetComponent<BaseObjectStats>().TakeDamage(player.AttackDamage);
        }
    }
}

/*
 BaseObjectStats[] target = collision.gameObject.GetComponent<BaseObjectStats[]>();
        Physics2D.
        if (collision != null && target != null)
        {
            for(int i = 0; i < target.Length; i++)
            {
                target[i].CallAttacked(player.attack);
                Debug.Log(target[i]);
            }
        }

    public void CheckAttack(Collider2D colllider,Vector2 point, Vector2 size)
    {
        enemies = Physics2D.OverlapBoxAll(point, size, layerMask);

        foreach(Collider2D x in enemies)
        {
            Debug.Log(x.name);
        }
    }
*/