using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public FiniteStateMachine stateMachine;
    public D_Entity entityData;

    public int facingDirection { get; private set; }
    public Rigidbody rb { get; private set;  }
    public Collider Collider { get; private set; }
    public GameObject mesh { get; private set; }
    public Animator anim { get; private set; }

    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform playerCheck;

    private Vector3 velocityWorkspace;
    private int currentHealth;

    // Start is called before the first frame update
    public virtual void Awake()
    {
        facingDirection = 1;
        currentHealth = entityData.hitPoint;
        Collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        stateMachine = new FiniteStateMachine();
    }


    public virtual void Update()
    {
        stateMachine.CurrentState.LogicUpdate();
        
    }

    public virtual void FixedUpdate()
    {
        stateMachine.CurrentState.PhysicUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        velocityWorkspace.Set(rb.velocity.x, rb.velocity.y, facingDirection *  velocity);
    }

    public virtual bool CheckWall()
    {
        return Physics.Raycast(wallCheck.position, mesh.transform.forward, entityData.wallCheckDistance, entityData.whatIsGround);
    }

    public virtual bool CheckLedge()
    {
        return Physics.Raycast(ledgeCheck.position, Vector3.down, entityData.ledgeCheckDistance, entityData.whatIsGround);
    }

    public virtual void Turn()
    {
        facingDirection *= -1;
        mesh.transform.Rotate(0f, 180f, 0f);
    }

    public virtual void Damaged()
    {
        currentHealth -= 1;
        if(currentHealth <= 0) 
        {
            Destroy(gameObject);
        }
    }

    public virtual bool CheckPlayerInAgroRange()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCheck.position, mesh.transform.forward, out hit, entityData.agroDistance, entityData.whatIsPlayer))
        {
            Puppy puppy = hit.collider.GetComponent<Puppy>();

            if (puppy != null)
            {
                if (puppy.alive)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + (Vector3)(Vector3.forward * facingDirection * entityData.wallCheckDistance));
        Gizmos.DrawLine(ledgeCheck.position, ledgeCheck.position + (Vector3)(Vector3.down * entityData.ledgeCheckDistance));
    }

}
