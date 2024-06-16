using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private int levelNum;
    private int starCollected;
    [SerializeField] private string scene = "LevelSelection";

    public Animator transition;
    public BgMusic bgm;

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
