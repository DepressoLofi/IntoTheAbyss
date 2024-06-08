using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    private PlayableDirector timeline;
    [SerializeField] private string sceneName;

    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
        timeline.stopped += OnTimelineStopped;
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        SceneManager.LoadScene(sceneName);
    }
}
