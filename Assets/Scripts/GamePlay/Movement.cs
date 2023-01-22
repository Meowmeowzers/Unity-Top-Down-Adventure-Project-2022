using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private PlayerStats player;

    private Animator anim;
    private Rigidbody2D rb;

    //private SpriteRenderer sr;
    private PlayerAttack attack;

    private Vector2 moveInput;

    private bool canMove = true;
    private float lastMoveX = 0f;
    private float lastMoveY = 0f;

    public float LastMoveX
    { get { return lastMoveX; } set { } }

    public float LastMoveY
    { get { return lastMoveY; } set { } }

    public enum LastDirection
    { top, topleft, topright, down, downleft, downright, left, right }

    public LastDirection ldirection;

    private void Start()
    {
        player = GetComponent<PlayerStats>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        attack = GetComponentInChildren<PlayerAttack>();
    }

    private void Update()
    {
        if (canMove)
        {
            if (moveInput != Vector2.zero && (moveInput.x > 0.1f || moveInput.x < -0.1f || moveInput.y > 0.1f || moveInput.y < 0.1f))
            {
                anim.SetBool("isMoving", true);
                MoveCharacterAnimation();
                MoveCharacter();
                SetLastDirection();
            }
            else
            {
                anim.SetBool("isMoving", false);
                rb.velocity = new Vector2(0f, 0f);
            }
        }
    }

    private void MoveCharacter()
    {
        //rb.MovePosition(rb.position + (movementSpeed * Time.deltaTime * moveInput.normalized));
        //transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + moveInput.normalized, movementSpeed * Time.deltaTime);
        rb.velocity = (player.MoveSpeed * moveInput.normalized);
        //rb.AddForce(movementSpeed * moveInput.normalized, ForceMode2D.Impulse);
    }

    private void MoveCharacterAnimation()
    {
        anim.SetFloat("moveAnimX", moveInput.x);
        anim.SetFloat("moveAnimY", moveInput.y);
    }

#pragma warning disable IDE0051 // Remove unused private members
    private void OnMovement(InputValue value)
#pragma warning restore IDE0051 // Remove unused private members
    {
        moveInput = value.Get<Vector2>();

        if (moveInput.x > 0.35f || moveInput.x < -0.35f || moveInput.y > 0.35f || moveInput.y < -0.35f)
        {
            lastMoveX = moveInput.x;
            lastMoveY = moveInput.y;
        }
    }

    private void SetLastDirection()
    {
        if (moveInput.x > 0.35f && moveInput.y < 0.7f && moveInput.y > -0.7f)
        {
            ldirection = LastDirection.right;
        }
        else if (moveInput.x < -0.35f && moveInput.y < 0.7f && moveInput.y > -0.7f)
        {
            ldirection = LastDirection.left;
        }
        else if (moveInput.y > 0.35f)
        {
            ldirection = LastDirection.top;
        }
        else if (moveInput.y < -0.35f)
        {
            ldirection = LastDirection.down;
        }
    }

    public void LockMove()
    {
        moveInput.x = 0f;
        moveInput.y = 0f;
        canMove = false;
    }

    public void UnlockMove()
    {
        canMove = true;
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

#pragma warning disable IDE0051 // Remove unused private members
    private void OnAttack()
#pragma warning restore IDE0051 // Remove unused private members
    {
        if (canMove)
        {
            LockMove();
            //anim.SetTrigger("meleeAttack");
            anim.SetBool("isMoving", false);
            attack.StartAttack();
        }
    }

#pragma warning disable IDE0051 // Remove unused private members
    private void OnPause()
#pragma warning restore IDE0051 // Remove unused private members
    {
        GameManager.PauseGame();
    }
}

/*

[SerializeField] private Joystick joystick;
void Update()
{
    //From Joystick Input System
    //movement.x = joystick.Horizontal;
    //movement.y = joystick.Vertical;
    //Old Input System
    //movement2.x = Input.GetAxisRaw("Horizontal");
    //movement2.y = Input.GetAxisRaw("Vertical");
}

private void MoveJoy()
{
    rb.MovePosition(rb.position + (movementSpeed * Time.deltaTime * movement.normalized));
}
*/

/*
   if (moveInput.x < -.1)
   {
       //anim.Play("Player_Move_Left");
       anim.SetFloat("moveanimx", moveInput.x);
   }
   else if (moveInput.x > .1)
   {
       //anim.Play("Player_Move_Right");
       anim.SetFloat("moveanimx", moveInput.x);
   }
   else if (moveInput.y > .1)
   {
       //anim.Play("Player_Move_Up");
       anim.SetFloat("moveanimy", moveInput.y);
   }
   else if (moveInput.y < -.1)
   {
       //anim.Play("Player_Move_Down");
       anim.SetFloat("moveanimy", moveInput.y);
   }
   else
   {
       anim.SetFloat("moveanimx", 0);
       anim.SetFloat("moveanimy", 0);
   }
   */