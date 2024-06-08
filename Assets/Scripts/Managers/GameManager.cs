using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public bool allLevel = false;

    public int newStar = 0;
    public int finishedLevel;

    public string currentScene;

    public int NewStarGained(int stars, int levelStar)
    {
        if (levelStar < stars) {
            return stars - levelStar;
        }
        return 0;
    }

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
                newStar = NewStarGained(stars, levelOneScore);
                

            }
            levelTwo = true;
            
        } else if (levelNum == 2)
        {
            if (levelTwoScore < stars)
            {
                newStar = NewStarGained(stars, levelTwoScore);
               

            }
            levelThree = true;
            
        } else if(levelNum == 3)
        {
            if (levelThreeScore < stars)
            {
                newStar = NewStarGained(stars, levelThreeScore);
                

            }
            levelFour = true;

        } else if (levelNum == 4)
        {
            if (levelFourScore < stars)
            {
                newStar = NewStarGained(stars, levelFourScore);
                
            }
            allLevel = true;
            
        }
        finishedLevel = levelNum;
        
    }

    public void GetActiveScene()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }
}
