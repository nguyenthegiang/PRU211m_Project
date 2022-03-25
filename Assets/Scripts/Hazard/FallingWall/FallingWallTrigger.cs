using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingWallTrigger : MonoBehaviour
{
    public GameObject[] spikes;

    Timer timer;
    public bool isTriggered = false;

    private void Awake()
    {
        
    }

    private void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1;
        spikes[0] = GameObject.Find("/FallingWall/spike");
        spikes[1] = GameObject.Find("/FallingWall/spike (1)");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player" && isTriggered == false)
        {

            StartCoroutine(moveSpike());

            GameObject fallingWall = GameObject.Find("FallingWall");
            if (fallingWall == null)
            {
                fallingWall = GameObject.Find("FallingWall(Clone)");
            }
            GameObject wallPivot = GameObject.Find("FallingWall/wallPivot");
            if (wallPivot == null)
            {
                wallPivot = GameObject.Find("FallingWall(Clone)/wallPivot");
            }
            Rigidbody2D rb = fallingWall.GetComponent<Rigidbody2D>();
            fallingWall.transform.RotateAround(wallPivot.transform.position, new Vector3(0,0,1), -20);

            isTriggered = true;
        }
        
    }

    IEnumerator moveSpike()
    {
        foreach(GameObject spike in spikes)
        {
            float spikewidth = spike.GetComponent<Renderer>().bounds.size.x;

            Vector3 targetPosition = new Vector3(spike.transform.position.x + spikewidth/2, spike.transform.position.y, spike.transform.position.z);
            spike.transform.position = Vector3.MoveTowards(spike.transform.position, targetPosition, 1f);
        }
        yield return new WaitForSeconds(1);
    }
}
