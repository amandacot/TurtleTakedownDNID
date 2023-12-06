using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public int damage = 1;
    public bool walkRight;
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveSpeed = Random.Range(3, 7);
    }

    void Update()
    {
        Vector3 direction;

  

        if (walkRight == false)
        {
            direction = Vector3.left;
            if (transform.position.x < -12)
            {
                Destroy(gameObject);
            }

        }

        else
        {
            direction = Vector3.right;

            
            if (transform.position.x > 12)
            {
                Destroy(gameObject);
            }
            
            if (gameObject.CompareTag("bee"))
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
        
        direction = new Vector3(direction.x, 0f, 0f); // Ignore vertical component
        direction.Normalize();
        movement = direction;
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.GetComponent<Health>() != null)
        {
            Health enemyHealth = collider.GetComponent<Health>();
            enemyHealth.Damage(damage);
        }
    }
}
