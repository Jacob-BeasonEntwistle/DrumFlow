using UnityEngine;

public class CreateContinuousObject : MonoBehaviour
{
    private void Awake()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/ContinuousObject");

        if (prefab != null)
        {
            GameObject obj = Instantiate(prefab);
            DontDestroyOnLoad(obj);
        }
    }
}