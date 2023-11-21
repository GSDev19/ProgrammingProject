using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected StateMachine StateMachine;
    public Core Core { get; private set; }

    public MoveState moveState;
    public IdleState idleState;
    public AttackState primaryAttackState;
    public AttackState secondaryAttackState;

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();

        StateMachine = new StateMachine();
    }
}
