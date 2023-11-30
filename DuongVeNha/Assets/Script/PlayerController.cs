using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float move_speed;

    public Rigidbody2D rb;
    public Animator animator;

    public GameObject talkButton;

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
        if (collision.CompareTag("npc"))
        {
            talkButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("npc"))
        {
            talkButton.SetActive(false);
        }
    }

    IEnumerator DelayStartMovement()
    {
        freezeMovement = true;

        yield return new WaitForSeconds(3f);
        freezeMovement = false;
    }
}
