using System;
using UnityEngine;

public class FallingSnowman : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    bool fell = false;

    // current position of Snowman (before game start)
    public float posX;
    public float posY;

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (!fell)
        {
            if (other.gameObject.tag == "Player")
            {
                //change type body of rock to dynamic (can be effected by gravity) -> Starts falling
                rigidbody2D.isKinematic = false;
                rigidbody2D.gravityScale = 4f;
                fell = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Platformer":
                {
                    //if Snowman touch Ground
                    gameObject.tag = "Untagged";
                    break;
                }
            case "Player":
                {
                    // if Snowman hit Player -> Reset Position
                    resetPosition();
                    break;
                }
        }
    }

    private void resetPosition()
    {
        this.rigidbody2D.velocity = Vector2.zero;
        this.rigidbody2D.angularVelocity = 0f;
        this.rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        this.gameObject.transform.position = new Vector3(posX, posY, 0);
        this.gameObject.transform.rotation = Quaternion.identity;
        fell = false;
    }
}
