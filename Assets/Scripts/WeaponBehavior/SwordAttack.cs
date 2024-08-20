using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwordAttack : MonoBehaviour
{
    public BoxCollider2D swordCollider;
    public float damage = 3;
    Vector2 rightAttackOffset;
    Vector2 verticalAttackOffset;
    Vector2 defaultColidSize = new Vector2(0.19f, 0.25f);
    Vector2 vertColidSize = new Vector2(0.25f, 0.19f);

    private void Start() {
        rightAttackOffset = transform.position;

        Vector2 verticalAttackOffset = new Vector2(0, Math.Abs(rightAttackOffset.x));
    }

    public void AttackRight() {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
        swordCollider.size = defaultColidSize;
        print("attack right");
    }

    public void AttackLeft() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(rightAttackOffset.x * -1, rightAttackOffset.y);
        swordCollider.size = defaultColidSize;
        print("attack left");
    }
    public void AttackUp()
    {
        swordCollider.enabled = true;
        transform.localPosition = verticalAttackOffset;
        swordCollider.size = vertColidSize;
        print("attack up");
    }
    public void AttackDown()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(0, verticalAttackOffset.y*-1);
        swordCollider.size = vertColidSize;
        print("attack down");
    }

    public void StopAttack() {
       swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            // Deal damage to the enemy
            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null) {
                enemy.health -= damage;
                print("enemy found");
            } else
            {
                print("missed");
            }
        } else
        {
            print("missed");
        }
    }
}
