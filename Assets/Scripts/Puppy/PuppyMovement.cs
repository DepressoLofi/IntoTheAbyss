using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyMovement : MonoBehaviour
{
    [Header("Movement stats")]
    public float speed;
    public float jumpForce;
    public float fallMultiplier;
    public float pullMultiplier;
    private Vector3 movement;

    [Header("Camera")]
    [SerializeField] private CinemachineVirtualCamera vcm;
    public bool direction; //false is left, true is right

    //some components 
    private Rigidbody rigid;
    private Collider puppyCollider;
    private Transform dogMesh;
    private Animator animator;
    [Header("Some Components")]
    public GameObject jumpVFX;
    public Transform jumpPoint;
    public Transform shootPoint;

    [Header("Ground")]
    [SerializeField] private bool grounded;
    [SerializeField] private bool doubleJump;
    public LayerMask whatIsGround;
    public bool onPlatform;

    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        puppyCollider = GetComponent<Collider>();

        dogMesh = transform.Find("DogMesh");

        if (dogMesh != null)
        {
            animator = dogMesh.GetComponent<Animator>();
        }

        onPlatform = false;
    }


    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, 1 * 0.5f + 0.29f, whatIsGround);

        if (grounded)
        {
            doubleJump = true;
            puppyCollider.material.dynamicFriction = 1;
        }
        else
        {
            puppyCollider.material.dynamicFriction = 0;
        }


        if (OnSlope())
        {
            rigid.useGravity = false;
        }
        else
        {
            rigid.useGravity = true;
        }


        animator.SetFloat("movement", movement.sqrMagnitude);
        animator.SetBool("grounded", grounded);


        if (movement.z > 0)
        {
            //move right
            direction = true; //right
        }
        else if (movement.z < 0)
        {
            //move left
            direction = false;
        }


        if (direction)
        {
            shootPoint.localPosition = new Vector3(0, 0, 1.2f);
            shootPoint.localRotation = Quaternion.identity;
            dogMesh.localRotation = Quaternion.identity;
            float targetOffset = 1f;
            SmoothlyChangeOffset(targetOffset);
        }
        else
        {
            shootPoint.localPosition = new Vector3(0, 0, -1.2f);
            shootPoint.localRotation = Quaternion.Euler(0f, 180f, 0f);
            dogMesh.localRotation = Quaternion.Euler(0f, 180f, 0f);
            float targetOffset = -1f;
            SmoothlyChangeOffset(targetOffset);
        }


        if (GameStateManager.Instance.freeze)
        {
            rigid.constraints |= RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
        else
        {
            rigid.constraints &= ~(RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ);
        }

        MyInput();
    }


    void FixedUpdate()
    {
        MovePlayer();
        ApplyGravity();
    }


    private void MyInput()
    {
        if (!GameStateManager.Instance.canInput)
        {
            return;
        }
        movement.z = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                Jump();
            }
            else if (doubleJump && GameStateManager.Instance.havePower)
            {
                Jump();
                if (jumpVFX != null)
                {
                    Instantiate(jumpVFX, jumpPoint.position, jumpPoint.rotation);
                }

                doubleJump = false;
            }
        }
    }

    private void MovePlayer()
    {
        if (onPlatform)
        {
            transform.Translate(speed * Time.deltaTime * movement);
        }
        else if (OnSlope())
        {
            rigid.MovePosition(rigid.position + GetSlopeMoveDirection() * speed * Time.deltaTime);
        }
        else
        {
            rigid.MovePosition(rigid.position + movement * speed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        rigid.velocity = Vector3.up * jumpForce;
    }

    private void ApplyGravity()
    {
        if (rigid.velocity.y < 0 && !OnSlope())
        {
            rigid.velocity += (-Vector3.up * fallMultiplier);
        }

        if (rigid.velocity.y > 0f && !OnSlope())
        {
            rigid.velocity += (-Vector3.up * pullMultiplier);
        }
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, 1 * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(movement, slopeHit.normal).normalized;
    }

    void SmoothlyChangeOffset(float targetOffset)
    {
        CinemachineFramingTransposer transposer = vcm.GetCinemachineComponent<CinemachineFramingTransposer>();


        transposer.m_TrackedObjectOffset.z = Mathf.Lerp(transposer.m_TrackedObjectOffset.z, targetOffset, Time.deltaTime * 5f);

    }

    private void OnDrawGizmos()
    {

        Gizmos.color = grounded ? Color.green : Color.red;

        Gizmos.DrawRay(transform.position, Vector3.down * (1 * 0.5f + 0.29f));
    }
}
