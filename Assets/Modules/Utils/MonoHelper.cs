using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MonoHelper : MonoBehaviour
{
    public static MonoHelper singleton = null;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;

            if (Application.isPlaying)
            {
                DontDestroyOnLoad(this);
            }
        }
        else
        {
            if (Application.isPlaying)
            {
                Destroy(gameObject);
            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }


    }

    private void OnDestroy()
    {
        if (singleton == this)
        {
            singleton = null;
        }
    }

    public static Coroutine Run(IEnumerator coroutine)
    {
        if (singleton == null)
        {
            CreateInstance();
        }
        return singleton.GetComponent<MonoBehaviour>().StartCoroutine(coroutine);
    }

    public static void Stop(Coroutine coroutine)
    {
        if (singleton == null)
        {
            CreateInstance();
        }
        singleton.GetComponent<MonoBehaviour>().StopCoroutine(coroutine);
    }

    private static void CreateInstance()
    {
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<MonoHelper>();
        gameObject.name = "MonoHelper";
    }

}