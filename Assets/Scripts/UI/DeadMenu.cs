using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadMenu : MonoBehaviour
{
    public GameObject quoteBox;
    public TextMeshProUGUI quote;

    public string backQuote = "It's okay to rest when you are tired. You can try again tomorrow.";
    public string retryQuote = "Don't give up!";

    public BgMusic bgm;

    public Animator transition;

    private void Start()
    {
        quoteBox.SetActive(false);
        quote.text = "";
    }

    public void RetryClick()
    {
        bgm.Fade();
        StartCoroutine(ChangeScene(GameManager.Instance.currentScene));
    }

    public void BackClick()
    {
        bgm.Fade();
        StartCoroutine(ChangeScene("LevelSelection"));
    }

    public void RetryHover()
    {
        quoteBox.SetActive(true);
        quote.text = retryQuote;
    }

    public void BackHover()
    {
        quoteBox.SetActive(true);
        quote.text = backQuote;
    }

    public void ButtonExit()
    {
        quoteBox.SetActive(false);
        quote.text = "";
    }

    IEnumerator ChangeScene(string sceneName)
    {
        transition.SetTrigger("Start");

        yield return Helpers.GetWait(1.2f);

        SceneManager.LoadScene(sceneName);
    }


}
