using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Entity
{
    private AudioSource detectSfx;
    public SK_MoveState MoveState { get; private set; }
    public SK_IdleState IdleState { get; private set; }
    public SK_DetectedState DetectedState { get; private set; }
    public SK_ChargeState ChargeState { get; private set; }
    public SK_DeadState DeadState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_DetectedState detectedStateData;
    [SerializeField] private D_ChargeState chargeStateData;
    [SerializeField] private D_DeadState deadStateData;

    public override void Awake()
    {
        base.Awake();
        detectSfx = GetComponent<AudioSource>();    

        MoveState = new SK_MoveState(this, stateMachine, "move", moveStateData, this);
        IdleState = new SK_IdleState(this, stateMachine,"idle", idleStateData, this);
        DetectedState = new SK_DetectedState(this, stateMachine,"detect", detectedStateData, this);
        ChargeState = new SK_ChargeState(this, stateMachine, "charge", chargeStateData, this);
        DeadState = new SK_DeadState(this, stateMachine,"dead", deadStateData, this);
        stateMachine.Initialize(MoveState);
    }

    public override void Update()
    {
        base.Update();
        if (!alive)
        {
            stateMachine.ChangeState(DeadState);
        }
    }

    public void PlaySound()
    {
        detectSfx.Play();
        
    }


}
