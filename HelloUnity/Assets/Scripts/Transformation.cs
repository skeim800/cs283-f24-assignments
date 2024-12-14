using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour
{
    public GameObject[] villagers;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ConvertToVillager();
        }
    }

    private void ConvertToVillager()
    {
        GameObject villager = villagers[Random.Range(0, villagers.Length)];

        Instantiate(villager, transform.position, transform.rotation);
        Spawner spawner = FindObjectOfType<Spawner>(); 
        spawner.OnceConverted();  
        Destroy(gameObject);  
    }

}

