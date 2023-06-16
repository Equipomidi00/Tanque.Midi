using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public bool destroid;

    private void Start()
    {
        destroid = false;
    }
    void Update()
    {
        if (destroid)
            Destroy(gameObject);
    }
}
