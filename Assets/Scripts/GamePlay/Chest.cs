using UnityEngine;

public class Chest : BaseObjectStats
{
    private AudioSource audioSource;
    private SpriteRenderer sr;
    private Score score;

    [SerializeField] private AudioClip soundOpen;
    [SerializeField] private Sprite openedSprite;
    [SerializeField] private bool isOpened = false;

    public override float ObjectHP
    {
        set
        {
            //Check value if greater than 0 before modifying it
            if (objectHP > 0)
            {
                objectHP = value;
                if (objectHP <= 0 && !isOpened)
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
        audioSource = GetComponent<AudioSource>();
        score = FindObjectOfType<Score>();
        sr = GetComponent<SpriteRenderer>();
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
        sr.sprite = openedSprite;
        score.ScoreAdd(5);
        isOpened = true;
    }
}