// Spawner for A08 
// November 2024
// Sarah Keim
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Template;
    public int MaxSpawns = 5;
    public float SpawnRadius = 25;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < MaxSpawns; i++)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] PointPotatoes = GameObject.FindGameObjectsWithTag("Collectable");

        if (PointPotatoes.Length < MaxSpawns)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector3 RandPos = new Vector3(transform.position.x + Random.Range(-SpawnRadius, SpawnRadius), transform.position.y, transform.position.z + Random.Range(-SpawnRadius, SpawnRadius));
        GameObject PointPotato = Instantiate(Template, RandPos, Quaternion.identity);
    }
}
