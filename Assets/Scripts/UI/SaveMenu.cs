using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveMenu : MonoBehaviour
{
    public GameObject[] newGameButtons = new GameObject[3];
    public GameObject[] loadGameButtons = new GameObject[3];

    public int[] saveIds = new int[3];


    private void Update()
    {
        for(int i = 0; i < newGameButtons.Length; i++)
        {
            if (SaveSystem.DoesSaveExist(saveIds[i]))
            {
                newGameButtons[i].SetActive(false);
                loadGameButtons[i].SetActive(true);
            } else
            {
                newGameButtons[i].SetActive(true);
                loadGameButtons[i].SetActive(false);
            }
        }
        
    }

    public void NewGame()
    {
        GameManager.Instance.levelOne = true; 
        GameManager.Instance.levelTwo = false;
        GameManager.Instance.levelThree = false;
        GameManager.Instance.levelFour = false;

        GameManager.Instance.levelOneScore = 0;
        GameManager.Instance.levelTwoScore = 0;
        GameManager.Instance.levelThreeScore = 0;
        GameManager.Instance.levelFourScore = 0;


        SceneManager.LoadScene("LevelSelection");
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadData(SaveID.saveID);

        if(data != null)
        {
            GameManager.Instance.levelTwo = data.levelTwo;
            GameManager.Instance.levelThree = data.levelThree;
            GameManager.Instance.levelFour = data.levelFour;

            GameManager.Instance.levelOneScore = data.levelOneScore;
            GameManager.Instance.levelTwoScore = data.levelTwoScore;
            GameManager.Instance.levelThreeScore = data.levelThreeScore;
            GameManager.Instance.levelFourScore = data.levelFourScore;

        }

        SceneManager.LoadScene("LevelSelection");
    }

    public void SetSaveID(int saveID)
    {
        SaveID.saveID = saveID;

    }
}
