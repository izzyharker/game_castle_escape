using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 60f;
    public Sprite swordSprite;

    private SpriteRenderer spriteRenderer;

    public Animator anim;

    public int hasWeapon = 0;
    public bool attack = false;

    public float health = 5;

    public bool immune = false;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<PolygonCollider2D>().enabled=false;
        health = 5;
    }

    void changeSprite(Sprite newsprite) {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newsprite;
    }

    void Attack() {
        if (hasWeapon == 1) {
            anim.SetBool("AttackPressed", true);
            this.GetComponent<PolygonCollider2D>().enabled=true;
            attack = true;
        }
    }

    void Flip() {
        float tx = transform.localScale.x;
        if (Input.GetAxis("Horizontal") < 0 && tx > 0) {
            tx *= -1;
        }
        else if (Input.GetAxis("Horizontal") > 0 && tx < 0) {
            tx *= -1;
        }
        transform.localScale = new Vector3(tx, transform.localScale.y, transform.localScale.z);
    }

    void Hit() {
        if (!immune) {
            health--;
            immune = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2 (Input.GetAxis("Horizontal")*speed, Input.GetAxis("Vertical")*speed);
        // if (Input.GetAxis("Fire1"))
        this.GetComponent<Rigidbody2D>().rotation = 0f;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0f;

        if (hasWeapon == 1) {
            anim.SetBool("hasWeapon", true);
        }

        if (Input.GetKeyDown("space")) {
            Debug.Log("pressed space bar");
            Attack();
        }

        if (Input.GetKeyUp("space")) {
            anim.SetBool("AttackPressed", false);
            this.GetComponent<PolygonCollider2D>().enabled=false;
            attack = false;
        }  

        if (health == 0) {
            Destroy(this.gameObject);
        }

        Flip();
        if (i % 10 == 0) {
            immune = false;
        }
        i++;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        // Debug.Log("collision detected\n");

        if (coll.gameObject.name == "enemy1") {
            Hit();
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        // Debug.Log("made it to sword\n");
        if (coll.gameObject.name == "sword") {
            changeSprite(swordSprite);
            hasWeapon = 1;
            Destroy(coll.gameObject);
        }
    }
}
