using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    protected Entity entity;
    protected EntityData data;
    protected StateMachine stateMachine;
    protected Core core;
    protected string stateName;

    public State(Entity entity, EntityData data, StateMachine stateMachine,Core core, string stateName)
    {
        this.entity = entity;
        this.data = data;
        this.stateMachine = stateMachine;
        this.core = core;
        this.stateName = stateName;
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
