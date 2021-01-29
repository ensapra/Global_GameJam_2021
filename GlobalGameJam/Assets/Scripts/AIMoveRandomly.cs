using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIMoveRandomly : MonoBehaviour
{
    [SerializeField] float repathTime = 6f;
    [SerializeField] float wanderDistance = 6f;
    [SerializeField] float randomStartDelayUntilFirstMove = 5;

    NavMeshAgent agent;
    Vector3 target;
    LayerMask layerMask;
    float timeLeft;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        timeLeft = Random.Range(-1, randomStartDelayUntilFirstMove);
    }

    void Update()
    {
        if (timeLeft < 0)
            MoveToNewRandomPoint();

        timeLeft -= Time.deltaTime;
    }

    void MoveToNewRandomPoint()
    {
        timeLeft = repathTime;
        agent.SetDestination(RandomNavSphere(transform.position, wanderDistance, -1));
    }

    Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }


}
