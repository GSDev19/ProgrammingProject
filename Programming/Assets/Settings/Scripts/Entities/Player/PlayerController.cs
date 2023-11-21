using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    public static PlayerController Instance { get; private set; }

    public EntityData entityData;

    public string stateName;
    public AttackData primaryAttackData;
    public AttackData secondaryAttackData;
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

    }
    private void Start()
    {
        moveState = new PlayerMoveState(this, entityData, StateMachine, Core, stateName);
        idleState = new PlayerIdleState(this, entityData, StateMachine, Core, stateName);
        primaryAttackState = new PlayerPrimaryAttackState(this, entityData, StateMachine, Core, stateName, primaryAttackData);
        secondaryAttackState = new PlayerSecondaryAttackState(this, entityData, StateMachine, Core, stateName, primaryAttackData);

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


}
