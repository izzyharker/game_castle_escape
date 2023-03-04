using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        float sx = transform.localScale.x;
        sx = player.GetComponent<PlayerMovement>().health / 5;
        transform.localScale = new Vector3(sx, transform.localScale.y, transform.localScale.z);
    }
}
