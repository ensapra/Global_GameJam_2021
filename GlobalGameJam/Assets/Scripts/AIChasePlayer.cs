using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIChasePlayer : MonoBehaviour
{


    FieldOfView fieldOfView;
    [Tooltip("needs to be the mesh of the field of view object")] [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Material seeTarget;
    Material normalMat;
    AIMoveRandomly AIMoveRandomly;
    NavMeshAgent agent;

    bool stateSeePlayer = false;
    public enum State { searching, Chasing };
    State state;
    float delay = 0.25f;
    Transform playerRef;

    void Awake()
    {
        fieldOfView = GetComponentInChildren<FieldOfView>();
        normalMat = meshRenderer.material;
        AIMoveRandomly = GetComponent<AIMoveRandomly>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (fieldOfView.visibleTargets.Count > 1)
            stateSeePlayer = true;
        
        if(state==State.searching && stateSeePlayer)        //upon first seeing player
        {
            state = State.Chasing;
            meshRenderer.material = seeTarget;
            if (AIMoveRandomly != null)
                Destroy(AIMoveRandomly);
            playerRef = fieldOfView.visibleTargets[0];
            agent.SetDestination(playerRef.position);            
        }

        if(state==State.Chasing)                            //keep chasing player if not reached him 
        {
            delay -= Time.deltaTime; 
            if(delay<0)
            {
                agent.SetDestination(playerRef.position);
                delay = 0.25f;
            }

            //TODO if lost player then change state back to searching
            //if distance to player > x  or if line of sight to player lost 
        }




    }

}
