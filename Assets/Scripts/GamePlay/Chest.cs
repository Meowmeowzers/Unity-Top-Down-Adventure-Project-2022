using UnityEngine;

public class Chest : BaseObjectStats
{
    [SerializeField] private AudioClip soundOpen;

    private AudioSource audioSource;
    private Animator anim;
    private Score score;

    private bool isClosed = true;

    public override float ObjectHP
    {
        set
        {
            //Check value if greater than 0 before modifying it
            //I think it could reduce the possibility of bugs in the future
            if (objectHP > 0)
            {
                objectHP = value;
                if (objectHP <= 0 && isClosed)
                {
                    Defeated();
                }
            }
            //Debug.Log("Chest Life left: " + objectHP);
        }
        get
        {
            return objectHP;
        }
    }

    protected void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        score = FindObjectOfType<Score>();
    }

    public override void TakeDamage(float damage)
    {
        Attacked(damage);
    }

    protected override void Attacked(float damage)
    {
        ObjectHP -= damage;
    }

    protected override void Defeated()
    {
        audioSource.PlayOneShot(soundOpen);
        anim.SetBool("isOpened", true);
        score.ScoreAdd(5);
        isClosed = false;
    }
}