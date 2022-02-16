using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public CharacterController2D controller;
    [SerializeField]
    public float runSpeed = 30f;
    [SerializeField]
    public Animator animator;
    [SerializeField]
    public HeartManager heartManager;

    float horizontalMove = 0f;
    bool isJumping = false;
    bool isJumpKeyReleased = true;
    private float jumpTimeCounter;
    public float jumpTime;
    // Start is called before the first frame update
    void Start()
    {
        //init heart manager
        heartManager = gameObject.GetComponent<HeartManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
        if (Input.GetButton("Jump") && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                jumpTimeCounter -= Time.fixedDeltaTime;
            } else
            {
                isJumping = false;
            }
        }

    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, isJumping);
        //isJumping = false;
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            heartManager.health--;
            heartManager.ChangeHearts();
        }
        //End game if go out of hearts
        if (heartManager.health <= 0)
        {
            Application.Quit();
        }
    }
}
