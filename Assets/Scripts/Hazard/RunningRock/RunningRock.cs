using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningRock : MonoBehaviour
{
    [SerializeField]
    public float thrust;

    //for recreate rock
    private GameObject RunningRockPrefab;

    void Start()
    {
        RunningRockPrefab = (GameObject)Resources.Load(@"Prefabs\RunningRock");

        Rigidbody2D rd2d = gameObject.GetComponent<Rigidbody2D>();
        rd2d.AddForce(transform.right * thrust);
        rd2d.AddForce(transform.right * thrust, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //When kill mainCharacter -> Destroy & Recreate the Rock
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(RunningRockPrefab, new Vector3(13.54f, 0.69f), Quaternion.identity);
        }
    }
}
