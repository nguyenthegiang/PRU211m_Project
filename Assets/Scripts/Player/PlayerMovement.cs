using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Movement & actions of MainCharacter
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
  
    Timer timer;

    //the checkpoint at which the Character will respawn
    public Vector3 checkPointPassed;

    // Start is called before the first frame update
    void Start()
    {
        //init heart manager
        heartManager = gameObject.GetComponent<HeartManager>();
        timer = gameObject.AddComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, isJumping);
        isJumping = false;
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if touch a Hazard -> die
        if (collision.gameObject.tag == "Hazard")
        {
            animator.SetBool("dead", true);
            StartCoroutine(waiter());
        }
    }

    //Use for Delay in Death animation
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("dead", false);

        if (heartManager.health > 0)
        {
            //respawn in checkpoint if still have HP
            CheckpointRespawn();
        }
        else
        {
            //endgame if out of HP
            fullRespawn();
        }
    }

    //respawn mainCharacter at checkPoint (when still have hearts left)
    void CheckpointRespawn()
    {
        //respawn
        transform.position = new Vector3(checkPointPassed.x, checkPointPassed.y, 0);
        //minus HP
        heartManager.MinusHeart();
    }

    //respawn mainCharacter at the beginning of the game (when out of hearts)
    void fullRespawn()
    {
        //respawn
        transform.position = new Vector3(-11.2f, 3.45f, 0);
        //restore HP
        heartManager.RestoreHealth();
    }
}
