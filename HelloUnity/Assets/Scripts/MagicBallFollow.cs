using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBallFollow : MonoBehaviour
{
    public Transform player; 
    public float followSpeed = 5f; 
    public float maxDistance = 1f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;  
        rb.velocity = direction.normalized * followSpeed;
    }
}
