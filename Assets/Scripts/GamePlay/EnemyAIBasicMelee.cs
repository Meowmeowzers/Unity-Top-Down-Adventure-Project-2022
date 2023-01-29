using System.Collections;
using UnityEngine;

// Basic Melee Enemy AI script

public class EnemyAIBasicMelee: EnemyAI
{
    private BaseObjectStats stats;
    private Rigidbody2D rb;

    // AI States
    private enum State
    { idle, idleMove, chasing, attacking };

    [SerializeField] private State state = State.idle;

    public override void SetState(int value)
    { state = (State)value; }

    // booleans used for states and methods
    private bool canMove = true;

    public bool CanMove
    { get { return canMove; } set { canMove = value; } }

    private bool onIdle = false;
    private bool onIdleMove = false;
    private bool onChase = false;
    private bool onAttack = false;

    // variables used for idle move state methods
    [SerializeField] private float onIdleMoveCooldown = 3f;

    [SerializeField] private float onIdleCooldown = 2f;
    private float onIdleMoveTime = 0f;

    // variables used for attack state methods
    [SerializeField] private float attackSpeed = 3f;

    [SerializeField] private float attackRange = 1.5f;
    private float attackGauge = 3f;
    [SerializeField] private float chaseDistance = 6f;

    // Vector variables used for idle and attack movements
    private Vector2 directionToMove;

    [SerializeField] private Vector3 directionToFace;
    [SerializeField] private Vector3 target;

    private WaitForFixedUpdate WaitFixedUpdate;

    private WaitForSeconds waitIdle;

    private WaitForSeconds waitOne;

    private void Start()
    {
        stats = GetComponent<BaseObjectStats>();
        rb = GetComponent<Rigidbody2D>();

        WaitFixedUpdate = new WaitForFixedUpdate();
        waitIdle = new WaitForSeconds(onIdleCooldown);
        waitOne = new WaitForSeconds(1f);

        // generate random direction at start up used for idle move destinantion
        Vector2 direction = Leo.GetRandomDirection();
        directionToFace = (Vector2)transform.position + direction * 3;
    }

    private void OnEnable()
    {
        StartCoroutine(StateMachine());
    }

    private IEnumerator StateMachine()
    {
        yield return waitIdle;

        ResetState();

        while (true)
        {
            switch (state)
            {
                case State.idle:
                    StateIdle();
                    break;

                case State.idleMove:
                    StateIdleMove();
                    break;

                case State.chasing:
                    StateChaseTarget();
                    break;

                case State.attacking:
                    StateAttackTarget();
                    break;
            }
            yield return waitOne;
        }
    }

    // Idle State
    private void StateIdle()
    {
        //if (state != State.idle) Debug.Log("Idle");
        if (!onIdle)
        {
            onIdle = true;
            onIdleMove = false;
            onChase = false;
            onAttack = false;
            StartCoroutine(Idle());
        }
    }

    private void StateIdleMove()
    {
        if (!onIdleMove)
        {
            onIdle = false;
            onIdleMove = true;
            onChase = false;
            onAttack = false;
            StartCoroutine(CIdleMove());
        }
    }

    private void StateChaseTarget()
    {
        if (!onChase)
        {
            onIdle = false;
            onIdleMove = false;
            onChase = true;
            onAttack = false;
            StartCoroutine(CChaseTarget());
        }
    }

    private void StateAttackTarget()
    {
        if (!onAttack)
        {
            onIdle = false;
            onIdleMove = false;
            onChase = false;
            onAttack = true;
            StartCoroutine(CAttackTarget());
        }
    }

    private IEnumerator Idle()
    {
        rb.velocity = Vector2.zero;
        yield return waitIdle;
        state = State.idleMove;
    }

    private IEnumerator CIdleMove()
    {
        onIdleMoveTime = Random.Range(-1f, 1f);
        directionToMove = (Vector2)transform.position + Leo.GetRandomDirection();
        directionToFace = directionToMove - rb.position;

        while (onIdleMoveTime < onIdleMoveCooldown || rb.position == directionToMove)
        {
            rb.velocity = (directionToFace.normalized * stats.MoveSpeed);
            Debug.DrawLine(transform.position, transform.position + directionToFace.normalized, Color.yellow);
            onIdleMoveTime += Time.fixedDeltaTime;
            if (Vector3.Distance(transform.position, FindObjectOfType<PlayerStats>().gameObject.transform.position) < chaseDistance && state != State.chasing)
            {
                state = State.chasing;
                yield break;
            }
            yield return WaitFixedUpdate;
        }

        ResetState();
    }

    private IEnumerator CChaseTarget()
    {
        while (onChase)
        {
            target = FindObjectOfType<PlayerStats>().gameObject.transform.position;
            if (Vector3.Distance(transform.position, target) < attackRange)
            {
                state = State.attacking;
            }
            else if (Vector3.Distance(transform.position, target) <= chaseDistance)
            {
                directionToFace = (target - transform.position).normalized;
                //Debug.DrawLine(transform.position, transform.position + directionToFace.normalized, Color.yellow);
                rb.velocity = directionToFace * stats.MoveSpeed;
            }
            else
            {
                ResetState();
            }
            yield return WaitFixedUpdate;
        }
    }

    private IEnumerator CAttackTarget()
    {
        while (onAttack)
        {
            if (attackGauge > attackSpeed && Vector3.Distance(transform.position, FindObjectOfType<PlayerStats>().gameObject.transform.position) < attackRange)
            {
                FindObjectOfType<PlayerStats>().TakeDamage(stats.AttackDamage);
                attackGauge = 0f;
            }
            else if (Vector3.Distance(transform.position, FindObjectOfType<PlayerStats>().gameObject.transform.position) < chaseDistance)
            {
                state = State.chasing;
            }

            attackGauge += Time.fixedDeltaTime;

            yield return WaitFixedUpdate;
        }
    }

    private void ResetState()
    {
        onIdle = false;
        onIdleMove = false;
        onChase = false;
        onAttack = false;
        state = State.idle;
    }
}

/*  Unused movement code
    //rb.MovePosition(rb.position + (stats.MoveSpeed * Time.fixedDeltaTime * target));
    //rb.MovePosition(rb.transform.position + (target * stats.MoveSpeed * Time.fixedDeltaTime));
    //coordinatesToFollow = aggro.targetPosition * stats.MoveSpeed * Time.fixedDeltaTime;
    //rb.AddForceAtPosition(aggro.targetPosition.normalized, rb.position);

private void StateIdleMove()
    {
        if (onIdleMoveTime > onIdleMoveCooldown)
        {
            onIdleMoveTime = 0f;
            Vector2 direction = (Vector2)transform.position + Leo.GetRandomDirection();
            destination = direction - (Vector2)transform.position;
            onIdleMove = false;
            state = State.idle;
        }

        rb.velocity = (destination.normalized * stats.MoveSpeed);
        FindTarget();
        onIdleMoveTime += Time.deltaTime;
    }

  private void OnCollisionEnter2D(Collision2D collision)
    {
        canMove = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canMove = true;
    }
*/