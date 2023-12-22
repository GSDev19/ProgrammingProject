using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1IdleState : IdleState
{
    public Enemy1IdleState(Entity entity, EntityData data, StateMachine stateMachine, Core core, string stateName) : base(entity, data, stateMachine, core, stateName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        core.Movement.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!core.Collision.CheckDistanceToPlayer(PlayerController.Instance.transform, entity.transform, data.minDistanceToPlayer))
        {
            stateMachine.ChangeState(entity.moveState);
        }
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
