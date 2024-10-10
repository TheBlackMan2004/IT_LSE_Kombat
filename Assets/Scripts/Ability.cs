using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Ability : MonoBehaviour
{
    public float cooldown;
    public float cooldownBase;
    // Start is called before the first frame update
    void Start()
    {
        cooldownBase = cooldown;
    }
    private void Update()
    {
        if (cooldown <= 0) cooldown = cooldownBase;
    }
    IEnumerator CooldownCounter()
    {
        while(cooldown>0)
        {
            cooldown--;
            yield return new WaitForSeconds(1);
        }
    }
    public virtual void CastAbility() { }
}
