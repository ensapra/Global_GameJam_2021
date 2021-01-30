using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIChasePlayer : MonoBehaviour
{
    FieldOfView fieldOfView;
    [Header("Components")]
    [Tooltip("needs to be the light of view object")] [SerializeField] Light enemyLight;
    [Tooltip("needs to be the light of view object")] [SerializeField] MeshRenderer enemyMesh;
    [Header("Colors")]
    [SerializeField] Color normalColor;
    [SerializeField] Color seeTargetColor;
    [Header("Materials")]
    [SerializeField] Material normalMaterial;
    [SerializeField] Material seeTargetMaterial;
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
        AIMoveRandomly = GetComponent<AIMoveRandomly>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (fieldOfView.visibleTargets.Count > 1)
            stateSeePlayer = true;
        else
            stateSeePlayer = false;
        
        if(state==State.searching && stateSeePlayer)        //upon first seeing player
        {
            state = State.Chasing;
            enemyLight.color = seeTargetColor;
            enemyMesh.material = seeTargetMaterial;
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

            if(!stateSeePlayer)
            {
                state = State.searching;
                enemyLight.color = normalColor;
                enemyMesh.material = normalMaterial;
            }
            //TODO if lost player then change state back to searching
            //if distance to player > x  or if line of sight to player lost 
        }




    }

}
