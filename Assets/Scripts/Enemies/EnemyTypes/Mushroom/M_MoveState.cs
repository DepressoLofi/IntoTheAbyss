using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_MoveState : MoveState
{
    private Mushroom enemy;

    public M_MoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Mushroom enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
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

    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        if(isDetectingWall || !isDetectingLedge || isDetectingMonster)
        {
            enemy.IdleState.SetTurnAfterIdle(true);
            stateMachine.ChangeState(enemy.IdleState);
        }
        else
        {
            entity.SetVelocity(stateData.movementSpeed);
        }
    }
}
