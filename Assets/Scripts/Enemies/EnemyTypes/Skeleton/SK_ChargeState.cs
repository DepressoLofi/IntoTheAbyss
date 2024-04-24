using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SK_ChargeState : ChargeState
{
    private Skeleton enemy;
    public SK_ChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, Skeleton enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
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
        if (isChargeTimeOver)
        {
            if (isPlayerInAgroRange)
            {
                stateMachine.ChangeState(enemy.DetectedState);
            }
            else
            {
                enemy.IdleState.SetTurnAfterIdle(false);
                stateMachine.ChangeState(enemy.IdleState);
            }
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        if(isDetectingWall || !isDetectingLedge || isDetectingMonster)
        {
            entity.SetVelocity(0);
            enemy.IdleState.SetTurnAfterIdle(true);
            stateMachine.ChangeState(enemy.IdleState);
        }
        else
        {     
            entity.SetVelocity(stateData.chargeSpeed);   
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }
}
