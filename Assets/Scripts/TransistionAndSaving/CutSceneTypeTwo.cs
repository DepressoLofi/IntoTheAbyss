using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutSceneTypeTwo : MonoBehaviour
{
    private PlayableDirector timeline;
    [SerializeField] private string sceneName;
    [SerializeField] private float waitSecond = 1f;
    public BgMusic bgm;


    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
        timeline.stopped += OnTimelineStopped;
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        if(bgm != null)
        {
            bgm.Fade();
        } else if(UniqueMusic.instance != null)
        {
            UniqueMusic.instance.FadeOutMusic();
        }
        
        StartCoroutine(LoadNextScene());
    }
    IEnumerator LoadNextScene()
    {
        yield return Helpers.GetWait(waitSecond);
        SceneManager.LoadScene(sceneName);
    }
}
