using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A static class for utility functions
public static class Leo
{       
    public static Vector2 GetRandomDirection()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
