using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BTAI;


public class PlayerAttack : MonoBehaviour
{
    public GameObject potato;
    public Transform throwFrom;
    public float throwForce = 10f;
    public float throwUpwardForce = 2f;
    public float throwCooldown = 1f;

    private bool canThrow = true;

    public float spinDuration = 1.2f;
    public float spinSpeed = 800;

    public Transform mage;

    public HealthBar healthBar;
    public int maxHealth = 8;
    private int currentHealth;
    public bool playerDead;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.GetComponent<HealthBar>().SetMaxHealth(currentHealth);
        playerDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canThrow)
        {
            PlayerThrowPotato();
        }
    }

    private void PlayerThrowPotato()
    {
        if (canThrow)
        {
            canThrow = false;

            GameObject potatoWeapon = Instantiate(potato, throwFrom.position, throwFrom.rotation);
            Rigidbody potatoWeaponRb = potatoWeapon.GetComponent<Rigidbody>();
            Vector3 forceToAdd = throwFrom.forward * throwForce + throwFrom.up * throwUpwardForce;
            potatoWeaponRb.AddForce(forceToAdd, ForceMode.Impulse);

            StartCoroutine(PotatoSpin(potatoWeapon));

            StartCoroutine(ThrowCooldown());
        }
    }

    private IEnumerator ThrowCooldown()
    {
        yield return new WaitForSeconds(throwCooldown);
        canThrow = true;
    }

    public IEnumerator PotatoSpin(GameObject potatoWeapon)
    {
        float elapsedTime = 0f;

        while (elapsedTime < spinDuration)
        {
            potatoWeapon.transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.GetComponent<HealthBar>().SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            playerDead = true;
        }
    }

}
