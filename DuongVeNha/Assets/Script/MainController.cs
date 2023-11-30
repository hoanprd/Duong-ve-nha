using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject loadingPanel, dialogPanel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayLoading());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NPCTalk()
    {
        PlayerController.freezeMovement = true;
        dialogPanel.SetActive(true);
    }

    public void EndDialog()
    {
        dialogPanel.SetActive(false);
        PlayerController.freezeMovement = false;
    }

    IEnumerator DelayLoading()
    {
        yield return new WaitForSeconds(3f);
        loadingPanel.SetActive(false);
    }
}
