using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatJuc : MonoBehaviour
{
    public Animator animator;
    public Transform PctAtacPumn;
    public Transform pctAtacPicior;
    public string keybindPumn;
    public string keybindPicior;
    public float MarimeAtac = 0.5f;
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

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(PctAtacPumn.position, MarimeAtac, LayerInamici);
    
        foreach(Collider2D enemy in hitEnemies)
        {
            
            if (enemy.GetComponent<CharacterBase>().characterName != this.GetComponent<CharacterBase>().characterName)
                enemy.GetComponent<CharacterBase>().TakeDamage(this.GetComponent<CharacterBase>().punchDamage);
        }
        StartCoroutine(AttackDelay());
        //isAttacking = false;
    }
    void AtacPicior()
    {
        if(!isAttacking)
            animator.SetTrigger("Atac");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(pctAtacPicior.position, MarimeAtac, LayerInamici);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<CharacterBase>().characterName != this.GetComponent<CharacterBase>().characterName)
                enemy.GetComponent<CharacterBase>().TakeDamage(this.GetComponent<CharacterBase>().kickDamage);
        }
        StartCoroutine(AttackDelay());
        //isAttacking = false;
    }
    void OnDrawGizmosSelected()
    {
        if (PctAtacPumn == null) { return; }
        if(pctAtacPicior == null) { return; }
        Gizmos.DrawWireSphere(PctAtacPumn.position, MarimeAtac);
        Gizmos.DrawWireSphere(pctAtacPicior.position, MarimeAtac);
    }
    IEnumerator AttackDelay()
    {
        isAttacking = true;
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
    
}



