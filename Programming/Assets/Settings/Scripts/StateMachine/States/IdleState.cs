using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(Entity entity, EntityData data, StateMachine stateMachine, Core core, MovementController movementController, string stateName, bool isPlayer) : base(entity, data, stateMachine, core, movementController, stateName, isPlayer)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override string StateName()
    {
        return base.StateName();
    }
}
