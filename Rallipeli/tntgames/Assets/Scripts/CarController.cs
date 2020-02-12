using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class CarController : MonoBehaviour {

    
    [SerializeField]private InputManager im;
    [SerializeField]private WheelCollider frontDriverW, frontPassengerW;
    [SerializeField]private WheelCollider backDriverW, backPassengerW;
    [SerializeField]private Transform frontDriverT, frontPassangerT;
    [SerializeField]private Transform backDriverT, backPassangerT;
    [SerializeField]private float motorForce = 800f;
    [SerializeField]private Transform centreofmass;
    private float maxSteerAngle = 40;
    private float steeringAngle;
    private Rigidbody rb;
    private float ts;
    private AudioManager audioManager;



    public void Steer()
    {

        steeringAngle = maxSteerAngle * im.horizontalInput;
        frontDriverW.steerAngle = steeringAngle;
        frontPassengerW.steerAngle = steeringAngle;

    }

    public void AcclerateAndBrake()
    {

        backDriverW.motorTorque = im.verticalInput * motorForce;
        backPassengerW.motorTorque = im.verticalInput * motorForce;
        frontDriverW.motorTorque = im.verticalInput * motorForce;
        frontPassengerW.motorTorque = im.verticalInput * motorForce;
        backDriverW.brakeTorque = 0;
        backPassengerW.brakeTorque = 0;
        rb.drag = 0;
        if (backPassengerW.motorTorque > 0)
        {
            if (!audioManager.CheckPlay("Car"))
            {
                audioManager.Play("Car");
            }
        }
        /*
        if (backPassengerW.motorTorque > 0)
        {
            if (!audioManager.CheckPlay("Car"))
            {
                audioManager.StopSound("Brake");
                audioManager.Play("Car");
                //Debug.Log(backPassengerW.motorTorque);
            }
        }
        */
        audioManager.ChangeSoundPitch("Car", frontPassengerW.motorTorque);
        if (im.space)
        {
            backDriverW.motorTorque = 0;
            backPassengerW.motorTorque = 0;
            frontDriverW.motorTorque = 0;
            frontPassengerW.motorTorque = 0;
            backDriverW.brakeTorque = 5000;
            backPassengerW.brakeTorque = 5000;
            rb.drag = 1;
            audioManager.Play("Brake");
        }
        
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassangerT);
        UpdateWheelPose(backDriverW, backDriverT);
        UpdateWheelPose(backPassengerW, backPassangerT);
    }


    private void UpdateWheelPose(WheelCollider collider, Transform transform)
    {
        Vector3 pos = transform.position;
        Quaternion quat = transform.rotation;

        collider.GetWorldPose(out pos, out quat);

        transform.position = pos;
        transform.rotation = quat; 
        
    }

    private void FixedUpdate()
    {
        Steer();
        AcclerateAndBrake();
        UpdateWheelPoses();
    }

    private void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centreofmass.localPosition;
        rb = GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();
        im = FindObjectOfType<InputManager>();
        
    }

}
