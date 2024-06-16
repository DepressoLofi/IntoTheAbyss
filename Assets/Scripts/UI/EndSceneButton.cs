using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneButton : MonoBehaviour
{
    public Button button;
    public BgMusic bgm;
    public Animator transition;

    // Start is called before the first frame update
    void Awake()
    {
        if(GameManager.Instance.allLevel == true)
        {
            button.interactable = true;
        } else
        {
            button.interactable = false;
        }
        
    }

    public void ClickEndScene()
    {
        bgm.Fade();
        StartCoroutine(LoadEndScene());
    }

    IEnumerator LoadEndScene()
    {
        transition.SetTrigger("Start");

        yield return Helpers.GetWait(1f);

        SceneManager.LoadScene("5-1_StickScene");
    }
}
