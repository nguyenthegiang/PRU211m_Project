using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSnowmanTrigger : MonoBehaviour
{
    // reference to Snowman game object
    [SerializeField]
    private GameObject Snowman;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Fall Snowman when Player touch ground
        FallingSnowman fallingSnowman = Snowman.GetComponent<FallingSnowman>();
        fallingSnowman.SnowmanFall(collision);
    }
}
