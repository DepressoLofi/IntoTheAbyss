using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    protected D_IdleState stateData;

    protected bool turnAfterIdle;
    protected bool isIdleTimeOver;
    protected bool isPlayerInAgroRange;

    protected float idleTime;

    public IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0f);
        isIdleTimeOver = false;

        SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();
        if (turnAfterIdle)
        {
            entity.Turn();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + idleTime)
        {
            isIdleTimeOver=true;
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

    public void SetTurnAfterIdle(bool turn)
    {
        turnAfterIdle = turn;
    }


    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }

}
