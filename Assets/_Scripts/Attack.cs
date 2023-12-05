using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{

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

        RaycastHit hit;
        float raycastDistance = 1.0f;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
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
 
    }
}
