using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInteraction : MonoBehaviour
{
    private enum InputType
    {
        MOUSE,
        KEYBOARD_CONTROLLER,
    }

    [SerializeField]
    private Transform raycastHitPointImage = null;

    [SerializeField]
    [Tooltip("Enter the string for the Input. Note in case of mouse buttons, the string will ger Parsed.")]
    private string interactionInput = null;

    [SerializeField]
    private InputType inputType = 0;

    [SerializeField]
    private float raycastMaxDistance = 0.0f;

    private Interactable currentInteractable;

    protected Interactable CurrentInteractable 
    { 
        get => currentInteractable; 
    }

    protected virtual void Update()
    {
        // Get Interactable from raycast
        RaycastHit raycastHit;
        Interactable interactable = null;
        bool hasRaycastHitSomething = Physics.Raycast(origin: transform.position, direction: transform.forward, 
                                                        out raycastHit, maxDistance: raycastMaxDistance);
        if (hasRaycastHitSomething)
        {
            interactable = raycastHit.collider.GetComponent<Interactable>();

            // Position and Rotate raycastEndImage
            if (raycastHitPointImage != null)
            {
                raycastHitPointImage.position = raycastHit.point + (raycastHit.normal * 0.01f);
                raycastHitPointImage.forward = raycastHit.normal;
            }

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

        if (HasInputBeenPressed() && currentInteractable != null)
        {
            currentInteractable.StartInteraction();
        }

        raycastHitPointImage.gameObject.SetActive( ShouldDisplayRaycastHitPointImage(hasRaycastHitSomething) );
    }

    protected bool HasInputBeenPressed()
    {
        bool hasInputBeenPressed;
        if (inputType == InputType.MOUSE)
        {
            hasInputBeenPressed = Input.GetMouseButtonDown(System.Int32.Parse(interactionInput));
        }
        else
        {
            hasInputBeenPressed = Input.GetButtonDown(interactionInput);
        }
        return hasInputBeenPressed;
    }

    protected abstract bool ShouldDisplayRaycastHitPointImage(bool hasRaycastHitSomething);
}
