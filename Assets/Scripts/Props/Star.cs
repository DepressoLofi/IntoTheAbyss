using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Star : MonoBehaviour
{
    public GameObject burstPrefab;

    public PlayableDirector showStory;

    private void Update()
    {
        transform.Rotate(0f, 90f * Time.deltaTime, 0f, Space.Self);
    }
    public void StarCollected()
    {
        var burst = Instantiate(burstPrefab, transform.position, transform.rotation);
        Destroy(burst, 5f);
        Destroy(gameObject);
        SoundManager.PlaySound(SoundType.STAR, 0.8f);
        if (showStory != null)
        {
            showStory.Play();
        } else
        {
            Debug.Log("Need to add director for the star");
        }
    }
}
