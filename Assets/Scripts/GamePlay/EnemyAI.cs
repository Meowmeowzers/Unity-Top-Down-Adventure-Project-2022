using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // An empty base class to make EnemyBasic.cs and EnemyBasicRanged.cs have same parent

    public virtual void SetState(int value) { }
}
