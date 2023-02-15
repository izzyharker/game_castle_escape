using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public GameObject player;
    public Vector3 offset = new Vector3(0, 0, -10);

    // Update is called once per frame
    void LateUpdate()
    {   
        transform.position = player.transform.position + offset;
    }
}
