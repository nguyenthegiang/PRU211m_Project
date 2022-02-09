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
    bool jump = false;
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
            jump = true;
            animator.SetBool("isJumping", true);
        }
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, jump);
        jump = false;
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
    }
}
