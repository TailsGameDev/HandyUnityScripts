using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private enum InputType
    {
        MOUSE,
        KEYBOARD_CONTROLLER,
    }

    [SerializeField]
    [Tooltip("Enter the string for the Input. Note in case of mouse buttons, the string will ger Parsed.")]
    private string interactionInput = null;

    [SerializeField]
    private InputType inputType = 0;

    [SerializeField]
    private float raycastMaxDistance = 0.0f;

    private Interactable currentInteractable;

    private void Update()
    {
        // Get Interactable from raycast
        RaycastHit raycastHit;
        Interactable interactable = null;
        bool hasRaycastHitSomething = Physics.Raycast(origin: transform.position, direction: transform.forward, 
                                                        out raycastHit, maxDistance: raycastMaxDistance);
        if (hasRaycastHitSomething)
        {
            interactable = raycastHit.collider.GetComponent<Interactable>();
            
            // TODO: Display little dot or similar in the point of interest.
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
        bool hasInputBeenPressed;
        if (inputType == InputType.MOUSE)
        {
            hasInputBeenPressed = Input.GetMouseButtonDown(System.Int32.Parse(interactionInput));
        }
        else
        {
            hasInputBeenPressed = Input.GetButtonDown(interactionInput);
        }

        if (hasInputBeenPressed && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }
}
