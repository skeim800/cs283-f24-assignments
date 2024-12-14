using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoCollision : MonoBehaviour
{
    public int damage = 1; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyBehavior enemy = collision.gameObject.GetComponent<EnemyBehavior>();
            enemy.TakeDamage(damage); 
            Destroy(gameObject);
        }
    }
}

