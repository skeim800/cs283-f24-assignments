using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject magicBall;
    public float attackRange = 2f;
    public Transform throwFrom;
    public float throwForce = 10f;
    public float throwUpwardForce = 2f;
    public float throwCooldown = 1f;

    private bool isAttacking = false;

    public float spinDuration = 1.2f;
    public float spinSpeed = 800;

    public Transform player;

    public HealthBar healthBar;
    private int currentHealth;
    public int maxHealth = 5;
    public bool defeated;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.GetComponent<HealthBar>().SetHealth(currentHealth);
        defeated = false;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange)
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            GameObject magic = Instantiate(magicBall, throwFrom.position, throwFrom.rotation);

            MagicBallFollow magicFollow = magic.GetComponent<MagicBallFollow>();
            magicFollow.player = player; 

            Rigidbody magicRb = magic.GetComponent<Rigidbody>();
            Vector3 forceToAdd = throwFrom.forward * throwForce + throwFrom.up * throwUpwardForce;
            magicRb.AddForce(forceToAdd, ForceMode.Impulse);

            StartCoroutine(MagicBallSpin(magic));
            StartCoroutine(AttackCooldown());
        }
    }

    public IEnumerator MagicBallSpin(GameObject magicBall)
    {
        float elapsedTime = 0f;

        while (elapsedTime < spinDuration)
        {
            magicBall.transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    } 

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(throwCooldown);
        isAttacking = false;
    }

    public void TakeDamage(int damage)
    { 
        currentHealth -= damage;
        healthBar.GetComponent<HealthBar>().SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        defeated = true;
        gameObject.SetActive(false);
    }
}
