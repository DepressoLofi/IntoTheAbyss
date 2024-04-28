using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Wizard : Entity
{
    private AudioSource detectSfx;
    public W_IdleState IdleState { get; private set; }
    public W_MoveState MoveState { get; private set; }
    public W_DeadState DeadState { get; private set; }
    public W_ShootState ShootState { get; private set; }
    public W_DetectedState DetectedState { get; private set; }


    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_DeadState deadStateData;
    [SerializeField] private D_ShootState shootStateData;
    [SerializeField] private D_DetectedState detectedStateData;


    public override void Awake()
    {
        base.Awake();
        detectSfx = GetComponent<AudioSource>();

        IdleState = new W_IdleState(this, stateMachine, "idle", idleStateData, this);
        MoveState = new W_MoveState(this, stateMachine, "move", moveStateData, this);
        DeadState = new W_DeadState(this, stateMachine, "dead", deadStateData, this);
        ShootState = new W_ShootState(this, stateMachine, "shoot", shootStateData, this);
        DetectedState = new W_DetectedState(this, stateMachine, "detect", detectedStateData, this);

        stateMachine.Initialize(MoveState);
    }

    // Update is called once per frame
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
