using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 5;

    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        this.health -= amount;
    }
}
