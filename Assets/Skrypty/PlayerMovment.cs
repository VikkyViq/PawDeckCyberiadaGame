using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float vertcalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * 3f, rb.velocity.y, vertcalInput * 3f);
        if (Input.GetButtonDown("Jump")) { rb.velocity = new Vector3(rb.velocity.x, 10f, rb.velocity.z); }
      
    }
}
