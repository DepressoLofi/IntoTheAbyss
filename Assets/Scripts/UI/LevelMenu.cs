using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public Animator transition;
    public GameObject Modal;
    public BgMusic bgm;

    private void Start()
    {
        SaveSystem.SaveData(GameManager.Instance, SaveID.saveID);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MiniMenu();
        }
    }

    public void MiniMenu()
    {
        if (Modal != null)
        {
            Modal.SetActive(!Modal.activeSelf);
        }
    }

    public void Back()
    {
        SaveSystem.SaveData(GameManager.Instance, SaveID.saveID);
        bgm.Fade();
        StartCoroutine(BackToMainMenu());
    }

    IEnumerator BackToMainMenu()
    {
        transition.SetTrigger("Start");

        yield return Helpers.GetWait(1f);

        SceneManager.LoadScene("0-0_MainMenu");
    }
}
