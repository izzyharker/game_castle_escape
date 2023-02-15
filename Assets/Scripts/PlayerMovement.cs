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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void changeSprite(Sprite newsprite) {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = newsprite;
    }

    void Attack() {
        if (hasWeapon == 1) {
            anim.SetBool("AttackPressed", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        // Debug.Log("collision detected\n");
    }

    void OnTriggerEnter2D(Collider2D coll) {
        // Debug.Log("made it to sword\n");
        if (coll.gameObject.name == "sword") {
            changeSprite(swordSprite);
            hasWeapon = 1;
        }
        Destroy(coll.gameObject);
    }
}
