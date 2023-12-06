/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 1;
    public float bounceForce = 5f; // Adjust this value as needed for the bounce force

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);

            // Get the Rigidbody2D of the parent object (attacker)
            Rigidbody2D attackerRb = transform.parent.GetComponent<Rigidbody2D>();

            if (attackerRb != null)
            {
                // Calculate bounce direction (away from the collision point)
                Vector2 bounceDirection = (attackerRb.transform.position - collider.transform.position).normalized;

                // Apply the bounce force to the attacker
                attackerRb.velocity = Vector2.zero; // Reset velocity before applying force
                attackerRb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
            }
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 1;
    public float bounceForce = 5f; // Adjust this value as needed for the bounce force

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);

            // Get the Rigidbody2D of the attacker
            Rigidbody2D attackerRb = transform.parent.GetComponent<Rigidbody2D>();

            // Get the Rigidbody2D of the enemy (collider)
            Rigidbody2D enemyRb = collider.GetComponent<Rigidbody2D>();

            if (attackerRb != null && enemyRb != null)
            {
                // Calculate the direction between attacker and enemy
                Vector2 direction = (enemyRb.transform.position - attackerRb.transform.position).normalized;

                // Apply forces to both attacker and enemy in opposite directions
                attackerRb.velocity = Vector2.zero; // Reset attacker's velocity before applying force
                attackerRb.AddForce(-direction * bounceForce, ForceMode2D.Impulse);

                enemyRb.velocity = Vector2.zero; // Reset enemy's velocity before applying force
                enemyRb.AddForce(direction * bounceForce, ForceMode2D.Impulse);
            }
        }
    }
}
