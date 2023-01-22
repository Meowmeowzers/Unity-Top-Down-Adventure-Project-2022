using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Shuriken : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed;

    private Vector2 stop;
    public float damage = 4f;

    private void Awake()
    {
        stop = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
            transform.Rotate(0f, 0f, 10f);
    }

    public void Fire(int x)
    {
        rb.velocity = stop;
        switch (x)
        {
            case 0:
                direction.x = 0f;
                direction.y = speed;
                break;
            case 1:
                direction.x = 0f;
                direction.y = -speed;
                break;
            case 2:
                direction.x = -speed;
                direction.y = 0f;
                break;
            case 3:
                direction.x = speed;
                direction.y = 0f;
                break;
        }
        rb.AddForce(direction, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BaseObjectStats>() && !collision.GetComponent<PlayerStats>())
        {
            collision.GetComponent<BaseObjectStats>().TakeDamage(damage);
            gameObject.SetActive(false);
        }
        else if (collision.GetComponent<TilemapCollider2D>())
        {
            gameObject.SetActive(false);
        }
    }
}
