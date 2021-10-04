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

    [SerializeField]
    private UnityEvent onEnd = null;

    private void OnEnable()
    {
        onBegin?.Invoke();
    }
    private void OnDisable()
    {
        onEnd?.Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            gameObject.SetActive(false);
        }
    }
}
