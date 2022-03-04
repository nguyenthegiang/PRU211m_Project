using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningRock : MonoBehaviour
{
    [SerializeField]
    public float thrust;

    void Start()
    {
        Rigidbody2D rd2d = gameObject.GetComponent<Rigidbody2D>();
        rd2d.AddForce(transform.right * thrust);
        rd2d.AddForce(transform.right * thrust, ForceMode2D.Impulse);
    }
}
