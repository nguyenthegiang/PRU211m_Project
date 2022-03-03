using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    //this is the point to rotate around
    [SerializeField]
    public GameObject rotationPivot;

    //to check rotate
    bool rotateForward = false;
    bool rotateBack = false;

    //Max position: used to stop rotation
    float maxRotate;
    float minRotate;

    private void Start()
    {
        //find max/min rotate by rotationPivot
        float distance = rotationPivot.transform.position.x - transform.position.x;
        maxRotate = transform.position.x + 2*distance;
        minRotate = transform.position.x;
    }

    private void Update()
    {
        if (rotateForward)
        {
            Vector3 point = rotationPivot.transform.position;
            Vector3 axis = new Vector3(0, 0, 1);
            transform.RotateAround(point, axis, 90 * Time.deltaTime);

            //stop rotate if reach position
            if (transform.position.x >= maxRotate)
            {
                rotateForward = false;
            }

        } else if (rotateBack)
        {
            Vector3 point = rotationPivot.transform.position;
            Vector3 axis = new Vector3(0, 0, 1);
            transform.RotateAround(point, axis, -90 * Time.deltaTime);

            //stop rotate if reach position
            if (transform.position.x <= minRotate)
            {
                rotateBack = false;
            }
        }
        
    }

    public void RotateForward()
    {
        rotateForward = true;
    }

    public void RotateBack()
    {
        rotateBack = true;
    }
}
