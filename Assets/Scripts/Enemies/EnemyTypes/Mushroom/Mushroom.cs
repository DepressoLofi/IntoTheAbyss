using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Entity
{
    public M_IdleState IdleState { get; private set; }
    public M_MoveState MoveState { get; private set; }
    public M_DeadState DeadState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_DeadState deadStateData;

    public override void Awake()
    {
        base.Awake();
        IdleState = new M_IdleState(this, stateMachine,"idle", idleStateData, this);
        MoveState = new M_MoveState(this, stateMachine, "move", moveStateData, this);
        DeadState = new M_DeadState(this, stateMachine, "dead", deadStateData, this);

        stateMachine.Initialize(MoveState);
    }

    public override void Update()
    {
        base.Update();
        if (!alive)
        {
            Debug.Log("Enemy died");
            Destroy(gameObject);
        }
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.CompareTag("Monster"))
        {
            IdleState.SetTurnAfterIdle(true);
            stateMachine.ChangeState(IdleState);
        }
    }
   
}
