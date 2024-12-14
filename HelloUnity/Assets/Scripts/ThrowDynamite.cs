using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowDynamite : MonoBehaviour
{
    public GameObject dynamite;
    public Transform throwFrom;
    public float throwForce = 10f;
    public float throwUpwardForce = 2f;
    public float throwCooldown = 1f;

    public float spinDuration = 1.2f;
    public float spinSpeed = 800;

    private bool canThrow = true;

    public float explosionRadius = 5f;
    public float explosionForce = 500f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && canThrow)
        {
            PlayerThrowDynamite();
        }
    }

    public void PlayerThrowDynamite()
    {
        canThrow = false;

        GameObject dynamiteObject = Instantiate(dynamite, throwFrom.position, throwFrom.rotation);
        Rigidbody dynamiteRb = dynamiteObject.GetComponent<Rigidbody>();
        Vector3 forceToAdd = throwFrom.forward * throwForce + throwFrom.up * throwUpwardForce;
        dynamiteRb.AddForce(forceToAdd, ForceMode.Impulse);

        StartCoroutine(DynamiteSpin(dynamiteObject));

        StartCoroutine(ThrowCooldown());
    }

    private IEnumerator ThrowCooldown()
    {
        yield return new WaitForSeconds(throwCooldown);
        canThrow = true;
    }

    public IEnumerator DynamiteSpin(GameObject dynamiteObject)
    {
        float elapsedTime = 0f;

        while (elapsedTime < spinDuration)
        {
            dynamiteObject.transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
