using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour, IDemegable
{
    public int playerHealth = 20;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void isDamaged(int damage)
    {
        playerHealth -= damage;
        Debug.Log($"Player received {damage} damage, now he got {playerHealth} HP");

    }

}
