using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    public GameObject ground;
    private GameObject attackAreaGround = default;
    private GameObject attackAreaAir = default;
    public LayerMask groundLayer;
    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    private void Start()
    {
        attackAreaGround = transform.GetChild(0).gameObject;
        attackAreaAir = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Attack();
        }

        if(attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackAreaGround.SetActive(attacking);
                attackAreaAir.SetActive(attacking);
            }
        }
        
    }

    private void Attack()
    {
        attacking = true;
        Debug.Log("Attacking");

        float distance = Vector3.Distance(gameObject.transform.position, ground.transform.position);
        // Debug.Log(distance);

        if(distance <= 9f)
        {
            attackAreaGround.SetActive(attacking);
            Debug.Log("Ground attack");
        }
        else
        {
            attackAreaAir.SetActive(attacking);
            Debug.Log("Air attack");
        }

        // RaycastHit hit;
        // float raycastDistance = 1.0f;

        /*

        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            Debug.Log(hit);
            if (hit.collider.CompareTag("Ground"))
            {
                attackAreaGround.SetActive(attacking);
            }

            else
            {
                attackAreaAir.SetActive(attacking);
            }
                
        }
        else
        {
            attackAreaAir.SetActive(attacking);
        }
        */
    }
}
