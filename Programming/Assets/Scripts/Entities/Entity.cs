using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected StateMachine StateMachine;
    public Element currentElement;
    public SpriteRenderer spriteRenderer;
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

        ResetStats();
    }

    public void SetEntity(Element element, EntityData data)
    {
        this.currentElement = element;
        this.EntityData = data;
        this.spriteRenderer.sprite = GameData.Instance.GetEnemySprite(element, EntityData.entityLevel);
        transform.localScale = Vector3.one * data.entitySize;

        this.Core.Life.SetInitialEntityHealth(EntityData.healthStat.currentValue);
    }
    public virtual void ResetStats()
    {
        if(EntityData != null)
        {
            EntityData.healthStat.Reset();
            EntityData.movementSpeedStat.Reset();
        }
    }


}
