using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    private BoxCollider2D col;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }


}
