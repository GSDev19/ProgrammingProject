using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1MoveState : MoveState
{
    SpriteRenderer spriteRenderer;
    public Enemy1MoveState(Entity entity, EntityData data, StateMachine stateMachine, Core core, string stateName, SpriteRenderer spriteRenderer) : base(entity, data, stateMachine, core, stateName)
    {
        this.spriteRenderer = spriteRenderer;
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

        core.Movement.GoToPlayer(PlayerController.Instance.transform, entity.transform, data.movementSpeedStat.currentValue, data.rotationSpeed, spriteRenderer);

        if (core.Collision.CheckDistanceToPlayer(PlayerController.Instance.transform, entity.transform, data.minDistanceToPlayer))
        {
            stateMachine.ChangeState(entity.idleState);
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
