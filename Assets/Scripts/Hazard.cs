using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject touchedCharacter = collision.gameObject;
        if (touchedCharacter.tag == "Player")
        {
            //Destroy(touchedCharacter);
            touchedCharacter.transform.position = new Vector3(-11.2f, 3.45f, 0);
        }
    }
}
