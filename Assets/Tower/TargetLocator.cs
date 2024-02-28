using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;
    void Start()
    {
        //Cannot implicitly convert type 'EnemyMover' to 'UnityEngine.Transform' / per questo errore .transform
        target = FindObjectOfType<Enemy>().transform;
    }

    void Update()
    {
        AimWeapon();
    }

    void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
