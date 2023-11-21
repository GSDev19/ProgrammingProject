using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IdleState
{
    public PlayerIdleState(Entity entity, EntityData data, StateMachine stateMachine, Core core, string stateName) : base(entity, data, stateMachine, core, stateName)
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

        if (InputHandler.Instance.PrimaryAttackInput)
        {
            stateMachine.ChangeState(entity.primaryAttackState);
        }
        else if (InputHandler.Instance.SecondaryAttackInput)
        {
            stateMachine.ChangeState(entity.secondaryAttackState);
        }
        else if (InputHandler.Instance.NormY != 0 || InputHandler.Instance.NormX != 0)
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
        return "Idle";
    }
}
