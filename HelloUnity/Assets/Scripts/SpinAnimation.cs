// Collectable item animation for A08 
// November 2024
// Sarah Keim
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAnimation : MonoBehaviour
{
    public float Duration = 1.2f;
    public float SpinSpeed = 600;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartSpin()
    {
        StartCoroutine(Spin());
    }

    public IEnumerator Spin()
    {
        float elapsedTime = 0f;

        while (elapsedTime < Duration)
        {
            transform.Rotate(Vector3.up, SpinSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
    }

}
