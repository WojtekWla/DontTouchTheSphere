using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
 
    [SerializeField] private int enemySpeed;
    Rigidbody2D rb;
    int x = 0;
    int y = 0;
    Vector3 lastVelocity;
    public ParticleSystem particleEnemy;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        int velocityX = Random.Range(1, 100);
        int velocityY = Random.Range(1, 100);
        print(velocityX + " "+ velocityY);
        
        if (velocityX % 2 == 0)
        {
            x = enemySpeed;
        }
        else
        {
            x = -enemySpeed;
        }

        if (velocityY % 2 == 0)
        {
            y = enemySpeed;
        }
        else
        {
            y = -enemySpeed;
        }

        rb.velocity = new Vector2(x, y);
        
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
        particleEnemy.transform.position = gameObject.transform.position;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * speed;
        
    }

    public int GetEnemySpeed()
    {

        return enemySpeed;
    }
}
