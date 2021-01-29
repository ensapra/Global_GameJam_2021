using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this works - but as soon as player leavers area of field of view, the enemy will return to normal 
//replaced with AIChasePlayer.cs 

public class AIChangeFieldOfViewColour : MonoBehaviour
{
/*    FieldOfView fieldOfView;
    [Tooltip("needs to be the mesh of the field of view object")] [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Material seeTarget;
    Material normalMat;

    void Awake()
    {
        fieldOfView = GetComponentInChildren<FieldOfView>();
        normalMat = meshRenderer.material;
    }

    void Update()
    {

        if (fieldOfView.visibleTargets.Count > 1)
            meshRenderer.material = seeTarget;
        else
            meshRenderer.material = normalMat;
    }*/
}
