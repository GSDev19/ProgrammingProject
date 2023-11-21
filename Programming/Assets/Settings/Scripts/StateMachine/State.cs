using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected Entity entity;
    protected EntityData data;
    protected StateMachine stateMachine;
    protected Core core;
    protected MovementController movementController;
    protected string stateName;
    protected bool isPlayer;

    public State(Entity entity, EntityData data, StateMachine stateMachine,Core core, MovementController movementController, string stateName, bool isPlayer)
    {
        this.entity = entity;
        this.data = data;
        this.stateMachine = stateMachine;
        this.core = core;
        this.movementController = movementController;
        this.stateName = stateName;
        this.isPlayer = isPlayer;
    }
    public virtual void Enter()
    {
        DoChecks();

    }
    public virtual void Exit()
    {

    }
    public virtual void LogicUpdate()               // Called every frame , like update
    {

    }
    public virtual void PhysicsUpdate()             // Called like fixedUpdate
    {
        DoChecks();
    }
    public virtual void DoChecks()                  // Called from enterState and PhysicsUpdate
    {

    }
    public virtual string StateName()
    {
        return stateName;
    }
}
