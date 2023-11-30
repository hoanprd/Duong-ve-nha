using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayFadeIn());
    }

    IEnumerator DelayFadeIn()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MenuScene");
    }
}
