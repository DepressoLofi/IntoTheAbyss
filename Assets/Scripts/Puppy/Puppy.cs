using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puppy : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private int lifeCount;
    [SerializeField] private Vector3 lastCheckPoint;
    [SerializeField] public bool alive;

    [Header("Collect")]
    public int star;
    public InGameUI starSystem;

    public SkinnedMeshRenderer meshRenderer;
    public GameObject flesh;

    private Collider puppyCollider;

    private void Awake()
    {
        puppyCollider = GetComponent<Collider>();
    }
    private void Start()
    {
        alive = true;
        lastCheckPoint = transform.position;
    }

    public void SetCheckpoint(Vector3 newPoint)
    {
        lastCheckPoint = newPoint;

    }

    private void Die()
    {
        alive = false;
        puppyCollider.enabled = false;


        meshRenderer.enabled = false;
        
        if (flesh != null)
        {
            GameObject vfx = Instantiate(flesh, transform.position, transform.rotation);
            Destroy(vfx, 0.9f);
        }

        GameStateManager.Instance.PuppyDied();
        //fade screen
        lifeCount -= 1;
        if (lifeCount > 0)
        {
            StartCoroutine(Respawn(2f));
        }
        else
        {
            //add game over script such as scene transition
            Debug.Log("You ran out of life");
        }

    }

    IEnumerator Respawn(float duration)
    {

        yield return Helpers.GetWait(duration);
        transform.position = lastCheckPoint;
        alive = true;
        GameStateManager.Instance.PuppyRevived();
        puppyCollider.enabled = true;
        meshRenderer.enabled = true;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Die();
        }
        if (other.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            star++;
            if (starSystem != null)
            {
                starSystem.IncreaseStarCount(star);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            Die();
        }
    }


}
