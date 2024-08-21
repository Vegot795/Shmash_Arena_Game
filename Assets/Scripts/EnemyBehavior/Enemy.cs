using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDemegable
{
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
    public void IsDamaged()
    {
        health -= swordAttack.damage();

        if (health <= 0)
        {
            Defeated();
        }
    }
}
