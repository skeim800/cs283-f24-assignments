using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{
    public float range = 10.0f;
    private NavMeshAgent Nav;

    // Start is called before the first frame update
    void Start()
    {
        Nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Nav.remainingDistance <= Nav.stoppingDistance)
        {
            WanderToPoint();
        }
    }

    void WanderToPoint()
    {
        Vector3 result;
        if (RandomPoint(transform.position, range, out result))
        {
            Nav.SetDestination(result);
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

}
