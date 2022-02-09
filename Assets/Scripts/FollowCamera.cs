using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        GameObject mainCharacter = GameObject.FindGameObjectWithTag("Player");
        transform.position = mainCharacter.transform.position + new Vector3(0,0,-10);
    }
}
