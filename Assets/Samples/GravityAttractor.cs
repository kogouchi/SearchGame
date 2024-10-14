using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public float gravity = -10;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.constraints = RigidbodyConstraints.FreezePosition;
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
        //rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attract(Transform body, Rigidbody rb)
    {
        Vector3 gravityup = (body.position - transform.position).normalized;
        Vector3 bodyup = body.up;

        rb.AddForce(gravityup * gravity);
        //body.rb.AddForce(gravityup * gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(
            bodyup, gravityup) * body.rotation;

        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
