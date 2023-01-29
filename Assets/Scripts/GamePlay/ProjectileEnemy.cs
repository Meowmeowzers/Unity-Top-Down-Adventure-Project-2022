using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProjectileEnemy : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed;

    private Vector2 stop;
    public float damage = 4f;

    float angle;

    private void Awake()
    {
        stop = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector3 direction)
    {
        rb.velocity = stop;

        // IDK what happened with this math equation but it works
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerStats>() && !collision.GetComponent<EnemySlime>())
        {
            collision.GetComponent<PlayerStats>().TakeDamage(damage);
            gameObject.SetActive(false);
        }
        else if (collision.GetComponent<TilemapCollider2D>())
        {
            gameObject.SetActive(false);
        }
    }
}
