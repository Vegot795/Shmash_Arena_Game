using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SwordAttack : MonoBehaviour
{
    public BoxCollider2D swordCollider;
    public int damage = 3;
    Vector2 rightAttackOffset = new Vector2(0.1f, -0.1f);
    Vector2 defaultColidSize = new Vector2(0.19f, 0.25f);
    Vector2 vertColidSize = new Vector2(0.25f, 0.19f);

    private void Start() {
        //rightAttackOffset = transform.position;
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
        transform.localPosition = new Vector2(0, 0);
        swordCollider.size = vertColidSize;
        print("attack up");
    }
    public void AttackDown()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector2(0, -0.2f);
        swordCollider.size = vertColidSize;
        print("attack down");
    }

    public void StopAttack() {
       swordCollider.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.CompareTag("Enemy"))
        {
            IDemegable damageable = other.GetComponent<IDemegable>();
            if(damageable != null)
            {
                damageable.IsDamaged(damage);
                Debug.Log("player attacks for" + damage + "to the target");
            }
        }
    }
}
