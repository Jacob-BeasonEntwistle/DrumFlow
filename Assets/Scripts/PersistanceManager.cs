using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistanceManager : MonoBehaviour
{
    private static PersistanceManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static PersistanceManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PersistanceManager>();

                if (instance == null)
                {
                    GameObject prefab = Resources.Load<GameObject>("Prefabs/ContinuousObject");
                    
                    if (prefab != null)
                    {
                        GameObject obj = Instantiate(prefab);
                        instance = obj.AddComponent<PersistanceManager>();
                    }
                    else
                    {
                        GameObject obj = new GameObject("ContinuousObject");
                        instance = obj.AddComponent<PersistanceManager>();
                    }
                }

                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
}
