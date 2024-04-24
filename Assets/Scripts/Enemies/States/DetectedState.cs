using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedState : State
{
    protected D_DetectedState stateData;

    protected bool isPlayerInAgroRange;
    protected bool performAction;
    public DetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DetectedState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        performAction = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time >= startTime + stateData.ActionTime)
        {
            performAction = true;
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isPlayerInAgroRange = entity.CheckPlayerInAgroRange();
    }
}
