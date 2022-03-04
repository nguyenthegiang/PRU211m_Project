using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineBomb : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Breakable")
        {
            
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);

        }
    }
}
