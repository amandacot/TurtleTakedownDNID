using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 5;

    private int MAX_HEALTH = 5;

    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Can't have negative damage");
        }
        this.health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Can't have negative healing");
        }

        if(health + amount > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
        
    }

private void Die()
    {
        Debug.Log("I am Dead!");
        Destroy(gameObject);
    }
}
