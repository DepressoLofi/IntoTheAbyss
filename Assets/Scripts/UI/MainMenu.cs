using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public BgMusic bgm;
    public void QuitGame()
    {
        bgm.Fade();
        StartCoroutine(QuitTheGame());
    }

    IEnumerator QuitTheGame()
    {
        transition.SetTrigger("Start");

        yield return Helpers.GetWait(1f);

        Application.Quit();
    }

}
