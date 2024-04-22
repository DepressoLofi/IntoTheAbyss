using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class State 
{
    protected FiniteStateMachine stateMachine;
    protected Entity entity;

    protected float startTime;

    public State(Entity entity, FiniteStateMachine stateMachine)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        DoChecks();
    }

    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {
        DoChecks();
    }

    public virtual void PhysicUpdate()
    {

    }

    public virtual void DoChecks()
    {

    }

}
