using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    public float moveForce;
    public float jumpForce = 2;
    public bool isOnGround = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(moveForce, 0), ForceMode2D.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1*moveForce, 0), ForceMode2D.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.Z) && isOnGround){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
             isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && isOnGround)
        {
            double f = 0.1;
            gameObject.transform.localScale = new Vector3((float)0.3, (float)0.2, (float)0.5);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && isOnGround)
        {
            double f = 0.1;
            gameObject.transform.localScale = new Vector3((float)0.3, (float)0.3, (float)0.5);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
        }
        
    }
}
    

