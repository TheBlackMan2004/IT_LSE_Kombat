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
   ///public Ultimate ultimate;
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
    }
}
