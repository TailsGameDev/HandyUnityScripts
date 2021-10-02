using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField]
    private GameObject GUI = null;

    public void ShowInterface()
    {
        GUI.SetActive(true);
    }

    public void HideInterface()
    {
        GUI.SetActive(false);
    }

    public abstract void StartInteraction();
}
