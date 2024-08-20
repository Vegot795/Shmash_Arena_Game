using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

// Takes and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;

    public bool isMovingHorisontal = false;
    public bool isMovingDown = false;
    public bool isMovingUp = false;
    public bool isMovingVertical = false;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public enum AttackDirection
    {
        Left,
        Right,
        Up,
        Down
    }
    public enum TurnedDirection
    {
        Left,
        Right,
        Up,
        Down
    }

    public AttackDirection lastAttackDirection;


    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        DetectMoveDirection();
        //IdleDirection();

        if (canMove)
        {
            bool success = TryMove(movementInput);

            // Handle horizontal movement
            if (isMovingHorisontal)
            {
                animator.SetBool("isMovingHorisontal", success);
                spriteRenderer.flipX = movementInput.x < 0; // Flip sprite for left movement
            }
            else
            {
                animator.SetBool("isMovingHorisontal", false);
            }

            // Handle vertical movement using key detection
            if (Input.GetKey(KeyCode.S)) // Moving Down
            {
                animator.SetBool("isMovingDown", success);
                animator.SetBool("isMovingUp", false);
            }
            else if (Input.GetKey(KeyCode.W)) // Moving Up
            {
                animator.SetBool("isMovingUp", success);
                animator.SetBool("isMovingDown", false);
            }
            else
            {
                // Reset both vertical movement states if no key is pressed
                animator.SetBool("isMovingUp", false);
                animator.SetBool("isMovingDown", false);
            }
        }
    }

    private void DetectMoveDirection()
    {
        if (movementInput.x != 0)
        {
            isMovingHorisontal = true;
            isMovingVertical = false;

            // Update the last attack direction based on horizontal movement
            if (movementInput.x > 0)
            {
                lastAttackDirection = AttackDirection.Right;
                
            }
            else if (movementInput.x < 0)
            {
                lastAttackDirection = AttackDirection.Left;
            }
        }
        else
        {
            isMovingHorisontal = false;
        }

        if (movementInput.y != 0)
        {
            isMovingVertical = true;
            isMovingHorisontal = false;

            // Update the last attack direction based on vertical movement
            if (movementInput.y > 0)
            {
                lastAttackDirection = AttackDirection.Up;
            }
            else if (movementInput.y < 0)
            {
                lastAttackDirection = AttackDirection.Down;
            }
        }
        else
        {
            isMovingVertical = false;
        }
    }



    private bool TryMove(Vector2 direction) {
        if(direction != Vector2.zero) {
            // Check for potential collisions
            int count = rb.Cast(
                direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
                movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset

            if(count == 0){
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }
        } else {
            // Can't move if there's no direction to move in
            return false;
        }
        
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire() {
        animator.SetTrigger("swordAttack");
    }

    public void SwordAttack()
    {
        LockMovement();
        switch (lastAttackDirection)
        {
            case AttackDirection.Right:
                swordAttack.AttackRight();
                break;
            case AttackDirection.Left:
                swordAttack.AttackLeft();

                break;
            case AttackDirection.Up:
                swordAttack.AttackUp();

                break;
            case AttackDirection.Down:
                swordAttack.AttackDown();
                break;
        }
    }
    public void IdleDirection()
    {
        switch (lastAttackDirection)
        {
            case AttackDirection.Right:
                animator.SetBool("isTurnedRight", true);
                animator.SetBool("isTurnedLeft", false);
                animator.SetBool("isTurnedUp", false) ;
                animator.SetBool("isTurnedDown", false);
                break;
            case AttackDirection.Left:
                animator.SetBool("isTurnedRight", false);
                animator.SetBool("isTurnedLeft", true);
                animator.SetBool("isTurnedUp", false);
                animator.SetBool("isTurnedDown", false);
                break;
            case AttackDirection.Up:
                animator.SetBool("isTurnedRight", false);
                animator.SetBool("isTurnedLeft", false);
                animator.SetBool("isTurnedUp", true);
                animator.SetBool("isTurnedDown", false);
                break;
            case AttackDirection.Down:
                animator.SetBool("isTurnedRight", false);
                animator.SetBool("isTurnedLeft", false);
                animator.SetBool("isTurnedUp", false);
                animator.SetBool("isTurnedDown", true);
                break;
        }
    }
    

    public void EndSwordAttack() {
        UnlockMovement();
        swordAttack.StopAttack();
    }

    public void LockMovement() {
        canMove = false;
    }

    public void UnlockMovement() {
        canMove = true;
    }
}
