using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject enemy1;
    public Vector3 offset = new Vector3(-16, 18, 0);

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(enemy1.GetComponent<Rigidbody2D>().position.x, enemy1.GetComponent<Rigidbody2D>().position.y, 0) + offset;
    
        float sx = transform.localScale.x;
        sx = enemy1.GetComponent<Enemy1>().health / 3;
        transform.localScale = new Vector3(sx, transform.localScale.y, transform.localScale.z);
    }
}
