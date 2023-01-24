using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicRanged : EnemyAI
{
    private BaseObjectStats stats;
    private Rigidbody2D rb;
    private AudioSource audioSource;

    [SerializeField] private AudioClip soundAttack;

    // AI States
    private enum State { idle, idleMove, attacking };
    [SerializeField] private State state = State.idle;
    public override void SetState(int value) { state = (State)value; }

    // booleans used for states and methods
    private bool canMove = true;
    public bool CanMove { get { return canMove; } set { canMove = value; } }

    private bool onIdle = false;
    private bool onIdleMove = false;
    private bool onAttack = false;

    // variables used for idle move state methods
    [SerializeField] private float onIdleMoveCooldown = 3f;
    [SerializeField] private float onIdleCooldown = 2f;
    private float onIdleMoveTime = 0f;

    // variables used for attack state methods
    [SerializeField] private float attackSpeed = 4f;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float targetDistance = 8f;
    [SerializeField] private bool attackReady = true;

    // Vector variables used for idle and attack movements
    private Vector2 directionToMove;
    [SerializeField] private Vector3 directionToFace;
    [SerializeField] private Vector3 target;
    //private Vector2[] idleMoveTransform = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    private WaitForSeconds WaitFixedUpdate;
    //private WaitForSeconds waitWalk;
    private WaitForSeconds waitIdle;
    private WaitForSeconds waitOne;
    private WaitForSeconds waitAttack;

    [SerializeField] private GameObject projectileGameObject;
    private GameObject projectileInstance;

    private void Awake()
    {
        stats = GetComponent<BaseObjectStats>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        WaitFixedUpdate = new WaitForSeconds(0.02f);
        //waitWalk = new WaitForSeconds(3f);
        waitIdle = new WaitForSeconds(1f);
        waitOne = new WaitForSeconds(1f);
        waitAttack = new WaitForSeconds(attackSpeed);

        // generate random direction at start up used for idle move destinantion
        Vector2 direction = Leo.GetRandomDirection();
        directionToFace = (Vector2)transform.position + direction * 3;
    }

    private void Start()
    {
        projectileInstance = Instantiate(projectileGameObject, gameObject.transform.position, Quaternion.identity);
        projectileInstance.SetActive(false);
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
        if (!onIdle)
        {
            onIdle = true;
            onIdleMove = false;
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
            onAttack = false;
            StartCoroutine(CIdleMove());
        }
    }

    private void StateAttackTarget()
    {
        if (!onAttack)
        {
            onIdle = false;
            onIdleMove = false;
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
        directionToFace = (directionToMove - rb.position).normalized;

        while (onIdleMoveTime < onIdleMoveCooldown || rb.position == directionToMove)
        {
            rb.velocity = (directionToFace * stats.MoveSpeed);
            //Debug.DrawLine(transform.position, transform.position + directionToFace, Color.yellow);
            onIdleMoveTime += Time.fixedDeltaTime;

            if (Vector3.Distance(transform.position, FindObjectOfType<PlayerStats>().gameObject.transform.position) < targetDistance && attackReady)
            {
                state = State.attacking;
                yield break;
            }
            yield return WaitFixedUpdate;
        }

        ResetState();
    }

    private IEnumerator CAttackTarget()
    {
        while (onAttack)
        {
            if (attackReady && Vector3.Distance(transform.position, FindObjectOfType<PlayerStats>().gameObject.transform.position) < targetDistance)
            {
                RangedAttack();
                state = State.idle;
            }

            yield return WaitFixedUpdate;
        }
    }

    private void AttackGaugeTimer()
    {
        StartCoroutine(CAttackGaugeTimer());
    }

    private IEnumerator CAttackGaugeTimer()
    {
        yield return waitAttack;

        attackReady = true;
    }

    private void RangedAttack()
    {
        projectileInstance.SetActive(true);
        projectileInstance.transform.position = this.gameObject.transform.position;

        target = FindObjectOfType<PlayerStats>().gameObject.transform.position;

        audioSource.PlayOneShot(soundAttack);
        projectileInstance.GetComponentInParent<ProjectileEnemy>().Fire((target - transform.position).normalized);
        attackReady = false;
        AttackGaugeTimer();
    }

    private void ResetState()
    {
        onIdle = false;
        onIdleMove = false;
        onAttack = false;
        state = State.idle;
    }
}
