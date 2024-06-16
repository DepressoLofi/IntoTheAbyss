using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance = null;

    // related to player
    private GameObject player;
    public bool canInput;
    public bool freeze;
    public bool havePower;

    // related to star and story
    public InGameUI gameUI;

    // related to mini menu
    public bool gamePaused;

    //When Puppy died
    public Animator transition;
    public BgMusic bgm;


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

    public void Resume()
    {
        canInput = true;
        gamePaused = false;
    }

    public void Pause()
    {
        canInput = false;
        gamePaused = true;
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

    public void GameOver()
    {
        
        StartCoroutine(LoadGameOver());
    }

    IEnumerator LoadGameOver()
    {
        bgm.Fade();
        yield return Helpers.GetWait(2f);
        
        transition.SetTrigger("Start");
        yield return Helpers.GetWait(1f);
        Cursor.visible = true;
        SceneManager.LoadScene("DieScene");
    }

    public void InStoryTelling(float storyTime)
    {
        gameUI.HideUi();
        StartCoroutine(StoryTellingTime(storyTime));
    }

    IEnumerator StoryTellingTime(float storyTime)
    {
        yield return Helpers.GetWait(storyTime);
        gameUI.ShowUi();
    }
}
