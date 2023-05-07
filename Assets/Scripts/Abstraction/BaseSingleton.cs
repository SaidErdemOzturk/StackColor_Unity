using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//monobehaivor mu olmal� yoksa singleton<t> mi olmal�?
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    private void Awake()
    {
        CreateInstance();
    }

    public static T GetInstance()
    {
        if(instance == null)
        {
            CreateInstance();
        }
        return instance;
    }

    private static void CreateInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<T>();
        }
        else if (instance != FindObjectOfType<T>())
        {
            Destroy(FindObjectOfType<T>());
        }
    }
}