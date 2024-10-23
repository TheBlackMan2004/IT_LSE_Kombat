using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public int health;
    public int currentHealth;
    public string characterName;
    public Ability firstAbility;
    public Ability secondAbility;
    public string firstAbilityKey;
    public string ultimateKey;
    public Ultimate ultimate;
    public int kickDamage;
    public int punchDamage;
   public bool facesRight = false;
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
    public void Start()
    {
        currentHealth = health;
    }
    public void Update()
    {
        if (Input.GetButtonDown(firstAbilityKey))
        {
            if (facesRight) firstAbility.direction = "right";
                else firstAbility.direction = "left";
            if(firstAbility.ready==true)
            {
                
                 firstAbility.CastAbility();
            }
            
        }    
        else if(Input.GetButtonDown(ultimateKey) && ultimate.ultimateCharge>=ultimate.ultimateMaxCharge)
        {
            ultimate.ultimateCharge = 0;
            StartCoroutine(Ult());
        }
    }
    IEnumerator Ult()
    {
        punchDamage *= 2;
        kickDamage *= 2;
        yield return new WaitForSeconds(5f);
        punchDamage /= 2;
        kickDamage /= 2;
    }
}
