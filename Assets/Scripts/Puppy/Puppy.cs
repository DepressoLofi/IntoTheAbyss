using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puppy : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private int lifeCount;
    [SerializeField] private Vector3 lastCheckPoint;
    [SerializeField] public bool alive;

    [Header("Collect")]
    public int star;
    public InGameUI inGameUi;

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
        Cursor.visible = false;

        GameManager.Instance.GetActiveScene();
    }

    public void SetCheckpoint(Vector3 newPoint)
    {
        lastCheckPoint = newPoint;

    }

    private void Die()
    {
        if (alive)
        {
            lifeCount -= 1;
            alive = false;
            puppyCollider.enabled = false;
            meshRenderer.enabled = false;

            if (flesh != null)
            {
                GameObject vfx = Instantiate(flesh, transform.position, transform.rotation);
                SoundManager.PlaySound(SoundType.PUPPYPOP, 0.5f);
                Destroy(vfx, 0.9f);
            }
            if (inGameUi != null)
            {
                inGameUi.UpdateHeartCount(lifeCount);
            }



            GameStateManager.Instance.PuppyDied();
        }
        
        //fade screen
        
        if (lifeCount > 0)
        {
            StartCoroutine(Respawn(2f));
        }
        else
        {
            GameStateManager.Instance.GameOver();
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
            Star starProps = other.GetComponent<Star>();
            starProps.StarCollected();
            star++;
            if (inGameUi != null)
            {
                inGameUi.IncreaseStarCount(star);
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
