using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : MoveState
{
    public PlayerMoveState(Entity entity, EntityData data, StateMachine stateMachine, Core core, string stateName) : base(entity, data, stateMachine, core, stateName)
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


        core.Movement.SetInputVelocity(InputHandler.Instance.NormX, InputHandler.Instance.NormY, data.movementSpeed);

        if(InputHandler.Instance.PrimaryAttackInput)
        {
            stateMachine.ChangeState(entity.primaryAttackState);
        }
        else if(InputHandler.Instance.SecondaryAttackInput)
        {
            stateMachine.ChangeState(entity.secondaryAttackState);
        }
        else if (InputHandler.Instance.NormY == 0 && InputHandler.Instance.NormX == 0)
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
        return "Move";
    }
}
