using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Message : MonoBehaviour
{
    [SerializeField]
    private Message nextMessage = null;

    [SerializeField]
    private UnityEvent onBegin = null;

    private void OnEnable()
    {
        onBegin?.Invoke();
    }

    private void Update()
    {
        
    }
}
