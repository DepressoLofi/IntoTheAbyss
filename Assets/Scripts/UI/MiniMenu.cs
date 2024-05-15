using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniMenu : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SaveSystem.SaveData(GameManager.Instance, SaveID.saveID);
        SceneManager.LoadScene("0-0_MainMenu");
    }
}
