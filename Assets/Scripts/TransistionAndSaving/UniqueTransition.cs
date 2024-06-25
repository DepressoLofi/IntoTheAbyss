using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UniqueTransition : MonoBehaviour
{

    public Animator transition;
    [SerializeField] string sceneName = "LevelSelection";
    [SerializeField] float waitTime = 2f;
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
        yield return Helpers.GetWait(waitTime);
        SceneManager.LoadScene(sceneName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            FinishScene();
        }
    }
}
