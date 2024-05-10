using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{
    public string levelName;

    public void OpenScene()
    {
        SceneManager.LoadScene(levelName);
    }
}
