using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject fadeInPanel, fadeOutPanel;
    private bool freezeStatus;

    // Start is called before the first frame update
    void Start()
    {
        freezeStatus = false;
        StartCoroutine(DelayFadeIn());
    }

    public void StartNewGame()
    {
        if (!freezeStatus)
        {
            StartCoroutine(DelayStartGame());
        }
    }

    public void LoadGame()
    {
        if (!freezeStatus)
        {
            StartCoroutine(DelayStartGame());
        }
    }

    IEnumerator DelayStartGame()
    {
        freezeStatus = true;
        fadeOutPanel.SetActive(true);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator DelayFadeIn()
    {
        yield return new WaitForSeconds(2f);
        fadeInPanel.SetActive(false);
    }
}
