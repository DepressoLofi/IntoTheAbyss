using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseLevel : MonoBehaviour
{
    public string levelName;
    public int levelNum;

    public Button levelButton;

    private void Start()
    {
        if(levelNum == 1)
        {
            if(GameManager.Instance.levelOne == true)
            {
                levelButton.interactable = true;

            } else
            {
                levelButton.interactable = false;
            }
        } else if(levelNum == 2)
        {
            if (GameManager.Instance.levelTwo == true)
            {
                levelButton.interactable = true;
            }
            else
            {
                levelButton.interactable = false;
            }

        } else if (levelNum == 3)
        {
            if (GameManager.Instance.levelThree == true)
            {
                levelButton.interactable = true;
            }
            else
            {
                levelButton.interactable = false;
            }

        } else if(levelNum == 4)
        {
            if (GameManager.Instance.levelFour == true)
            {
                levelButton.interactable = true;
            }
            else
            {
                levelButton.interactable = false;
            }

        } else
        {
            return;
        }
    }
    public void OpenScene()
    {
        SceneManager.LoadScene(levelName);
    }
}
