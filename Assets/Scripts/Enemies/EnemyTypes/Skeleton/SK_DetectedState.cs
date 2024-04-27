using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SK_DetectedState : DetectedState
{
    private Skeleton enemy;
    public SK_DetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DetectedState stateData, Skeleton enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0);
        enemy.PlaySound();
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (performAction)
        {
            stateMachine.ChangeState(enemy.ChargeState);
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
