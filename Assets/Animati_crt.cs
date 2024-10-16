using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animati_crt : MonoBehaviour
{
    Animator animator;
    public string leftButton;
    public string rightButton;
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

        bool merge = animator.GetBool("Merge");
        bool mersDreapta = Input.GetKey(rightButton);
        bool mersStanga = Input.GetKey(leftButton);
        if (!merge && mersDreapta)
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

        if (!merge && mersStanga)
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
