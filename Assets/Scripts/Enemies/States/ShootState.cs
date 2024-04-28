using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : State
{
    protected D_ShootState stateData;

    protected bool isPlayerInAgroRange;

    protected bool shootingDone;
    public ShootState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ShootState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
        shootingDone = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(Time.time >= startTime + stateData.shootDuration)
        {
            if(isPlayerInAgroRange)
            {
                startTime = Time.time;
            } else
            {
                shootingDone = true;
            }
            
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

