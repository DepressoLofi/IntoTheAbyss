using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniMenu : MonoBehaviour
{
    public GameObject mini;

    
    public AudioMixer audioMixer;
    public Slider bgmSlider;
    public Slider sfxSlider;

    private const string bgmKey = "bgm";
    private const string sfxKey = "sfx";

    void Start()
    {
        if (PlayerPrefs.HasKey(bgmKey))
        {
            float savedBgm = PlayerPrefs.GetFloat(bgmKey);
            SetBgm(savedBgm);
            bgmSlider.value = savedBgm;
        }
        else
        {
            SetBgm(0f);
        }
        if (PlayerPrefs.HasKey(sfxKey))
        {
            float savedSfx = PlayerPrefs.GetFloat(sfxKey);
            SetSfx(savedSfx);
            sfxSlider.value = savedSfx;
        }
        else
        {
            SetSfx(0f);
        }

    }

    

    public void ResumeGame()
    {
        mini.SetActive(false);
        Time.timeScale = 1f;
        GameStateManager.Instance.Resume();

    }

    public void BackToLevelSelection()
    {
        // TODO:: add scene transition in mini menu back to selection
        SceneManager.LoadScene("LevelSelection");
    }

    public void BackToMainMenu()
    {
        // TODO:: add scene transition in mini menu back to main menu
        SaveSystem.SaveData(GameManager.Instance, SaveID.saveID);
        SceneManager.LoadScene("0-0_MainMenu");
    }

    
    public void SetBgm(float volume)
    {
        audioMixer.SetFloat("bgm", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(bgmKey, volume);
        PlayerPrefs.Save();
    }

    public void SetSfx(float volume)
    {
        audioMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(sfxKey, volume);
        PlayerPrefs.Save();
    }
    

}
