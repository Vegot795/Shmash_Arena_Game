using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float _interactionRange = 1f;
    private GameObject currentIntObjec;
    public LayerMask interactableObjects;
    private Collider2D[] interactablesInRange;

    void Update()
    {
        DetectIntObjects();
        if (interactablesInRange.Length > 0 && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }
    }

    void DetectIntObjects()
    {
        interactablesInRange = Physics2D.OverlapCircleAll(transform.position, _interactionRange, interactableObjects); 
    }
    void InteractWithObject()
    {
        if(interactablesInRange.Length > 0 )
        {
            Collider2D interactableObject = interactablesInRange[0];
            if (interactableObject.CompareTag("Interactable"))
            {
                interactableObject.GetComponent<IOnInteraction>().Interact();
                Debug.Log("Interacted with " + interactableObject.name);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _interactionRange);
    }
}
