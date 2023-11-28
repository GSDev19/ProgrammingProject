using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected StateMachine StateMachine;
    public Element currentElement;
    public SpriteRenderer spriteRenderer;
    public Core Core { get; private set; }
    [HideInInspector] public EntityData EntityData;

    public MoveState moveState;
    public IdleState idleState;
    public AttackState primaryAttackState;
    public AttackState secondaryAttackState;

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();

        StateMachine = new StateMachine();
    }

    public void SetEntity(Element element, EntityData data)
    {
        this.currentElement = element;
        this.EntityData = data;
        this.spriteRenderer.color = GameData.Instance.GetColor(element);
        spriteRenderer.transform.localScale = Vector3.one * data.enemySize;

        this.Core.Life.SetInitialEntityHealth(EntityData.entityHealth);
    }

}
