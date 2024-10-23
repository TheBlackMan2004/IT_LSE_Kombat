using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

public class Animati_crt : MonoBehaviour
{
    // Animati pe caracter
    Animator animator;
    public string leftButton;
    public string rightButton;
    public string isCrouch;
   [SerializeField] bool isFacingRight;

    

    void Start()
    {
        animator = GetComponent<Animator>();
        Vector3 localScale = transform.localScale;
        if(!isFacingRight)
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<CharacterBase>().facesRight = isFacingRight;
        bool merge = animator.GetBool("Merge");
        bool mersDreapta = Input.GetKey(rightButton);
        bool mersStanga = Input.GetKey(leftButton);
        
        bool crouch = Input.GetKey(isCrouch);
        if (Input.GetKey(isCrouch))
        {
            animator.SetBool("Crouch", true);
        }
        else if (!Input.GetKey(isCrouch))
        {
            animator.SetBool("Crouch", false);
        }
        if (!merge && mersDreapta && !crouch)
        {
            animator.SetBool("Merge", true);
            if(!isFacingRight)
            {
                isFacingRight = true;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
            

        }

        if (merge && !mersDreapta)
        {
            animator.SetBool("Merge", false);
        }

        if (!merge && mersStanga && !crouch)
        {
            animator.SetBool("Merge", true);
            if(isFacingRight)
            {
                isFacingRight = false;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
           
        }

        if (merge && !mersStanga)
        {
            animator.SetBool("Merge", false);
        }
    }
}
