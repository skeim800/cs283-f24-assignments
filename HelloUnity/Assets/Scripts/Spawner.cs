// Spawner for A08 
// November 2024
// Sarah Keim
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject Template;
    public int MaxSpawns = 5;
    public float SpawnRadius = 25;
    public TextMeshProUGUI pointsText;

    private int ratsRemaining;
    public bool moreRats;

    // Start is called before the first frame update
    void Start()
    {
        moreRats = true;
        ratsRemaining = MaxSpawns;
        pointsText.text = "Rats Remaining: " + ratsRemaining;
        for (int i = 1; i <= MaxSpawns; i++)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] rats = GameObject.FindGameObjectsWithTag("Rat"); 

        if (ratsRemaining == 0)
        {
            moreRats = false;
        }
        else
        {
            pointsText.text = "Rats Remaining: " + ratsRemaining;
        }
    }

    private void Spawn()
    {
        Vector3 RandPos = new Vector3(transform.position.x + Random.Range(-SpawnRadius, SpawnRadius), transform.position.y, transform.position.z + Random.Range(-SpawnRadius, SpawnRadius));
        GameObject rat = Instantiate(Template, RandPos, Quaternion.identity);
        rat.tag = "Rat";
    }

    public void OnceConverted()
    {
        ratsRemaining -= 1;
        pointsText.text = "Rats Remaining: " + ratsRemaining;
    }
}
