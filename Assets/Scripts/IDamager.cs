using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDamager : MonoBehaviour
{
    public GameObject swordHitbox;
    public Collider2D swordCollider;
    LayerMask demagableObjects;
    private Collider2D[] demagableInRange;
    private Collider2D demagableObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FindEnemy(Collider2D other)
    {
        
    }
         
}
