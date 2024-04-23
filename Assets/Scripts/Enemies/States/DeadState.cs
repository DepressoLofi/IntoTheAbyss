using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    protected D_DeadState stateData;
    public DeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData; 
    }

    public override void Enter()
    {
        base.Enter();
        entity.Collider.enabled = false;
        entity.rb.constraints |= RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
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
    }

    public override void DoChecks()
    {
        base.DoChecks();

    }

}
