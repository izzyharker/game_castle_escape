using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(130, -100, 0);
    }

    public float health = 3;
    public float speed = 0.5f;

    public float xmin = 130;
    public float ymin = -100;
    public float radius = 60;
    public Vector3 move_direction = new Vector3 (0, 1, 0);

    void Move() {
        if (transform.position.y > (ymin + radius) && move_direction.y == 1) {
            move_direction = new Vector3(1, 0, 0);
        }
        else if (transform.position.x > (xmin + radius) && move_direction.x == 1) {
            move_direction = new Vector3(0, -1, 0);
        }
        else if (transform.position.y < ymin && move_direction.y == -1) {
            move_direction = new Vector3(-1, 0, 0);
        }
        else if (transform.position.x < xmin && move_direction.x == -1) {
            move_direction = new Vector3(0, 1, 0);
        }
        transform.position = transform.position + speed*move_direction;
    }

    void Hit() {
        health--;
        Debug.Log(health.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (health==0) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.name == "Player") {
            Hit();
            Debug.Log("hit enemy\n");
        }
    }
}

