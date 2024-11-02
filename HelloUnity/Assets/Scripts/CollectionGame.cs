// Collection Game for A08 
// November 2024
// Sarah Keim
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectionGame : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    private int points = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Debug.Log("Collided with collectable object");
            points += 1;
            pointsText.text = points.ToString();
            other.GetComponent<Collider>().enabled = false;
            SpinAnimation spinAnimation = other.GetComponent<SpinAnimation>();
            StartCoroutine(spinAnimation.Spin());
        }
    }
}
