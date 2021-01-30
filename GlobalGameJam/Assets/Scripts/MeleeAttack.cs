using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] float attackRange = 1;
    [SerializeField] float timeBetweenAttacks = 2;
    [SerializeField] float damage = 10;

    Transform target;
    FieldOfView fieldOfView;
    float nextAttackTime;

    void Awake()
    {
        fieldOfView = GetComponent<FieldOfView>();
    }

    void Update()
    {
        if(fieldOfView.visibleTargets.Count>0)
        {
            target = fieldOfView.visibleTargets[0];
            if (InRange())
            {
                if (CanAttack())
                    Attack();
            }
        }
    }

    bool InRange()      //have todo distance check as don't know targets distance, HMM ASK MeleeEngageComponenet 
    {
        float getDist = Vector3.Distance(transform.position, target.position);
        //Debug.Log("attack distance is " + getDist);
        return (getDist < attackRange);
    }

    bool CanAttack()
    {
        if (Time.time > nextAttackTime) // && health.lastTakeDamageTime + attackStaggerUponDamage < Time.time)
            return true;
        else
            return false;
    }

    void Attack()
    {
        //movementComponent.StopMoving();                               //testing to get rid of footsounds
        nextAttackTime = Time.time + timeBetweenAttacks;
        //animationComponent.PlayAnimationAttack();

        HealthComponent targetHealth = target.GetComponent<HealthComponent>();
        if (targetHealth)
            targetHealth.TakeDamage(damage);
        //AudioManager.instance.PlaySound("SwordAttack", transform.position);
    }


}
