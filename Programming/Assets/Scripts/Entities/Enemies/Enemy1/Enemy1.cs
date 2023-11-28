using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy1 : Entity
{
    public string stateName;
    public Enemy1Data data;

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        moveState = new Enemy1MoveState(this, data, StateMachine, Core, stateName, spriteRenderer);
        idleState = new Enemy1IdleState(this, data, StateMachine, Core, stateName);

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
        Gizmos.DrawWireSphere(transform.position, data.minDistanceToPlayer);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, data.damageRadious);
    }
}
