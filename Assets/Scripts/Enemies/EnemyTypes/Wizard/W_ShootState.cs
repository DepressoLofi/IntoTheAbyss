using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W_ShootState : ShootState
{
    private Wizard enemy;
    public W_ShootState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ShootState stateData, Wizard enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (shootingDone)
        {
            enemy.IdleState.SetTurnAfterIdle(false);
            stateMachine.ChangeState(enemy.IdleState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

}
