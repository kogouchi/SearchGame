using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public GravityAttractor attractor;
    private Transform mytransform;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
        //rb.useGravity = false;
        mytransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        attractor.Attract(mytransform, rb);
    }
}
