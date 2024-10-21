using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Ability : MonoBehaviour
{
    public float cooldown;
    public float cooldownBase;
    public string direction;
    public bool ready = true;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = cooldownBase;
    }
    private void Update()
    {
        if (cooldown <= 0)
        {
            cooldown = cooldownBase;
            ready = true;
        }

    }
  protected  IEnumerator CooldownCounter()
    {
        for(float i = cooldownBase; i>0; i--)
        {
            if (ready != true)
            cooldown--;
            yield return new WaitForSeconds(1);
        }
        StopCoroutine("CooldownCounter");
    }
    public virtual void CastAbility() { }
}
