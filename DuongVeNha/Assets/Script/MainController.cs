using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public Animator banditBoxAni, emptyBoxAni, treeHidePasswordAni, catMiniGameAni;

    public Transform bagParent;
    public GameObject talkButton, doorPasswordFoundButton, glass1FoundButton, glass2FoundButton, banditFoundButton, doorOpenButton, handleFoundButton, boxEmptyFoundButton, doorPasswordCollider;
    public GameObject loadingPanel, dialogPanel, dialog2Panel, dialog3Panel, glass1Prefab, glass2Prefab, glassFullPrefab, banditPrefab, handlePrefab, secretMapPrefab;
    public GameObject glass1Sprite, glass2Sprite, handleSprite, gameLog, bagHud, catMiniGamePanel, passwordZoomPanel, playChessPanel, doorOpenFloor3Panel, secretMapPanel;

    public GameObject catGame, miniGameBox2, miniGameBox3, miniGameBox2Done, miniGameBox3Done, food1Game, food2Game, doorLock, doorOpen;

    public InputField doorInput;

    public Transform catOldPosition, miniGameBox2OldPosition, miniGameBox3OldPosition;

    public static bool catMiniGame, showEmptyBox1, showEmptyBox2, treePushHidePassword, glassFix, chessMiniGame;
    public static bool glass1HadPick, glass2HadPick, banditHadPick, handleHadPick, doorFloor3HadPick;
    public static bool banditUse, secretMapUse;

    private bool showBandit, box2Done, box3Done, food1Done, food2Done;
    private int bagStatus;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayLoading());

        //catOldPosition.position = catGame.transform.position;
        //miniGameBox2OldPosition.position = miniGameBox2.transform.position;
        //miniGameBox3OldPosition.position = miniGameBox3.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (banditUse)
        {
            banditUse = false;
            ContainerController.bandit -= 1;
            ContainerController.glass1 -= 1;
            ContainerController.glass2 -= 1;
            ContainerController.glassFull += 1;
            glassFix = true;
            Instantiate(glassFullPrefab, bagParent);
        }
        else if (secretMapUse)
        {
            PlayerController.freezeMovement = true;
            secretMapUse = false;
            secretMapPanel.SetActive(true);
        }
    }

    public void EnterPasswordDoor()
    {
        if (doorInput.text == "523416")
        {
            Destroy(doorPasswordCollider);
            doorFloor3HadPick = true;
            doorOpenButton.SetActive(false);
            doorOpenFloor3Panel.SetActive(false);
            doorLock.SetActive(false);
            doorOpen.SetActive(true);
            PlayerController.freezeMovement = false;
        }
    }

    public void CloseSecretMap()
    {
        secretMapPanel.SetActive(false);
        PlayerController.freezeMovement = false;
    }

    public void NPCTalk()
    {
        PlayerController.freezeMovement = true;
        if (!glassFix)
        {
            dialogPanel.SetActive(true);
        }
        else if (!chessMiniGame && glassFix)
        {
            ContainerController.glassFull -= 1;
            dialog2Panel.SetActive(true);
        }
    }

    public void glass1Pick()
    {
        if (ContainerController.contentQuanity < 5)
        {
            glass1HadPick = true;
            glass1FoundButton.SetActive(false);
            Destroy(glass1Sprite);
            ContainerController.glass1 += 1;
            Instantiate(glass1Prefab, bagParent);
        }
        else if (ContainerController.contentQuanity >= 5)
        {
            StopAllCoroutines();
            gameLog.GetComponent<Text>().text = "Đã chật slot túi đồ";
            StartCoroutine(DelayGameLog());
        }
    }

    public void glass2Pick()
    {
        if (!catMiniGame)
        {
            PlayerController.freezeMovement = true;
            catMiniGamePanel.SetActive(true);
        }
    }

    public void banditPick()
    {
        if (!showBandit)
        {
            banditBoxAni.SetTrigger("showbandit");
            showBandit = true;
        }
        else
        {
            if (ContainerController.contentQuanity < 5)
            {
                banditHadPick = true;
                banditBoxAni.SetTrigger("takebandit");
                banditFoundButton.SetActive(false);
                ContainerController.bandit += 1;
                ContainerController.contentQuanity += 1;
                Instantiate(banditPrefab, bagParent);
            }
            else if (ContainerController.contentQuanity >= 5)
            {
                StopAllCoroutines();
                gameLog.SetActive(true);
                gameLog.GetComponent<Text>().text = "Đã chật slot túi đồ";
                StartCoroutine(DelayGameLog());
            }
        }
    }

    public void HandlePick()
    {
        if (ContainerController.contentQuanity < 5)
        {
            handleHadPick = true;
            handleFoundButton.SetActive(false);
            Destroy(handleSprite);
            ContainerController.handle += 1;
            ContainerController.contentQuanity += 1;
            Instantiate(handlePrefab, bagParent);
        }
        else if (ContainerController.contentQuanity >= 5)
        {
            StopAllCoroutines();
            gameLog.SetActive(true);
            gameLog.GetComponent<Text>().text = "Đã chật slot túi đồ";
            StartCoroutine(DelayGameLog());
        }
    }

    public void TreePush()
    {
        if (!treePushHidePassword)
        {
            treePushHidePassword = true;
            treeHidePasswordAni.SetTrigger("treepush");
        }
        else
        {
            passwordZoomPanel.SetActive(true);
        }
    }

    public void OpenDoorToFloor3()
    {
        PlayerController.freezeMovement = true;
        doorOpenFloor3Panel.SetActive(true);
    }

    public void OpenEmptyBox()
    {
        if (!showEmptyBox1)
        {
            showEmptyBox1 = true;
            emptyBoxAni.SetTrigger("openempty1");
        }
        else if (!showEmptyBox2)
        {
            showEmptyBox2 = true;
            boxEmptyFoundButton.SetActive(false);
            emptyBoxAni.SetTrigger("openempty2");
        }
    }

    public void EndDialog()
    {
        if (!glassFix)
        {
            dialogPanel.SetActive(false);
            PlayerController.freezeMovement = false;
        }
        else if (glassFix && !chessMiniGame)
        {
            dialog2Panel.SetActive(false);
            playChessPanel.SetActive(true);
            StartCoroutine(DelayPlayChessMiniGame());
        }
        else
        {
            talkButton.SetActive(false);
            dialog3Panel.SetActive(false);
            ContainerController.secretMap += 1;
            Instantiate(secretMapPrefab, bagParent);
            PlayerController.freezeMovement = false;
        }
    }

    public void EndPlayChess()
    {
        dialog3Panel.SetActive(false);
        PlayerController.freezeMovement = false;
    }

    public void OpenCloseBagPress()
    {
        bagStatus += 1;
        if (bagStatus % 2 != 0)
        {
            bagHud.SetActive(true);
        }
        else
        {
            bagHud.SetActive(false);
        }
    }

    //MiniGame
    public void Box2Press()
    {
        box2Done = true;
        miniGameBox2.transform.position = miniGameBox2Done.transform.position;
    }

    public void Box3Press()
    {
        box3Done = true;
        miniGameBox3.transform.position = miniGameBox3Done.transform.position;
    }

    public void Food1Press()
    {
        if (box2Done || box3Done)
        {
            StopAllCoroutines();
            catMiniGameAni.SetTrigger("cateat");
            StartCoroutine(CatMiniGameDelay());
            catGame.transform.position = food1Game.transform.position;
            food1Game.SetActive(false);
            food1Done = true;
            CheckCatMiniGameDone();
        }
    }

    public void Food2Press()
    {
        if (box2Done || box3Done)
        {
            StopAllCoroutines();
            catMiniGameAni.SetTrigger("cateat");
            StartCoroutine(CatMiniGameDelay());
            catGame.transform.position = food2Game.transform.position;
            food2Game.SetActive(false);
            food2Done = true;
            CheckCatMiniGameDone();
        }
    }

    public void CloseCatMiniGame()
    {
        catMiniGamePanel.SetActive(false);
    }

    void CheckCatMiniGameDone()
    {
        if (food1Done && food2Done)
        {
            catMiniGamePanel.SetActive(false);
            if (ContainerController.contentQuanity < 5)
            {
                glass2HadPick = true;
                catMiniGame = true;
                glass2FoundButton.SetActive(false);
                Destroy(glass2Sprite);
                ContainerController.glass2 += 1;
                PlayerController.freezeMovement = false;
                Instantiate(glass2Prefab, bagParent);
            }
            /*else if (ContainerController.contentQuanity >= 5)
            {
                StopAllCoroutines();
                gameLog.GetComponent<Text>().text = "Đã chật slot túi đồ";
                catGame.transform.position = catOldPosition.position;
                miniGameBox2.transform.position = miniGameBox2OldPosition.position;
                miniGameBox3.transform.position = miniGameBox3OldPosition.position;
                food1Game.SetActive(true);
                food2Game.SetActive(true);
                food1Done = false;
                food2Done = false;
                StartCoroutine(DelayGameLog());
            }*/
        }
    }

    public void CloseZoomPassword()
    {
        passwordZoomPanel.SetActive(false);
        PlayerController.freezeMovement = false;
    }

    public void CloseEnterPasswordDoorFloor3()
    {
        doorOpenFloor3Panel.SetActive(false);
        PlayerController.freezeMovement = false;
    }

    IEnumerator CatMiniGameDelay()
    {
        yield return new WaitForSeconds(1f);
        catMiniGameAni.SetTrigger("catdone");
    }

    IEnumerator DelayLoading()
    {
        yield return new WaitForSeconds(3f);
        loadingPanel.SetActive(false);
    }

    IEnumerator DelayGameLog()
    {
        yield return new WaitForSeconds(2f);
        gameLog.SetActive(false);
    }

    IEnumerator DelayPlayChessMiniGame()
    {
        yield return new WaitForSeconds(12.5f);
        chessMiniGame = true;
        playChessPanel.SetActive(false);
        dialog3Panel.SetActive(true);
    }
}
