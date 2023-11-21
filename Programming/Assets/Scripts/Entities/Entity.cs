using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected StateMachine StateMachine;
    public Element currentElement;
    public Core Core { get; private set; }
    public EntityData EntityData { get; private set; }

    public MoveState moveState;
    public IdleState idleState;
    public AttackState primaryAttackState;
    public AttackState secondaryAttackState;

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();

        StateMachine = new StateMachine();
    }

    public void ChangeElement(Element element)
    {
        currentElement = element;
    }

    public virtual void SetData(EntityData entityData)
    {
        this.EntityData = entityData;
    }

}
