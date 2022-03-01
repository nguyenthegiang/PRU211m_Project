using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterMovement : PlayerMovement
{
    public float speed = 5f;

    float horizontalMove;
    float verticalMove;
    bool m_FacingRight = true;
    Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        if (horizontalMove > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontalMove < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        Vector3 moveVector = new Vector3(horizontalMove, verticalMove, 0);
        body.velocity = moveVector.normalized * speed;
    }

    void FixedUpdate()
    {
        
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
