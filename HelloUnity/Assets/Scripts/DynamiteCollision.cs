using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteCollision : MonoBehaviour
{
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Explodable"))
        {
            Destroy(collision.gameObject);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}