using UnityEngine;

public abstract class BaseObjectStats : MonoBehaviour
{
    [SerializeField] protected float objectMaxHP;
    [SerializeField] protected float objectHP;
    [SerializeField] protected float attackDamage = 2f;
    //[SerializeField] private int objectMP = 0;
    //[SerializeField] private int physicalDefense = 0;
    //[SerializeField] private int magicalDefense = 0;
    //[SerializeField] private float extraMovementSpeed = 0f;
    //[SerializeField] private Score score;

    [SerializeField] protected float moveSpeed = 2;
    public float ObjectMaxHP { get { return objectMaxHP; } set { objectMaxHP = value; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public float AttackDamage { get { return attackDamage; } }
    public virtual float ObjectHP
    {
        set
        {
            //Debug.Log(objectHP);
            objectHP = value;
            if (objectHP > objectMaxHP)
            {
                objectHP = objectMaxHP;
            }
            else if (objectHP <= 0)
            {
                objectHP = 0;
                Defeated();
            }
            //Debug.Log(gameObject + "'s life left: " + objectHP);
        }
        get
        {
            return objectHP;
        }
    }

    private void Start()
    {
        if (objectHP > objectMaxHP)
        {
            objectHP = objectMaxHP;
        }
    }

    protected abstract void Defeated();

    public virtual void TakeDamage(float damage)
    { Attacked(damage); }

    protected abstract void Attacked(float damage);
}