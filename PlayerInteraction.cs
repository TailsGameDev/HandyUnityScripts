using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Interactable currentInteractable;

    private void Update()
    {
        // Get Interactable from raycast
        RaycastHit raycastHit;
        Interactable interactable = null;
        bool hasRaycastHitSomething = Physics.Raycast(origin: transform.position, direction: transform.forward, out raycastHit, maxDistance: 5.0f);
        if (hasRaycastHitSomething)
        {
            interactable = raycastHit.collider.GetComponent<Interactable>();
        }

        // Update Interactable, displaying/hiding interfaces
        if (currentInteractable != interactable)
        {
            if (currentInteractable != null)
            {
                currentInteractable.HideInterface();
            }

            if (interactable != null)
            {
                interactable.ShowInterface();
            }

            currentInteractable = interactable;
        }

        // Manage Input
        if (Input.GetButtonDown("Fire1") && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }
}
