using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDemegable
{
    public string enemyName = "Slime";
    Animator animator;

    public SwordAttack swordAttack;

    public float Health {
        set {
            health = value;

            if(health <= 0) {
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public float health = 1;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void Defeated(){
        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }
    public void IsDamaged(int damage)
    {
        animator.SetTrigger("isDamaged");
        health -= damage;
        Debug.Log(enemyName + "takes" + damage + "damage, health left" + health);
        if (health <= 0)
        {
            Defeated();
        }
    }
}
