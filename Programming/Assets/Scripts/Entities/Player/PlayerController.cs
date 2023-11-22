using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    public static PlayerController Instance { get; private set; }

    public EntityData data;

    public string stateName;

    public override void Awake()
    {
        base.Awake();

        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        EntityData = data;
    }
    private void Start()
    {
        moveState = new PlayerMoveState(this, data, StateMachine, Core, stateName);
        idleState = new PlayerIdleState(this, data, StateMachine, Core, stateName);
        primaryAttackState = new PlayerPrimaryAttackState(this, data, StateMachine, Core, stateName);
        secondaryAttackState = new PlayerSecondaryAttackState(this, data, StateMachine, Core, stateName);

        StateMachine.Initialize(idleState);
    }
    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
        stateName = StateMachine.CurrentState.StateName();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    public void ChangeElement(Element element)
    {
        currentElement = element;
        spriteRenderer.color = GameData.Instance.GetColor(element);
    }
}
