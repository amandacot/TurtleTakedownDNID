using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Animator animator;
    public float moveForce;
    private Rigidbody2D rb;
    private bool facingRight;
    public float jumpForce = 2;
    public bool isOnGround = true;
    private float moveDirection;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    private Coroutine attackCoroutine;
    Health health = new Health();

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveDirection * moveForce, rb.velocity.y);

        if(moveDirection * moveForce == 0)
        {
            animator.SetBool("Walking", false);
        }
        else
        {
            animator.SetBool("Walking", true);
        }

        animator.SetBool("Grounded", isOnGround);

       
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        

        if(Input.GetKeyDown(KeyCode.Z) && isOnGround){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
             isOnGround = false;
             
        }


        if (Input.GetKeyDown(KeyCode.X))
        {
            if (attackCoroutine == null)
            {
                attackCoroutine = StartCoroutine(AttackCoroutine());
            }
        }

        IEnumerator AttackCoroutine()
        {
            animator.SetBool("Attacking", true);
            yield return new WaitForSeconds(0.25f); // Adjust the duration of the attack animation

            animator.SetBool("Attacking", false);
            attackCoroutine = null;
        }


        if (Input.GetKeyDown(KeyCode.DownArrow) && isOnGround)
        {
            double f = 0.1;
            gameObject.transform.localScale = new Vector3((float)3, (float)2, (float)0.5);
            animator.SetBool("Crouching", true);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && isOnGround)
        {
            double f = 0.1;
            gameObject.transform.localScale = new Vector3((float)3, (float)3, (float)0.5);
            animator.SetBool("Crouching", false);
        }

       
        

    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("enemy"))
        {
            enemyDamage(collision.gameObject);
        }

    }

    public void enemyDamage(GameObject enemy)
    {
        enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 5), ForceMode2D.Impulse);
        enemy.GetComponent<Health>().Damage(1);
    }


}
    

