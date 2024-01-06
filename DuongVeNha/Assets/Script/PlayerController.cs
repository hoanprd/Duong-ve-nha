using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float move_speed;

    public Camera cam;
    public Transform player;

    public Rigidbody2D rb;
    public Animator animator;

    public GameObject talkButton, doorPasswordFoundButton, glass1FoundButton, glass2FoundButton, banditFoundButton, doorOpenButton, handleFoundButton, boxEmptyFoundButton, flashLightFoundButton, electricStatueFoundButton, loadingPanel;

    public static bool freezeMovement;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayStartMovement());
    }

    // Update is called once per frame
    void Update()
    {
        if (!freezeMovement)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Horizontal", movement.x);

            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1)
            {
                animator.SetFloat("LastX", Input.GetAxisRaw("Horizontal"));
            }

            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }

    void FixedUpdate()
    {
        if (!freezeMovement)
        {
            rb.MovePosition(rb.position + movement * move_speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("npc") && !MainController.chessMiniGame)
        {
            talkButton.SetActive(true);
        }
        else if (collision.CompareTag("doorpassword") && !MainController.doorFloor3HadPick)
        {
            doorPasswordFoundButton.SetActive(true);
        }
        else if (collision.CompareTag("glass1") && !MainController.glass1HadPick)
        {
            glass1FoundButton.SetActive(true);
        }
        else if (collision.CompareTag("glass2") && !MainController.glass2HadPick)
        {
            glass2FoundButton.SetActive(true);
        }
        else if (collision.CompareTag("bandit") && !MainController.banditHadPick)
        {
            banditFoundButton.SetActive(true);
        }
        else if (collision.CompareTag("dooropen") && !MainController.doorFloor3HadPick)
        {
            doorOpenButton.SetActive(true);
        }
        else if (collision.CompareTag("handle") && !MainController.handleHadPick)
        {
            handleFoundButton.SetActive(true);
        }
        else if (collision.CompareTag("boxempty") && !MainController.showEmptyBox2)
        {
            boxEmptyFoundButton.SetActive(true);
        }
        else if (collision.CompareTag("flashlight") && !MainController.flashLightHadPick)
        {
            flashLightFoundButton.SetActive(true);
        }
        else if (collision.CompareTag("electricstatue") && !MainController.electricHadFix)
        {
            electricStatueFoundButton.SetActive(true);
        }
        else if (collision.CompareTag("f1tof3"))
        {
            StartCoroutine(DelayLoading());
            player.position = new Vector3(23, 9, -10);
            player.localScale = new Vector3(0.35f, 0.35f, 0.35f);
            cam.transform.position = new Vector3(26, 12, -11);
        }
        else if (collision.CompareTag("f3tof1"))
        {
            StartCoroutine(DelayLoading());
            player.position = new Vector3(15, -4, -10);
            player.localScale = new Vector3(0.18f, 0.18f, 0.18f);
            cam.transform.position = new Vector3(10, -1, -11);
        }
        else if (collision.CompareTag("f1tof2"))
        {
            StartCoroutine(DelayLoading());
            player.position = new Vector3(-6, -7, -10);
            cam.transform.position = new Vector3(-11, -5, -11);
        }
        else if (collision.CompareTag("f2tof1"))
        {
            StartCoroutine(DelayLoading());
            player.position = new Vector3(15, -4, -10);
            cam.transform.position = new Vector3(10, -1, -11);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("npc") && !MainController.chessMiniGame)
        {
            talkButton.SetActive(false);
        }
        else if (collision.CompareTag("doorpassword") && !MainController.doorFloor3HadPick)
        {
            doorPasswordFoundButton.SetActive(false);
        }
        else if (collision.CompareTag("glass1") && !MainController.glass1HadPick)
        {
            glass1FoundButton.SetActive(false);
        }
        else if (collision.CompareTag("glass2") && !MainController.glass2HadPick)
        {
            glass2FoundButton.SetActive(false);
        }
        else if (collision.CompareTag("bandit") && !MainController.banditHadPick)
        {
            banditFoundButton.SetActive(false);
        }
        else if (collision.CompareTag("dooropen") && !MainController.doorFloor3HadPick)
        {
            doorOpenButton.SetActive(false);
        }
        else if (collision.CompareTag("handle") && !MainController.handleHadPick)
        {
            handleFoundButton.SetActive(false);
        }
        else if (collision.CompareTag("boxempty") && !MainController.showEmptyBox2)
        {
            boxEmptyFoundButton.SetActive(false);
        }
        else if (collision.CompareTag("flashlight") && !MainController.flashLightHadPick)
        {
            flashLightFoundButton.SetActive(false);
        }
        else if (collision.CompareTag("electricstatue") && !MainController.electricHadFix)
        {
            electricStatueFoundButton.SetActive(false);
        }
    }

    IEnumerator DelayStartMovement()
    {
        freezeMovement = true;

        yield return new WaitForSeconds(3f);
        freezeMovement = false;
    }

    IEnumerator DelayLoading()
    {
        freezeMovement = true;
        loadingPanel.SetActive(true);

        yield return new WaitForSeconds(3f);
        loadingPanel.SetActive(false);
        freezeMovement = false;
    }
}
