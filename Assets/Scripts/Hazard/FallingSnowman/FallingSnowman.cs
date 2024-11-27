using System;
using UnityEngine;

public class FallingSnowman : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    bool fell = false;

    // current position of Snowman (before game start)
    [SerializeField]
    private float posX;
    [SerializeField]
    private float posY;

    // speed of rotation of Snowman
    [SerializeField]
    private float rotationSpeed = 1f;
    // how many degrees Snowman will rotate
    private Quaternion targetRotation;
    // Whether the Snowman should rotate
    private bool shouldRotate = false; 

    void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Platformer":
                {
                    //if Snowman touch Ground
                    StartRotation();
                    break;
                }
            case "Player":
                {
                    // if Snowman hit Player -> Reset Position
                    ResetPosition();
                    break;
                }
        }
    }

    void Update()
    {
        // If the object should rotate
        if (shouldRotate)
        {
            // Smoothly interpolate the current rotation to the target rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // Stop rotating if close enough to the target rotation
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation; // Snap to the target rotation
                shouldRotate = false;
            }
        }
    }

    private void StartRotation()
    {
        // Calculate the target rotation (90 degrees left in 2D, around Z-axis)
        targetRotation = Quaternion.Euler(0, 0, transform.eulerAngles.z + 90);
        shouldRotate = true;
    }

    private void ResetPosition()
    {
        this.rigidbody2D.velocity = Vector2.zero;
        this.rigidbody2D.angularVelocity = 0f;
        this.rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        this.gameObject.transform.position = new Vector3(posX, posY, 0);
        this.gameObject.transform.rotation = Quaternion.identity;
        fell = false;
        shouldRotate = false;
    }

    public void SnowmanFall(Collision2D other)
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
}
