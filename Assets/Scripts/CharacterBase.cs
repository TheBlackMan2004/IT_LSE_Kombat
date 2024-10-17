using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public int health;
    public int currentHealth;
    public string characterName;
   /// public Ability firstAbility;
   /// public Ability secondAbility;
   ///public Ultimate ultimate;
    public int kickDamage;
    public int punchDamage;
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
        
    }
}
