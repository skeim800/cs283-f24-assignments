using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using BTAI;

public class BehaviorMinion : MonoBehaviour
{
    private Root m_btRoot = BT.Root();
    NavMeshAgent agent;
    public Transform player;
    public Transform playerHome;
    public Transform minionHome;
    public float attackRange = 3.0f;
    public float fleeRange = 12.0f;
    public float speed = 8.0f;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        m_btRoot.OpenBranch(
            BT.Selector().OpenBranch(
                BT.If(InAttackRange).OpenBranch(
                    BT.Call(Attack)
                ),
                BT.If(InHomeArea).OpenBranch(
                    BT.Call(Flee)
                ),
                BT.Call(Follow)
            )
        );
    }

    void Update()
    {
        m_btRoot.Tick();
    }

    private bool InAttackRange()
    {
        return Vector3.Distance(transform.position, player.position) < attackRange;
    }

    private bool InHomeArea()
    {
        return Vector3.Distance(transform.position, playerHome.position) < fleeRange;
    }

    private void Attack()
    {
        animator.SetBool("IsAttacking", true);
        animator.SetBool("IsAttacking", false);
    }

    private void Flee()
    {
        transform.position = Vector3.MoveTowards(transform.position, minionHome.position, Time.deltaTime * speed);
    }

    private void Follow()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * speed);
    }

}
