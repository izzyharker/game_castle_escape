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

    public int num_enemies = 4;

    public GameObject healthbar;

    public GameObject win;
    public GameObject lose;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<PolygonCollider2D>().enabled=false;
        health = 5;

        transform.position = new Vector2(-335, -610);

        Time.timeScale = 1;
    }

    void changeSprite(Sprite newsprite) {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newsprite;
        anim.SetBool("hasWeapon", true);
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

    void GameOver() {
        lose.SetActive(true);
        Time.timeScale = 0;
    }

    void YouWin() {
        win.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2 (Input.GetAxis("Horizontal")*speed, Input.GetAxis("Vertical")*speed);
        this.GetComponent<Rigidbody2D>().rotation = 0f;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0f;

        // if (hasWeapon == 1) {
        //     anim.SetBool("hasWeapon", true);
        // }

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
            GameOver();
        }

        if (num_enemies == 0) {
            YouWin();
        }

        Flip();

        if (i % 20 == 0) {
            immune = false;
        }
        i++;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        // Debug.Log("collision detected\n");

        Sprite s = coll.gameObject.GetComponent<SpriteRenderer>().sprite;

        if (s.name == "enemy1") {
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
