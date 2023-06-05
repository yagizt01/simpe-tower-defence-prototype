using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem bullet;
    [SerializeField] float range = 15f;
    
    Transform target;
    
   

    void FindClosetTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closetTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closetTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closetTarget;
    }

    void Update()
    {
        AimWeapon();
        FindClosetTarget();
    }
    
    void AimWeapon()
    {
        if (target == null)
        {
            return;  
        }
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if (targetDistance < range)
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
        var emmisionmodule = bullet.emission;
        emmisionmodule.enabled = isActive;
    }
}
