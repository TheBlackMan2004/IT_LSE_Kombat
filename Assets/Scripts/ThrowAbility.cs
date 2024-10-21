using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAbility : Ability
{
    [SerializeField] Projectile projectile;
    [SerializeField] Transform spawnPoint;
    Vector3 position;
    private void FixedUpdate()
    {
    }
    override public void CastAbility() 
    {
        ready = false;
        Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        if (direction == "right") projectile.direction = "right";
        else projectile.direction = "left";
        StartCoroutine(CooldownCounter());
    }
}
