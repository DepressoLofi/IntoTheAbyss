using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{

    public bool levelOne;
    public int levelOneScore;

    public bool levelTwo;
    public int levelTwoScore;

    public bool levelThree;
    public int levelThreeScore;

    public bool levelFour;
    public int levelFourScore;

    public bool allLevel;

    public PlayerData(GameManager GameManager)
    {

        levelOne = GameManager.levelOne;
        levelOneScore = GameManager.levelOneScore;

        levelTwo = GameManager.levelTwo;
        levelTwoScore = GameManager.levelTwoScore;

        levelThree = GameManager.levelThree;
        levelThreeScore = GameManager.levelThreeScore;

        levelFour = GameManager.levelFour;
        levelFourScore = GameManager.levelFourScore;

        allLevel = GameManager.allLevel;

    }
}
