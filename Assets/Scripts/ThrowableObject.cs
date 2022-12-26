using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    public Rigidbody rigidbody;

    public void Throw()
    {
        rigidbody.isKinematic = false;
        rigidbody.AddForce((Vector3.forward + Vector3.up).normalized * 20f, ForceMode.Impulse);
    }
}
