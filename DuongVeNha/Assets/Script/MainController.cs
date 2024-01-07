using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public Animator banditBoxAni, emptyBoxAni, treeHidePasswordAni, catMiniGameAni, waterTapAni, waterTree1Ani, waterTree2Ani, waterTree3Ani, poleAni, bansinAni;

    public Transform bagParent;
    public GameObject talkButton, doorPasswordFoundButton, glass1FoundButton, glass2FoundButton, banditFoundButton, doorOpenButton, handleFoundButton, boxEmptyFoundButton, flashLightFoundButton, electricStatueFoundButton, waterTankFoundButton, doorFloor4FoundButton, npc2TalkButton, waterTapFoundButton, waterTreeFoundButton, bansinFoundButton, doorPasswordCollider;
    public GameObject loadingPanel, dialogPanel, dialog2Panel, dialog3Panel, glass1Prefab, glass2Prefab, glassFullPrefab, banditPrefab, handlePrefab, secretMapPrefab, flashLightPrefab, waterTankPrefab, waterTankFullPrefab, hookPrefab, keyFloor4Prefab;
    public GameObject glass1Sprite, glass2Sprite, handleSprite, flashLightSprite, waterTankSprite, waterTankFullSprite, gameLog, bagHud, catMiniGamePanel, passwordZoomPanel, playChessPanel, doorOpenFloor3Panel, secretMapPanel, eletricStatuePanel;

    public GameObject catGame, miniGameBox2, miniGameBox3, miniGameBox2Done, miniGameBox3Done, food1Game, food2Game, doorLock, doorOpen;

    public GameObject floor3BG, electricStatue, eletricFixShow, electricFixButon;

    public InputField doorInput;

    public Transform catOldPosition, miniGameBox2OldPosition, miniGameBox3OldPosition;

    public static bool catMiniGame, showEmptyBox1, showEmptyBox2, treePushHidePassword, glassFix, chessMiniGame;
    public static bool glass1HadPick, glass2HadPick, banditHadPick, handleHadPick, doorFloor3HadPick, flashLightHadPick, electricHadFix, waterTankHadPick, waterTapHadRun, waterTankFullHadPick, waterTreeHadDone, poleHadDone, keyFloor4HadPick;
    public static bool banditUse, secretMapUse;

    private bool showBandit, box2Done, box3Done, food1Done, food2Done;
    private int bagStatus;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayLoading());

        //floor3BG.GetComponent<Renderer>().material.color = Color.red;

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
            ContainerController.contentQuanity -= 2;
            glassFix = true;
            Instantiate(glassFullPrefab, bagParent);
        }
        else if (secretMapUse)
        {
            PlayerController.freezeMovement = true;
            secretMapUse = false;
            secretMapPanel.SetActive(true);
        }

        /*if (flashLightHadPick)
        {
            electricStatue.GetComponent<Image>().color = Color.white;
        }

        if (electricHadFix)
        {
            electricHadFix = false;
            floor3BG.GetComponent<Renderer>().material.color = Color.white;
        }*/
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
            ContainerController.contentQuanity -= 1;
            dialog2Panel.SetActive(true);
        }
    }

    public void glass1Pick()
    {
        if (ContainerController.contentQuanity < 7)
        {
            glass1HadPick = true;
            glass1FoundButton.SetActive(false);
            Destroy(glass1Sprite);
            ContainerController.glass1 += 1;
            ContainerController.contentQuanity += 1;
            Instantiate(glass1Prefab, bagParent);
        }
        else if (ContainerController.contentQuanity >= 7)
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
            if (ContainerController.contentQuanity < 7)
            {
                banditHadPick = true;
                banditBoxAni.SetTrigger("takebandit");
                banditFoundButton.SetActive(false);
                ContainerController.bandit += 1;
                ContainerController.contentQuanity += 1;
                Instantiate(banditPrefab, bagParent);
            }
            else if (ContainerController.contentQuanity >= 7)
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
        if (ContainerController.contentQuanity < 7)
        {
            handleHadPick = true;
            handleFoundButton.SetActive(false);
            Destroy(handleSprite);
            ContainerController.handle += 1;
            ContainerController.contentQuanity += 1;
            Instantiate(handlePrefab, bagParent);
        }
        else if (ContainerController.contentQuanity >= 7)
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

    public void FlashLightPick()
    {
        if (ContainerController.contentQuanity < 7)
        {
            flashLightHadPick = true;
            flashLightFoundButton.SetActive(false);
            Destroy(flashLightSprite);
            ContainerController.flashLight += 1;
            ContainerController.contentQuanity += 1;
            Instantiate(flashLightPrefab, bagParent);
        }
        else if (ContainerController.contentQuanity >= 7)
        {
            StopAllCoroutines();
            gameLog.SetActive(true);
            gameLog.GetComponent<Text>().text = "Đã chật slot túi đồ";
            StartCoroutine(DelayGameLog());
        }
    }

    public void ElectricStatueShow()
    {
        PlayerController.freezeMovement = true;
        eletricStatuePanel.SetActive(true);

        if (flashLightHadPick)
        {
            electricFixButon.SetActive(true);
            electricStatue.GetComponent<Image>().color = Color.white;
        }
    }

    public void WaterTankPick()
    {
        if (ContainerController.contentQuanity < 7)
        {
            waterTankHadPick = true;
            waterTankFoundButton.SetActive(false);
            Destroy(waterTankSprite);
            ContainerController.waterTank += 1;
            ContainerController.contentQuanity += 1;
            Instantiate(waterTankPrefab, bagParent);
        }
        else if (ContainerController.contentQuanity >= 7)
        {
            StopAllCoroutines();
            gameLog.SetActive(true);
            gameLog.GetComponent<Text>().text = "Đã chật slot túi đồ";
            StartCoroutine(DelayGameLog());
        }
    }

    public void NPC2Talk()
    {

    }

    public void WaterTapOpen()
    {
        if (waterTankHadPick && !waterTapHadRun)
        {
            waterTapAni.SetTrigger("waterfull");
            //waterTapFoundButton.SetActive(false);
            ContainerController.waterTank -= 1;
            ContainerController.contentQuanity -= 1;
            StartCoroutine(DelayWaterTankFull());
        }
        else if (waterTankHadPick && waterTapHadRun)
        {
            waterTankFullHadPick = true;
            waterTapFoundButton.SetActive(false);
            Destroy(waterTankFullSprite);
            ContainerController.waterTankFull += 1;
            ContainerController.contentQuanity += 1;
            Instantiate(waterTankFullPrefab, bagParent);
        }
    }

    public void WaterTree()
    {
        if (waterTankFullHadPick)
        {
            waterTreeFoundButton.SetActive(false);
            ContainerController.waterTankFull -= 1;
            ContainerController.contentQuanity -= 1;
            StartCoroutine(DelayWatering());
        }
    }

    public void PoleDoing()
    {
        if (waterTreeHadDone && !poleHadDone)
        {
            poleHadDone = true;
            ContainerController.hook -= 1;
            ContainerController.contentQuanity -= 1;
            poleAni.SetTrigger("polerun");
            bansinAni.SetTrigger("bansinrun");
        }
        else if (waterTreeHadDone && poleHadDone)
        {
            if (ContainerController.contentQuanity < 7)
            {
                keyFloor4HadPick = true;
                bansinFoundButton.SetActive(false);
                poleAni.SetTrigger("takekey");
                ContainerController.keyFloor4 += 1;
                ContainerController.contentQuanity += 1;
                Instantiate(keyFloor4Prefab, bagParent);
            }
            else if (ContainerController.contentQuanity >= 7)
            {
                StopAllCoroutines();
                gameLog.SetActive(true);
                gameLog.GetComponent<Text>().text = "Đã chật slot túi đồ";
                StartCoroutine(DelayGameLog());
            }
        }    
    }

    public void OpenDoorFloor4()
    {
        
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
            ContainerController.contentQuanity += 1;
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
            if (ContainerController.contentQuanity < 7)
            {
                glass2HadPick = true;
                catMiniGame = true;
                glass2FoundButton.SetActive(false);
                Destroy(glass2Sprite);
                ContainerController.glass2 += 1;
                ContainerController.contentQuanity += 1;
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

    public void FixElectric()
    {
        if (handleHadPick)
        {
            electricHadFix = true;
            electricStatueFoundButton.SetActive(false);
            floor3BG.SetActive(false);
            ContainerController.handle -= 1;
            ContainerController.contentQuanity -= 1;
            electricStatue.SetActive(false);
            eletricFixShow.SetActive(true);
            StartCoroutine(DelayElectricFix());
        }
    }

    public void CloseFixElectric()
    {
        eletricStatuePanel.SetActive(false);
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

    IEnumerator DelayElectricFix()
    {
        yield return new WaitForSeconds(2f);
        eletricStatuePanel.SetActive(false);
        PlayerController.freezeMovement = false;
    }

    IEnumerator DelayWaterTankFull()
    {
        yield return new WaitForSeconds(1f);
        waterTapHadRun = true;
    }

    IEnumerator DelayWatering()
    {
        PlayerController.freezeMovement = true;
        waterTree1Ani.SetTrigger("watertree1");

        yield return new WaitForSeconds(1f);
        waterTree2Ani.SetTrigger("watertree2");

        yield return new WaitForSeconds(1f);
        waterTree3Ani.SetTrigger("watertree3");

        yield return new WaitForSeconds(0.5f);
        PlayerController.freezeMovement = false;
        waterTreeHadDone = true;
        ContainerController.hook += 1;
        ContainerController.contentQuanity += 1;
        Instantiate(hookPrefab, bagParent);
    }
}
