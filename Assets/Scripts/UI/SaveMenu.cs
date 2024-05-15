using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveMenu : MonoBehaviour
{
    public GameObject[] newGameButtons = new GameObject[3];
    public GameObject[] loadGameButtons = new GameObject[3];
    public TextMeshProUGUI[] levelNum = new TextMeshProUGUI[3];
    public TextMeshProUGUI[] starNum = new TextMeshProUGUI[3];

    public int[] saveIds = new int[3];

    public Animator transition;
    public GameObject Modal;
    public BgMusic bgm;

    private void Update()
    {
        for(int i = 0; i < newGameButtons.Length; i++)
        {
            if (SaveSystem.DoesSaveExist(saveIds[i]))
            {
                newGameButtons[i].SetActive(false);
                loadGameButtons[i].SetActive(true);
                ShowData(i);
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
        GameManager.Instance.allLevel = false;

        GameManager.Instance.levelOneScore = 0;
        GameManager.Instance.levelTwoScore = 0;
        GameManager.Instance.levelThreeScore = 0;
        GameManager.Instance.levelFourScore = 0;

        bgm.Fade();
        StartCoroutine(LoadNextLevel("0-1_FirstScene"));
        
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadData(SaveID.saveID);

        if(data != null)
        {
            GameManager.Instance.levelOne = data.levelOne;
            GameManager.Instance.levelTwo = data.levelTwo;
            GameManager.Instance.levelThree = data.levelThree;
            GameManager.Instance.levelFour = data.levelFour;
            GameManager.Instance.allLevel = data.allLevel;

            GameManager.Instance.levelOneScore = data.levelOneScore;
            GameManager.Instance.levelTwoScore = data.levelTwoScore;
            GameManager.Instance.levelThreeScore = data.levelThreeScore;
            GameManager.Instance.levelFourScore = data.levelFourScore;

        }

        bgm.Fade();
        StartCoroutine(LoadNextLevel("LevelSelection"));
    }


    public void ShowData(int id)
    {
        PlayerData data = SaveSystem.LoadData(saveIds[id]);

        int starCount = 0;
        int levelCount = 0;

        if (data.levelTwo) levelCount++;
        if (data.levelThree) levelCount++;
        if (data.levelFour) levelCount++;
        if (data.allLevel) levelCount++;

        starCount = data.levelOneScore + data.levelTwoScore + data.levelThreeScore + data.levelFourScore;   


        levelNum[id].text = levelCount.ToString();
        starNum[id].text = starCount.ToString();

    }

    public void ClearData()
    {
        SaveSystem.ClearData(SaveID.saveID);
        Modal.SetActive(false);

    }

    public void ToggleModal()
    {
        if (Modal != null)
        {
            Modal.SetActive(!Modal.activeSelf);
        }

    }



    public void SetSaveID(int saveID)
    {
        SaveID.saveID = saveID;

    }

    IEnumerator LoadNextLevel(string level)
    {
        transition.SetTrigger("Start");

        yield return Helpers.GetWait(1f);

        SceneManager.LoadScene(level);
    }
}
