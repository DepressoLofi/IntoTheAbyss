using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UniqueTransition : MonoBehaviour
{

    public Animator transition;

    private void FinishScene()
    {
        
        if(UniqueMusic.instance != null)
        {
            UniqueMusic.instance.FadeOutMusic();
        }

        Cursor.visible = true;
        StartCoroutine(LoadLevelSelection());
    }

    IEnumerator LoadLevelSelection()
    {
        transition.SetTrigger("Start");
        yield return Helpers.GetWait(2f);
        SceneManager.LoadScene("LevelSelection");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            FinishScene();
        }
    }
}
