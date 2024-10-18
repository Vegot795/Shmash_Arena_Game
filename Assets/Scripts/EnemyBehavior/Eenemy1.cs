using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour, IDemegable
{
    Animator animator;
    public string enemyName = "Enemy1";

    public int health = 10;
   

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Defeated()
    {
        animator.SetTrigger("isDefeated");
    }

    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
    public void IsDamaged(int damage)
    {
        animator.SetTrigger("isDamaged");
        health -= damage;
        Debug.Log(enemyName + "takes" + damage + "damage, health left" + health);
        if (health <= 0)
        {
            Defeated() ;
        }
    }

    public void OnCollisionEnter2D(Collider2D player)
    {
        
    }


}
