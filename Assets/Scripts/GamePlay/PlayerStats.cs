using UnityEngine;

public class PlayerStats : BaseObjectStats
{
    //[SerializeField] private int objectMP = 0;
    //[SerializeField] private int physicalDefense = 0;
    //[SerializeField] private int magicalDefense = 0;
    //[SerializeField] private float extraMovementSpeed = 0f;
    [SerializeField] private AudioClip sound;

    private GameManager gameManager;
    private Animator anim;
    private Movement movement;
    private AudioSource audioSource;
    private SpriteRenderer sr;
    private Color originalColor;
    private Color damagedColor = new Vector4(1f, 0.6f, 0.3f, 1f);

    public bool isDead = false;

    private void Start()
    {
        gameManager = GameManager.Instance;
        anim = GetComponent<Animator>();
        movement = GetComponent<Movement>();
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        originalColor = sr.color;
        if (objectHP > objectMaxHP)
        {
            objectHP = objectMaxHP;
        }
    }

    public override float ObjectHP
    {
        set
        {
            if (objectHP > objectMaxHP)
            {
                objectHP = objectMaxHP;
            }
            else if (objectHP > 0)
            {
                objectHP = value;
                //DamagedFlashStart();
                //Debug.Log("Leo - player hp modified " + value);

                if (objectHP <= 0 && !isDead)
                {
                    objectHP = 0;
                    Defeated();
                }
            }
            else if (objectHP <= 0)
            {
                objectHP = 0;
            }

            //Debug.Log("Life left: " + objectHP);
        }
        get
        {
            return objectHP;
        }
    }

    protected override void Defeated()
    {
        anim.SetBool("isDead", true);

        isDead = true;
        //gameManager.RespawnPlayer();
        GameManager.Instance.RespawnPlayer();
    }

    public void Disable()
    {
        movement.LockMove();
        gameObject.SetActive(false);
    }

    public void Respawn(Vector2 checkpointTransform)
    {
        gameObject.SetActive(true);
        isDead = false;
        anim.SetBool("isDead", false);
        movement.UnlockMove();
        objectHP = 10;
        transform.position = checkpointTransform;
    }

    public void ModifyHP(float value)
    {
        //Debug.Log("Leo - original hp " + ObjectHP);
        ObjectHP += value;

        // Im too lazy to fix the late update of hp when modifying hp greater than max hp.
        // So i just copy pasted this code, without taking note of the structure or sequence
        if (objectHP > objectMaxHP)
        {
            objectHP = objectMaxHP;
        }
        //Debug.Log("Leo - modified hp " + ObjectHP);
    }

    public override void TakeDamage(float damage)
    { Attacked(damage); }

    protected override void Attacked(float damage)
    {
        if (objectHP > 0)
        {
            DamagedFlashStart();
        }
        ObjectHP -= damage;
    }

    private void DamagedFlashStart()
    {
        sr.color = damagedColor;
        audioSource.PlayOneShot(sound);
        Invoke(nameof(DamagedFlashStop), .20f);
    }

    private void DamagedFlashStop()
    {
        sr.color = originalColor;
    }
}