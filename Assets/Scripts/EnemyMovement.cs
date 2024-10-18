using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private float moveSpeed = 1f;
    Animator animator;
    SpriteRenderer spriteRenderer;
    GameObject thisObject;
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.transform;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        thisObject = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();

        if (player != null )
        {
            MoveTowards(player.position);
        }
        AnimationHandler();
    }

    private void DetectPlayer()
    {

        if (player == null)
        {
            Debug.Log("Player not found!");
        }
        else
        {
            print("Player found.Go Next");
        }
    }

    private void MoveTowards(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

    }
    private void AnimationHandler()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;

        //cut here

        if (direction.x != 0)
        {
            animator.SetBool("EnemyMovingSideways", true);
            spriteRenderer.flipX = direction.x < 0;
        }
        else
        {
            animator.SetBool("EnemyMovingSideways", false);
        }
        /*
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Horizontal movement
            animator.SetBool("EnemyMovingSideways", true);
            spriteRenderer.flipX = direction.x < 0; // Flip sprite based on direction
        }
        else
        {
            // Vertical movement
            animator.SetBool("EnemyMovingSideways", false);

            if (direction.y > 0)
            {
                animator.SetBool("EnemyMovingUp", true);
                animator.SetBool("EnemyMovingDown", false);
            }
            else
            {
                animator.SetBool("EnemyMovingDown", true);
                animator.SetBool("EnemyMovingUp", false);
            }
        }
        */
    }
    private void Attak()
    {
            
    }
}
