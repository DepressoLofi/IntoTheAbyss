using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private int levelNum;
    private int starCollected;

    [SerializeField] private string scene = "LevelSelection";
    [SerializeField] private float waitSecond = 1f;

    public Animator transition;
    public BgMusic bgm;

    public PlayableDirector showStory;

    private void FinishLevel()
    {
        GameManager.Instance.LevelComplete(levelNum, starCollected);
        bgm.Fade();
        Cursor.visible = true;
        StartCoroutine(LoadLevelSelection());
    }

    IEnumerator LoadLevelSelection()
    {
        transition.SetTrigger("Start");
        yield return Helpers.GetWait(1f);
        if (showStory != null)
        {
            showStory.Play();
        }
        yield return Helpers.GetWait(waitSecond);
        SceneManager.LoadScene(scene);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Puppy puppy = other.GetComponent<Puppy>();
            if (puppy != null)
            {
                starCollected = puppy.star;   
            }
            FinishLevel();
        }
    }
}
