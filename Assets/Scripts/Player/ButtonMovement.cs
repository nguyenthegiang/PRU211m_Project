using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    //move main character to the left
    public void MoveLeft()
    {
        GameObject mainCharacter = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement pm = mainCharacter.GetComponent<PlayerMovement>();
        pm.moveHorizontal(-1);
    }
}
