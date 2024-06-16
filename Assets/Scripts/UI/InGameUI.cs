using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public TextMeshProUGUI starText;
    public int starCount = 0;
    public int heart = 3;

    public GameObject menu;
    public CanvasGroup Display;

    public GameObject heartOne;
    public GameObject heartTwo;
    public GameObject heartThree;

    private void Start()
    {
        UpdateScore();
        UpdateHeartCount(heart);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameStateManager.Instance.gamePaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
        
    }

    public void IncreaseStarCount(int starCollected)
    {
        starCount = starCollected;
        UpdateScore();
    }

    public void UpdateScore()
    {
        if (starText != null)
        {
            starText.text = "x " + starCount.ToString();
        }
    }

    public void UpdateHeartCount(int life)
    {
        heart = life; 

        switch (heart)
        {
            case 0:
                heartThree.SetActive(false);
                heartTwo.SetActive(false);
                heartOne.SetActive(false);
                break;
            case 1:
                heartThree.SetActive(false);
                heartTwo.SetActive(false);
                heartOne.SetActive(true);
                break;
            case 2:
                heartThree.SetActive(false);
                heartTwo.SetActive(true);
                heartOne.SetActive(true);
                break;
            case 3:
                heartThree.SetActive(true);
                heartTwo.SetActive(true);
                heartOne.SetActive(true);
                break;
        }
    }

    private void Pause()
    {
        Cursor.visible = true;
        menu.SetActive(true);
        Time.timeScale = 0f;
        GameStateManager.Instance.Pause();
    }

    private void Resume()
    {
        Cursor.visible = false;
        menu.SetActive(false);
        Time.timeScale = 1f;
        GameStateManager.Instance.Resume();
    }

    public void ShowUi()
    {
        Display.alpha = 1f;
    }

    public void HideUi()
    {
        Display.alpha = 0f;
    }
}
