using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighted : MonoBehaviour
{
    public Material original;
    public Material highlighted;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = original;
    }

    private void OnTriggerEnter(Collider other)
    {
        rend.material = highlighted;
    }

    private void OnTriggerExit(Collider other)
    {
        rend.material = original;
    }
}
