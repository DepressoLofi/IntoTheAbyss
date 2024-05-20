using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance = null;

    private GameObject player;

    public bool canInput;
    public bool freeze;
    public bool havePower;

    public bool storyTelling;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        GameObject puppyObject = GameObject.Find("Puppy");
        if (puppyObject != null )
        {
            player = puppyObject;
        }
        
    }

    public void IntroScene()
    {
        havePower = false;
    }

    public void BackToNormal()
    {
        canInput = true;
    }

    public void InCutscene()
    {
        canInput = false;
    }

    public void PuppyDied()
    {
        canInput = false;
        freeze = true;
        player.transform.SetParent(null);

    }

    public void PuppyRevived()
    {
        canInput = true;
        freeze = false;

    }

    public void InStoryTelling()
    {
        storyTelling = true;
        StartCoroutine(storyTellingTime());
    }

    IEnumerator storyTellingTime()
    {
        yield return Helpers.GetWait(2f);
        storyTelling = false;
    }
}
