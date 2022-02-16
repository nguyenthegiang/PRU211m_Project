using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class controls a checkpoint
public class CheckPoint : MonoBehaviour
{
    //When MainCharacter passes the Checkpoint
    //-> update the checkpoint of the MainCharacter so that it will respawn here
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject touchedObject = collision.gameObject;
        if (touchedObject.tag == "Player")
        {
             touchedObject.GetComponent<PlayerMovement>().checkPointPassed = transform.position;
        }
    }
}
