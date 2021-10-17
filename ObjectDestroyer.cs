using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private static ObjectDestroyer instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void DestroyObjectInTime(GameObject gameObjectToDestroy, float timeToDestruction)
    {
        instance.StartCoroutine(instance.DestructionCoroutine(gameObjectToDestroy, timeToDestruction));
    }
    private IEnumerator DestructionCoroutine(GameObject gameObjectToDestroy, float timeToDestruction)
    {
        yield return new WaitForSeconds(timeToDestruction);
        Destroy(gameObjectToDestroy);
    }
}
