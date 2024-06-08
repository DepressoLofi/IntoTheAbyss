using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    private void Start()
    {
        SaveSystem.SaveData(GameManager.Instance, SaveID.saveID);
    }
    public void Back()
    {
        SaveSystem.SaveData(GameManager.Instance, SaveID.saveID);
        SceneManager.LoadScene("0-2_SaveSlot");
    }

    public void Ending()
    {

    }
}
