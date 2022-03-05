using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingTrap : MonoBehaviour
{
    [SerializeField]
    GameObject ceilingTrap ;

    Vector3 startPosition;

    private void Start()
    {
        ceilingTrap = (GameObject)Resources.Load(@"Prefabs\CeilingTrap", typeof(GameObject));


        startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(ceilingTrap, startPosition, Quaternion.identity);
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }
}
