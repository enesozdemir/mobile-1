using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public Rigidbody rb;
    public Transform parentPickup;
    public Transform stackPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crates")
        {
            Transform otherTransform = other.transform;

            Rigidbody otherRB = otherTransform.GetComponent<Rigidbody>();
            
            otherRB.isKinematic = true;
            other.enabled = false;
            if (parentPickup == null)
            {
                parentPickup = otherTransform;
                parentPickup.position = stackPosition.position;
                parentPickup.parent = stackPosition;
            }
            else
            {
                parentPickup.position += Vector3.up * (otherTransform.localScale.y);
                otherTransform.position = stackPosition.position;
                otherTransform.parent = parentPickup;
            }
        }
    }
}
