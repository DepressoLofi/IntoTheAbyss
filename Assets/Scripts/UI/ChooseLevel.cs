using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseLevel : MonoBehaviour
{
    // warning this is the worst code in the game

    public string levelName;
    public int levelNum;

    public Transform[] starSpot = new Transform[3];
    public GameObject starPrefab;
    public GameObject newStarPrefab;

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

        } 

        DisplayStars();
    }


    private void DisplayStars()
    {
        if (levelNum == 1)
        {
            if (GameManager.Instance.levelOne == true)
            {
                for(int i = 0; i < GameManager.Instance.levelOneScore; i++)
                {
                    Instantiate(starPrefab, starSpot[i]);

                }
                if(GameManager.Instance.newStar > 0 && GameManager.Instance.finishedLevel == 1)
                {
                    for (int i = GameManager.Instance.levelOneScore; i < GameManager.Instance.levelOneScore + GameManager.Instance.newStar; i++)
                    {
                        Instantiate(starPrefab, starSpot[i]);


                    }
                    GameManager.Instance.levelOneScore += GameManager.Instance.newStar;
                    GameManager.Instance.newStar = 0;

                }

                
            }
        }
        else if (levelNum == 2)
        {
            if (GameManager.Instance.levelTwo == true)
            {
                for (int i = 0; i < GameManager.Instance.levelTwoScore; i++)
                {
                    Instantiate(starPrefab, starSpot[i]);
                }
                if(GameManager.Instance.newStar > 0 && GameManager.Instance.finishedLevel == 2)
                {
                    for (int i = GameManager.Instance.levelTwoScore; i < GameManager.Instance.levelTwoScore + GameManager.Instance.newStar; i++)
                    {
                        Instantiate(starPrefab, starSpot[i]);


                    }

                    GameManager.Instance.levelTwoScore+= GameManager.Instance.newStar;
                    GameManager.Instance.newStar = 0;
                }
            }


        }
        else if (levelNum == 3)
        {
            if (GameManager.Instance.levelThree == true)
            {
                for (int i = 0; i < GameManager.Instance.levelThreeScore; i++)
                {
                    Instantiate(starPrefab, starSpot[i]);
                }
                if (GameManager.Instance.newStar > 0 && GameManager.Instance.finishedLevel == 3)
                {
                    for (int i = GameManager.Instance.levelThreeScore; i < GameManager.Instance.levelThreeScore + GameManager.Instance.newStar; i++)
                    {
                        Instantiate(starPrefab, starSpot[i]);

                    }

                    GameManager.Instance.levelThreeScore += GameManager.Instance.newStar;
                    GameManager.Instance.newStar = 0;

                }
            }


        }
        else if (levelNum == 4)
        {
            if (GameManager.Instance.levelFour == true)
            {
                for (int i = 0; i < GameManager.Instance.levelFourScore; i++)
                {
                    Instantiate(starPrefab, starSpot[i]);
                }
                if (GameManager.Instance.newStar > 0 && GameManager.Instance.finishedLevel == 4)
                {
                    for (int i = GameManager.Instance.levelFourScore; i < GameManager.Instance.levelFourScore + GameManager.Instance.newStar; i++)
                    {
                        Instantiate(starPrefab, starSpot[i]);

                    }

                    GameManager.Instance.levelFourScore += GameManager.Instance.newStar;
                    GameManager.Instance.newStar = 0;

                }
            }


        }


    }

    public void OpenScene()
    {
        SceneManager.LoadScene(levelName);
    }


}
