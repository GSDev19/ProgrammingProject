using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1MoveState : MoveState
{
    Enemy1Data enemyData;
    public Enemy1MoveState(Entity entity, Enemy1Data data, StateMachine stateMachine, Core core, string stateName) : base(entity, data, stateMachine, core, stateName)
    {
        this.enemyData = data;
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

        if (core.Collision.CheckDistanceToPlayer(core.player.transform, entity.transform, enemyData.minDistanceToPlayer))
        {
            core.Movement.GoToPlayer(core.player.transform, entity.transform, enemyData.movementSpeed);
        }
        else
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
