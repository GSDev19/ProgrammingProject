using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    AttackData attackData;
    
    public AttackState(Entity entity, EntityData data, StateMachine stateMachine, Core core, string stateName, AttackData attackData) : base(entity, data, stateMachine, core, stateName)
    {
        this.attackData = attackData;
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

        core.Movement.SetInputVelocity(InputHandler.Instance.NormX, InputHandler.Instance.NormY, data.movementSpeed);
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
