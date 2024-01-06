using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float move_speed;

    public Rigidbody2D rb;
    public Animator animator;

    public GameObject talkButton, doorPasswordFoundButton, glass1FoundButton, glass2FoundButton, banditFoundButton, doorOpenButton, handleFoundButton, boxEmptyFoundButton;

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
        else if (collision.CompareTag("doorpassword"))
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
    }

    IEnumerator DelayStartMovement()
    {
        freezeMovement = true;

        yield return new WaitForSeconds(3f);
        freezeMovement = false;
    }
}
