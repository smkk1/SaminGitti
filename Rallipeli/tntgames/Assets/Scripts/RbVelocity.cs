using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RbVelocity : MonoBehaviour
{
    private Rigidbody rb;
    private SpeedometerUI speedUI;
    private CarExhaust carExhaust;
    public float carSpeed;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speedUI = FindObjectOfType<SpeedometerUI>();
        carExhaust = FindObjectOfType<CarExhaust>();
    }

    void FixedUpdate()
    {
        speedUI.updateSpeed(rb.velocity.magnitude * 3.6f);
        carExhaust.UpdateStarLifeTime(rb.velocity.magnitude * 3.6f);
        carSpeed = rb.velocity.magnitude * 3.6f;

    }

}
