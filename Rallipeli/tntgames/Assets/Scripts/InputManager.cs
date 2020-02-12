using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class InputManager : MonoBehaviour
{


    private string scene;

    public float horizontalInput;
    public float verticalInput;
    public bool space;
    public bool escape;
    
    private bool inputOn = false;

    private float gyroX = 0f, gyroY = 0f, gyroZ = 0f;

    public float gyroAcclerate = 0;
    public float gyroBack = 0;
    public Quaternion t;
    public Quaternion previusRotation = new Quaternion(0f, 0f, 0f, 0f);
    public Vector3 axis = new Vector3(0f, 0f, 0f);

    public float vasen = 0f, oikea = 0f;


    public static InputManager instance;

    [SerializeField]
    public GameObject cuuppa;

    [SerializeField]
    public Quaternion previouscurrent;

    [SerializeField]
    public Quaternion current;

    [SerializeField]
    public float kulmio;

    [SerializeField]
    public Vector3 akselit;


    Queue<float> dot = new Queue<float>();
    float sum = 0;
    Queue<float> rotation = new Queue<float>();
    float kokonaisrotation = 0f;

    private void Start()
    {
        

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }


    }

    private void FixedUpdate()
    {

    }

    public void updateValues(string[] values)
    {
        
        gyroX = float.Parse(values[0]);
        gyroY = float.Parse(values[1]);
        gyroZ = float.Parse(values[2]);

        vasen = float.Parse(values[10]);
        oikea = float.Parse(values[4]);

        if(oikea == 1)
        {
            horizontalInput = 1;
        }

        if (vasen == 1)
        {
            horizontalInput = -1;
        }

        if(oikea == 0 && vasen == 0)
        {
            horizontalInput = 0;
        }

        Debug.Log("v: " + vasen);
        Debug.Log("o: " + oikea);

       


        gyroBack = float.Parse(values[8]);
        gyroAcclerate = float.Parse(values[6]);
        
        if (gyroAcclerate == 1 && gyroBack == 1)
        {
            space = true;

        }
        else if (gyroAcclerate == 1 && gyroBack == 0)
        {
            verticalInput = 1;
            space = false;

        }
        else if (gyroBack == 1 && gyroAcclerate == 0)
        {
            space = false;
            verticalInput = -1;

        }
        else
        {
            space = false;
            verticalInput = 0;

        }




    }

    public void TurnInputOn()
    {
        inputOn = true;
    }
    
    void Update()
    {
        
        escape = Input.GetKeyDown(KeyCode.Escape);
        if (inputOn)
        {
            //horizontalInput = Input.GetAxis("Horizontal");
            //verticalInput = Input.GetAxis("Vertical");
           
            //space = Input.GetKey(KeyCode.Space);

        }

    }

}
