using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    private Rigidbody rb;

    public float jump_forward_force = 4500f; // 8500f
    public float jump_up_force = -2500f; // 10000f

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
  


    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            CatapultObj();
        }

        //Debug.Log(rb.velocity.magnitude); // Tulostetaan nopeus

    }




    private void CatapultObj()
    {
        //rb.AddForce(0f, 8500f, 15000f, ForceMode.Impulse);
        rb.AddForce(transform.forward * jump_forward_force, ForceMode.Impulse);
        rb.AddForce(transform.up * jump_up_force, ForceMode.Impulse);
    }
}
