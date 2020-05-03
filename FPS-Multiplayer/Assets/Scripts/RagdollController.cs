using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetKinematic(true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SetKinematic(bool newValue)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.useGravity = !newValue;
            rb.isKinematic = newValue;
        }
    }
}