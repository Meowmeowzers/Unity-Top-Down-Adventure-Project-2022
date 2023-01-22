using System.Collections;
using UnityEngine;

// Created by an AI, I used it for basis
public class EnemyIdleMovement : MonoBehaviour
{
    // The minimum amount of time that the enemy will wait before starting to move again
    public float minIdleTime = 1.0f;

    // The maximum amount of time that the enemy will wait before starting to move again
    public float maxIdleTime = 3.0f;

    // The minimum force that the enemy will apply to move
    public float minMovementForce = 1.0f;

    // The maximum force that the enemy will apply to move
    public float maxMovementForce = 3.0f;

    // The rigidbody component of the enemy
    private Rigidbody2D rb;

    void Start()
    {
        // Get the rigidbody component of the enemy
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // If the enemy is not currently moving, choose a new movement direction
        if (rb.velocity.magnitude < 0.1f)
        {
            // Choose a random idle time
            float idleTime = Random.Range(minIdleTime, maxIdleTime);

            // Wait for the chosen idle time before moving again
            StartCoroutine(WaitForNextMovement(idleTime));
        }
    }

    IEnumerator WaitForNextMovement(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        // Choose a random movement force
        float movementForce = Random.Range(minMovementForce, maxMovementForce);

        // Choose a random direction to apply the force in
        float angle = Random.Range(0, 2 * Mathf.PI);
        Vector2 forceDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        // Apply the force to the enemy's rigidbody
        rb.AddForce(forceDirection * movementForce, ForceMode2D.Impulse);
    }
}