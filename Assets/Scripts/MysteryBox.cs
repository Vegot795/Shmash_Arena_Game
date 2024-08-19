using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBox : MonoBehaviour, IOnInteraction
{
    
    [SerializeField] Animator animator;
    public void Interact()
    {   
        Debug.Log("Random Drop From Box");
        animator.SetBool("BoxRoll", true);  

    }
    public void Start()
    {
        animator=GetComponent<Animator>();
    }
    public void DisableAnimation()
    {
        animator.SetBool("BoxRoll", false);
    }
}
