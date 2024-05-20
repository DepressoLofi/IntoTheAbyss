using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public TextMeshProUGUI starText;
    public int starCount = 0;

    public GameObject MiniMenu;

    private void Start()
    {
        UpdateScore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMiniMenu();
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
            starText.text = "Star: " + starCount.ToString();
        }
    }

    private void OpenMiniMenu()
    {
        MiniMenu.SetActive(!MiniMenu.activeSelf);
    }
}
