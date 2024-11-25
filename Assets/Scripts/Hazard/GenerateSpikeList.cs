using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpikeList : MonoBehaviour
{
    public GameObject spikePrefab;

    // position of the spike list
    public float posX;
    public float posY;

    // space (horizontal) between each spike to make the list
    public float space;

    // number of spike in the list
    public int spikeCount;

    // Start is called before the first frame update
    void Awake()
    {
        SpikeListSpawn();   
    }

    void SpikeListSpawn()
    {
        for (int i = 0; i < spikeCount; i++)
        {
            Instantiate(spikePrefab, new Vector3(posX, posY, 0), Quaternion.identity);
            posX += space;
        }
    }
}
