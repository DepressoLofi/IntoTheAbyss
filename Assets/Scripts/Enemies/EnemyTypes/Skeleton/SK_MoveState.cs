using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SK_MoveState : MoveState
{
    private Skeleton enemy;
    public SK_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Skeleton enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.turnBack = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isPlayerInAgroRange)
        {
            stateMachine.ChangeState(enemy.DetectedState);
        }
        else if (entity.turnBack)
        {
            entity.turnBack = false;
            entity.Turn();
        }

    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        if(isDetectingWall || !isDetectingLedge || isDetectingMonster)
        {
            enemy.IdleState.SetTurnAfterIdle(true);
            stateMachine.ChangeState(enemy.IdleState);
        } else
        {
            entity.SetVelocity(stateData.movementSpeed);
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }
}
