using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour
{
    public GameObject shootingPoint;
    public GameObject hitboxPrefab;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){

            Vector3 playerPos = shootingPoint.transform.position;

            if(shootingPoint.GetComponent<SpriteRenderer>().flipX = true)
            {
                playerPos.x -= (float)1.5;
                playerPos.y += (float)0.5;
                Instantiate(hitboxPrefab, playerPos, transform.rotation);
            }

            if (shootingPoint.GetComponent<SpriteRenderer>().flipX = false)
            {
                playerPos.x += (float)1.5;
                playerPos.y += (float)0.5;
                Instantiate(hitboxPrefab, playerPos, transform.rotation);
            }
        }
    }
}
