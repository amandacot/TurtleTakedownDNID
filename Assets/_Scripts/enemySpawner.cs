using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    private Coroutine emitRepeater;
    public float F = 0;
    private int repeats = 0;
    
    [SerializeField]
    private GameObject smallPig;
    [SerializeField]
    private GameObject bigPig;
    [SerializeField]
    private GameObject bee;
    public bool sendleft;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (emitRepeater == null)
        {
            emitRepeater = StartCoroutine(emitEnemy(smallPig,bee,bigPig));
        }
    }

    IEnumerator emitEnemy(GameObject enemy1, GameObject enemy2, GameObject enemy3)
    {
        if(sendleft == true && repeats == 0)
        {
            GameObject newEnemy = Instantiate(enemy1, new Vector3(this.transform.position.x - 2, this.transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(2 - F);
        }

        yield return new WaitForSeconds(5 - F);

        

        int randomNumber = Random.Range(1, 4);

        if(randomNumber < 3)
        {
            if (sendleft == true)
            {
                GameObject newEnemy = Instantiate(enemy1, new Vector3(this.transform.position.x - 2, this.transform.position.y), Quaternion.identity);
            }

            else
            {
                GameObject newEnemy = Instantiate(enemy1, new Vector3(this.transform.position.x + 2, this.transform.position.y), Quaternion.identity);
            }
            
        }

        else if(randomNumber == 3)
        {
            if (sendleft == true)
            {
                GameObject newEnemy = Instantiate(enemy2, new Vector3(this.transform.position.x - 2, this.transform.position.y + Random.Range(2, 5)), Quaternion.identity);
            }
            else
            {
                GameObject newEnemy = Instantiate(enemy2, new Vector3(this.transform.position.x + 2, this.transform.position.y + Random.Range(2, 5)), Quaternion.identity);
            }
        }
        

        Debug.Log("enemy emitted!");

        repeats += 1;

        if(repeats == 1)
        {
            F = 0f;
        }

        if(repeats == 5)
        {
            F = 0.5f;
            Debug.Log("first speed up");
        }

        if (repeats == 10)
        {
            F = 1;
            Debug.Log("second speed up");
        }

        if(repeats == 15)
        {
            F = 2f;
            Debug.Log("third speed up");
        }

        if(repeats == 20)
        {
            F = 3;
            Debug.Log("good luck");
        }
        
        emitRepeater = null;
    }
}
