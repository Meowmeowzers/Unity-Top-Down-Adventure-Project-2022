using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Collider2D meleeAttackCollider;
    [SerializeField] private SpriteRenderer attackEffect;
    [SerializeField] private Animator attackEffectAnimation;
    [SerializeField] private AudioClip[] soundAttack;

    private Animator animPlayer;
    private Attack attack;
    private AudioSource audioSource;

    private Movement movement;

    private Vector3 attackOffset;
    private Vector2 attackSize;

    //public float attackDamage = 3;

    private void Start()
    {
        movement = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();
        attackOffset = meleeAttackCollider.offset;
        attack = meleeAttackCollider.GetComponent<Attack>();
        animPlayer = GetComponentInParent<Animator>();
        attackSize.x = attackOffset.x / 2;
        attackSize.y = attackOffset.y / 2;
    }

    public void StartAttack()
    {
        audioSource.PlayOneShot(soundAttack[Random.Range(0, soundAttack.Length)]);
        GetAttackDirection();
        meleeAttackCollider.transform.localPosition += attackOffset;
        meleeAttackCollider.enabled = true;
        attackEffect.enabled = true;
        attack.enabled = true;
        attackEffectAnimation.SetBool("isTriggered", true);
        animPlayer.SetTrigger("meleeAttack");
        //Hit();
    }

    public void StopAttack()
    {
        meleeAttackCollider.enabled = false;
        attack.enabled = false;
        attackEffect.enabled = false;
        attackOffset.x = 0;
        attackOffset.y = -0.1f;
        meleeAttackCollider.transform.localPosition = attackOffset;
        //attackEffectAnimation.SetBool("isTriggered", false);
        attackEffectAnimation.SetBool("isTriggered", false);
    }

    private void GetAttackDirection()
    {
        switch (movement.ldirection)
        {
            case Movement.LastDirection.top:
                attackOffset.y += .6f;
                break;

            case Movement.LastDirection.down:
                attackOffset.y -= .5f;
                break;

            case Movement.LastDirection.left:
                attackOffset.x -= .7f;
                break;

            case Movement.LastDirection.right:
                attackOffset.x += .7f;
                break;
        }
    }
}

/*
    private void Hit()
    {
        Collider2D[] x = attack.CheckAttack(attackOffset, attackSize);
        Debug.Log(x.Length);
        for(int i = 0;i < x.Length;i++) {
            Debug.Log(x[i]);
        }
    }
private void Hit()
    {
        attack.CheckAttack(attackOffset, attackSize);
    }
*/