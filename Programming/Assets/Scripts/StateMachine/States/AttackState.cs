using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{        
    public AttackState(Entity entity, EntityData data, StateMachine stateMachine, Core core, string stateName) : base(entity, data, stateMachine, core, stateName)
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

        core.Movement.SetInputVelocity(InputHandler.Instance.NormX, InputHandler.Instance.NormY, data.movementSpeedStat.currentValue);
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
