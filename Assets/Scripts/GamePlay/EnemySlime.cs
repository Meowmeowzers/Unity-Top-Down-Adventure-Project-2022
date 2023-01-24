using UnityEngine;

public class EnemySlime : BaseObjectStats
{
    private Animator anim;
    private AudioSource audioSource;
    private Collider2D col;
    private SpriteRenderer sr;
    private Color originalColor;
    private Color damagedColor = new Vector4(1f, 0.5f, 0.3f, 1f);

    [SerializeField] private AudioClip soundDestroy;

    private EnemyBasic ai;
    private EnemyDrop enemyDrop;

    public bool isDead = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        ai = GetComponent<EnemyBasic>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;

        enemyDrop = GetComponent<EnemyDrop>();
    }

    public override float ObjectHP
    {
        set
        {
            objectHP = value;
            if (objectHP > objectMaxHP)
            {
                objectHP = objectMaxHP;
            }
            else if (objectHP <= 0)
            {
                objectHP = 0;
                PlaySound(soundDestroy);
                isDead = true;
                anim.SetBool("isDead", true);
                enemyDrop.StartDrop();
            }
            //Debug.Log(gameObject + "'s life left: " + objectHP);
        }
        get
        {
            return objectHP;
        }
    }

    protected override void Defeated()
    {
        Debug.Log(gameObject + "defeated");
        gameObject.SetActive(false);
        //score.ScoreAdd(1);
    }

    private void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }

    private void DisableMove()
    {
        if (ai.CanMove)
        {
            ai.CanMove = false;
        }
    }

    protected override void Attacked(float damage)
    {
        ObjectHP -= damage;
        if (ObjectHP > 0)
        {
            DamagedFlashStart();
        }
    }

    public override void TakeDamage(float x)
    {
        Attacked(x);
    }

    private void DamagedFlashStart()
    {
        sr.color = damagedColor;
        //audioSource.PlayOneShot(sound);
        Invoke(nameof(DamagedFlashStop), .20f);
    }

    private void DamagedFlashStop()
    {
        sr.color = originalColor;
    }
}