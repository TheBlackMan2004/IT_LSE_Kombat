using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animati_crt : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        bool merge = animator.GetBool("Merge");
        bool mersFata = Input.GetKey("d");
        bool mersSpate = Input.GetKey("a");
        if (!merge && mersFata)
        {
            animator.SetBool("Merge", true);
        }

        if (merge && !mersFata)
        {
            animator.SetBool("Merge", false);
        }

        if (!merge && mersSpate)
        {
            animator.SetBool("Merge", true);
        }

        if (merge && !mersSpate)
        {
            animator.SetBool("Merge", false);
        }
    }
}
