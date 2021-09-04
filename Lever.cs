using UnityEngine;

public class Lever : Interactable
{
    [SerializeField]
    private float rotationAmount = 0.0f;

    private Vector3 originalRotation;

    private void Awake()
    {
        originalRotation = transform.eulerAngles;
    }

    public override void Interact()
    {
        const float TOLERANCE = 1.0f;
        bool isLeverRotated = (transform.eulerAngles - originalRotation).sqrMagnitude > TOLERANCE;
        if (isLeverRotated)
        {
            transform.eulerAngles = originalRotation;
        }
        else
        {
            transform.eulerAngles = originalRotation + (Vector3.forward * rotationAmount);
        }
    }
}
