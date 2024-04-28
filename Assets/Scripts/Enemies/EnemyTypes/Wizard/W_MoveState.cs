using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class W_MoveState : MoveState
{
    public Wizard enemy;
    public W_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Wizard enemy) : base(entity, stateMachine, animBoolName, stateData)
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
        if (isDetectingWall || !isDetectingLedge || isDetectingMonster)
        {
            enemy.IdleState.SetTurnAfterIdle(true);
            stateMachine.ChangeState(enemy.IdleState);

        }
        else
        {

            entity.SetVelocity(stateData.movementSpeed);
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

}
