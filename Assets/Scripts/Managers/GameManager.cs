using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    public bool levelOne = true;
    public int levelOneScore = 0;

    public bool levelTwo = false;
    public int levelTwoScore = 0;

    public bool levelThree = false;
    public int levelThreeScore = 0;

    public bool levelFour = false;
    public int levelFourScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void LevelComplete(int levelNum,int stars)
    {
        if(levelNum == 1)
        {
            if (levelOneScore < stars)
            {
                levelOneScore = stars;
            }
            levelTwo = true;
            
        } else if (levelNum == 2)
        {
            if (levelTwoScore < stars)
            {
                levelTwoScore = stars;
            }
            levelThree = true;
            
        } else if(levelNum == 3)
        {
            if (levelThreeScore < stars)
            {
                levelThreeScore = stars;
            }
            levelFour = true;

        } else if (levelNum == 4)
        {
            if (levelFourScore < stars)
            {
                levelFourScore = stars;
            }
            
        }
        else
        {
            return;
        }


    }
}
