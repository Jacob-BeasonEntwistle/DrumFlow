using UnityEngine;

public class PersistanceManager : MonoBehaviour
{
    public static PersistanceManager Instance { get; private set; }

    public etee.eteeAPI api;
    public etee.eteeDevice leftDevice;
    public etee.eteeDevice rightDevice;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        api = transform.Find("eteeAPI/API").GetComponent<etee.eteeAPI>();
        leftDevice = transform.Find("eteeAPI/LeftDevice").GetComponent<etee.eteeDevice>();
        rightDevice = transform.Find("eteeAPI/RightDevice").GetComponent<etee.eteeDevice>();
    }
}