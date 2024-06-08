using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private int levelNum;
    private int starCollected;
    [SerializeField] private string scene = "LevelSelection";
    private void LoadLevelSelection()
    {
        GameManager.Instance.LevelComplete(levelNum, starCollected);
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
            LoadLevelSelection();
        }
    }
}
