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
    public Vector3 offset = new Vector3(-14, 36, 0);

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.GetComponent<Rigidbody2D>().position.x, player.GetComponent<Rigidbody2D>().position.y, 0) + offset;

        float sx = transform.localScale.x;
        sx = player.GetComponent<PlayerMovement>().health / 5;
        transform.localScale = new Vector3(sx, transform.localScale.y, transform.localScale.z);
    }
}
