using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAbility : Ability
{
    [SerializeField] Projectile projectile;
    [SerializeField] Transform spawnPoint;
    public int damage = 10;
    override public void CastAbility() 
    {
        ready = false;
        Instantiate(projectile);
        projectile.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        if (direction == "right") projectile.direction = "right";
        else projectile.direction = "left";
        StartCoroutine(CooldownCounter());
    }
}
