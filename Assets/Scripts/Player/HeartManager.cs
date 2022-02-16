using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public GameObject[] hearts;
    [SerializeField]
    public Sprite fullHealth;
    [SerializeField]
    public Sprite emptyHealth;

    public void ChangeHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].GetComponent<SpriteRenderer>().enabled = true;
                //hearts[i].GetComponent<SpriteRenderer>().sprite = fullHealth;
            }
            else
            {
                //hearts[i].GetComponent<SpriteRenderer>().sprite = emptyHealth;
                hearts[i].GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}
