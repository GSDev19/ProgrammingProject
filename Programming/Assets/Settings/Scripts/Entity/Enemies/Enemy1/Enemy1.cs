using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1 : Entity
{
    [SerializeField] public string stateName;
    [field: SerializeField] protected Enemy1Data entityData;
    public override void Awake()
    {
        base.Awake();

        StateMachine = new StateMachine();
        moveState = new Enemy1MoveState(this, entityData, StateMachine, Core, stateName);
        idleState = new Enemy1IdleState(this, entityData, StateMachine, Core, stateName);
    }
    private void Start()
    {
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, entityData.minDistanceToPlayer);
    }
}
