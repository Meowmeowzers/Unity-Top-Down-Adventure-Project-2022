using System.Collections;
using UnityEngine;

// Boss 1 Enemy AI script

public class EnemyAIBoss1 : EnemyAI
{
    private BaseObjectStats stats;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private AreaAttackClose attackArea;

    private AudioSource audioSource;

    [SerializeField] private AudioClip soundAttack;

    // AI States
    private enum State
    { idle, idleMove, attack, summon };

    [SerializeField] private State state = State.idle;

    public override void SetState(int value)
    { state = (State)value; }

    // booleans used for states and methods
    private bool canMove = true;

    public bool CanMove
    { get { return canMove; } set { canMove = value; } }

    private bool onIdle = false;
    private bool onIdleMove = false;
    private bool onAttack = false;
    private bool onSummon = false;

    // variables used for idle move state methods
    [SerializeField] private float onIdleMoveCooldown = 3f;

    [SerializeField] private float onIdleCooldown = 2f;
    private float onIdleMoveTime = 0f;

    // variables used for attack state methods
    [SerializeField] private float attackSpeed = 3f;

    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float targetDistance = 6f;
    [SerializeField] private bool attackReady = true;
    [SerializeField] private float summonCooldown = 3f;
    [SerializeField] private bool summonReady = true;

    private float offset;
    private Vector2 newTransform;

    // Vector variables used for idle and attack movements
    [SerializeField] private Vector3 directionToFace;

    [SerializeField] private Vector3 target;
    private Vector2 directionToMove;
    //private Vector2[] idleMoveTransform = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    private WaitForFixedUpdate WaitFixedUpdate;
    private WaitForSeconds waitIdle;
    private WaitForSeconds waitOne;
    private WaitForSeconds waitAttack;
    private WaitForSeconds waitSummon;

    [SerializeField] private GameObject projectileGameObject;
    private GameObject projectileInstance;
    //[SerializeField] private GameObject summonGameObject;
    //private GameObject[] summonInstance = new GameObject[3];

    private void Awake()
    {
        stats = GetComponent<BaseObjectStats>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        attackArea = GetComponentInChildren<AreaAttackClose>();
        audioSource = GetComponent<AudioSource>();

        WaitFixedUpdate = new WaitForFixedUpdate();
        waitIdle = new WaitForSeconds(onIdleCooldown);
        waitOne = new WaitForSeconds(1f);
        waitAttack = new WaitForSeconds(attackSpeed);
        waitSummon = new WaitForSeconds(summonCooldown);

        offset = col.offset.y;

        // generate random direction at start up used for idle move destinantion
        Vector2 direction = Leo.GetRandomDirection();
        directionToFace = (Vector2)transform.position + direction * 3;
    }

    private void Start()
    {
        projectileInstance = Instantiate(projectileGameObject, gameObject.transform.position, Quaternion.identity);
        projectileInstance.SetActive(false);
        //summonInstance[0] = Instantiate(summonGameObject, gameObject.transform.position, Quaternion.identity);
        //summonInstance[1] = Instantiate(summonGameObject, gameObject.transform.position, Quaternion.identity);
        //summonInstance[2] = Instantiate(summonGameObject, gameObject.transform.position, Quaternion.identity);
        //summonInstance[0].SetActive(false);
        //summonInstance[1].SetActive(false);
        //summonInstance[2].SetActive(false);
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

                case State.attack:
                    StateAttack();
                    break;

                case State.summon:
                    StateSummon();
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
            onAttack = false;
            onSummon = false;
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
            onSummon = false;
            StartCoroutine(CIdleMove());
        }
    }

    private void StateAttack()
    {
        if (!onAttack)
        {
            onIdle = false;
            onIdleMove = false;
            onAttack = true;
            onSummon = false;
            StartCoroutine(CAttack());
        }
    }

    private void StateSummon()
    {
        if (!onSummon)
        {
            onIdle = false;
            onIdleMove = false;
            onAttack = false;
            onSummon = true;
            //StartCoroutine(CSummon());
        }
    }

    private IEnumerator Idle()
    {
        rb.velocity = Vector2.zero;
        if (summonReady)
        {
            //StartCoroutine(CSummon());
        }
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

            yield return WaitFixedUpdate;
        }

        if (Vector3.Distance(transform.position, FindObjectOfType<PlayerStats>().gameObject.transform.position) < targetDistance && state != State.attack)
        {
            state = State.attack;
            yield break;
        }

        ResetState();
    }

    private IEnumerator CAttack()
    {
        while (onAttack && attackReady)
        {
            /*
            if (Vector3.Distance(transform.position, FindObjectOfType<PlayerStats>().gameObject.transform.position) < attackRange)
            {
                //MeleeAttack();
            }
            */
            if (Vector3.Distance(transform.position, FindObjectOfType<PlayerStats>().gameObject.transform.position) < targetDistance)
            {
                RangedAttack();
            }

            attackReady = false;
            AttackGaugeTimer();
            state = State.idle;
            yield return WaitFixedUpdate;
        }
    }

    private IEnumerator CSummon()
    {
        Debug.Log("summon");
        summonReady = false;
        yield return waitSummon;
        summonReady = true;
    }

    private IEnumerator CAttackGaugeTimer()
    {
        yield return waitAttack;

        attackReady = true;
    }

    private void AttackGaugeTimer()
    {
        StartCoroutine(CAttackGaugeTimer());
    }

    private void RangedAttack()
    {
        projectileInstance.SetActive(true);
        newTransform.x = this.gameObject.transform.position.x;
        newTransform.y = this.gameObject.transform.position.y + offset;
        projectileInstance.transform.position = newTransform;

        target = FindObjectOfType<PlayerStats>().gameObject.transform.position;

        audioSource.PlayOneShot(soundAttack);
        projectileInstance.GetComponent<ProjectileEnemy>().Fire((target - transform.position).normalized);
    }

    private void MeleeAttack()
    {
        //attackArea.StartAttack(stats.AttackDamage);
        FindObjectOfType<PlayerStats>().TakeDamage(stats.AttackDamage);
    }

    private void ResetState()
    {
        onIdle = false;
        onIdleMove = false;
        onAttack = false;
        onSummon = false;
        state = State.idle;
    }
}