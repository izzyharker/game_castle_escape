using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float xmin;
    public float ymin;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().position = new Vector2(xmin, ymin);
    }

    public float health = 3;
    public float speed = 30;

    public float radius = 120;
    public Vector3 move_direction = new Vector2 (0, 1);

    public GameObject healthbar;

    void Move() {
        if (this.GetComponent<Rigidbody2D>().position.y >= (ymin + radius) && move_direction.y == 1) {
            move_direction = new Vector2(1, 0);
        }
        else if (this.GetComponent<Rigidbody2D>().position.x >= (xmin + radius) && move_direction.x == 1) {
            move_direction = new Vector2(0, -1);
        }
        else if (this.GetComponent<Rigidbody2D>().position.y <= (ymin) && move_direction.y == -1) {
            move_direction = new Vector2(-1, 0);
        }
        else if (this.GetComponent<Rigidbody2D>().position.x <= (xmin) && move_direction.x == -1) {           
            move_direction = new Vector2(0, 1);
        }
    }

    void Hit() {
        health--;
        // Debug.Log(health.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        this.GetComponent<Rigidbody2D>().velocity = move_direction * speed;
        this.GetComponent<Rigidbody2D>().rotation = 0f;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0f;
    }

    void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.name == "Player") {
            Hit();
            // Debug.Log("hit enemy\n");
            if (health==0) {
                Destroy(this.gameObject);
                Destroy(healthbar);
                c.gameObject.GetComponent<PlayerMovement>().num_enemies--;
            }
        }
    }
}

