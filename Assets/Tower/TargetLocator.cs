using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    Transform target;
   
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        //array di nemici che verranno trovati by type
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        //capire qual è il nemico più vicino. settato su null perchè ancora non sappiamo chi sarà quello più vicino
        Transform closestTarget = null;
        //la distanza di detecting del nemico dalla torre
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            //(la nostra posizione, la posizione del nemico)
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            //come capire quale nemico è più vicino
            if(targetDistance < maxDistance)
            {   
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void AimWeapon()
    {   
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);

        if(targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
