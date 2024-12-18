﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatJuc : MonoBehaviour
{
    public Animator animator;
    public Transform PctAtacPumn;
    public Transform pctAtacPicior;
    public string keybindPumn;
    public string keybindPicior;
    public float MarimeAtacPumn = 0.5f;
    public float MarimeAtacPicior = 0.5f;
    bool isAttacking = false;
    public LayerMask LayerInamici;
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keybindPumn) && !isAttacking)
        {
            AtacPumn();
            
        }
       else if (Input.GetKey(keybindPicior) && !isAttacking)
        {
            AtacPicior();

        }
    }

    void AtacPumn()
    {
        if(!isAttacking)
            animator.SetTrigger("Atac");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(PctAtacPumn.position, MarimeAtacPumn, LayerInamici);
    
        foreach(Collider2D enemy in hitEnemies)
        {
            
            if (enemy.GetComponent<CharacterBase>().characterName != this.GetComponent<CharacterBase>().characterName)
            {
                enemy.GetComponent<CharacterBase>().TakeDamage(this.GetComponent<CharacterBase>().punchDamage);
                this.GetComponent<CharacterBase>().ultimate.ChargeUlt();
            }
        }
        StartCoroutine(AttackDelay());
        //isAttacking = false;
    }
    void AtacPicior()
    {
        if(!isAttacking)
            animator.SetTrigger("Atac_Picior");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(pctAtacPicior.position, MarimeAtacPicior, LayerInamici);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<CharacterBase>().characterName != this.GetComponent<CharacterBase>().characterName)
            {
                enemy.GetComponent<CharacterBase>().TakeDamage(this.GetComponent<CharacterBase>().kickDamage);
                this.GetComponent<CharacterBase>().ultimate.ChargeUlt();
            }
        }
        StartCoroutine(AttackDelay());
    }
    void OnDrawGizmosSelected()
    {
        if (PctAtacPumn == null) { return; }
        if(pctAtacPicior == null) { return; }
        Gizmos.DrawWireSphere(PctAtacPumn.position, MarimeAtacPumn);
        Gizmos.DrawWireSphere(pctAtacPicior.position, MarimeAtacPicior);
    }
    IEnumerator AttackDelay()
    {
        isAttacking = true;
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
    
}



