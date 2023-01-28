using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Collider2D meleeAttackCollider;
    [SerializeField] private SpriteRenderer attackEffect;
    [SerializeField] private Animator attackEffectAnimation;
    [SerializeField] private AudioClip[] soundAttack;
    [SerializeField] private AudioClip soundRangedAttack;

    [SerializeField] private GameObject shuriken;
    private GameObject projectile;

    private Animator animPlayer;
    private Attack attack;
    private AudioSource audioSource;

    private Movement movement;

    private Vector3 attackOffset;
    private Vector2 attackSize;

    private WaitForSeconds cooldownAttack2 = new(2f);
    private bool isAttack2Ready = true;

    private void Start()
    {
        movement = GetComponent<Movement>();
        audioSource = GetComponent<AudioSource>();
        attackOffset = meleeAttackCollider.offset;
        attack = meleeAttackCollider.GetComponent<Attack>();
        animPlayer = GetComponentInParent<Animator>();
        attackSize.x = attackOffset.x / 2;
        attackSize.y = attackOffset.y / 2;

        projectile = Instantiate(shuriken, gameObject.transform.position, Quaternion.identity);
        projectile.SetActive(false);
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

    public void OnAttack2()
    {
        if (isAttack2Ready)
        {
            Debug.Log("ranged attack");
            isAttack2Ready = false;
            StartCoroutine(CAttack2Ready());
            attackEffectAnimation.SetBool("isTriggered", true);
            animPlayer.SetTrigger("meleeAttack");
            projectile.SetActive(true);
            projectile.transform.position = this.gameObject.transform.position;

            audioSource.PlayOneShot(soundRangedAttack);

            switch (movement.ldirection)
            {
                case Movement.LastDirection.top:
                    projectile.GetComponent<Shuriken>().Fire(0);
                    break;

                case Movement.LastDirection.down:
                    projectile.GetComponent<Shuriken>().Fire(1);
                    break;

                case Movement.LastDirection.left:
                    projectile.GetComponent<Shuriken>().Fire(2);
                    break;

                case Movement.LastDirection.right:
                    projectile.GetComponent<Shuriken>().Fire(3);
                    break;
            }
        }
    }

    private IEnumerator CAttack2Ready()
    {
        yield return cooldownAttack2;

        isAttack2Ready = true;
 
        yield break;
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