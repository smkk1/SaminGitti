using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffset : MonoBehaviour
{

    public static Vector3 cameraOffset = new Vector3(0f,0f,0f);
    public static CameraOffset instance;


    void Start()
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
    
    public void NewCameraOffset(Vector3 aCameraOffset)
    {
        cameraOffset = aCameraOffset;
    }

    public Vector3 GetCameraOffset()
    {
        return cameraOffset;
    }

    public static void UpdateCameraOffset(int aCameraOffset)
    {
        if(aCameraOffset == 0)
        {
            cameraOffset = new Vector3(0f, 4.59f, -8.14f);
        }
        else if(aCameraOffset == 1)
        {
            cameraOffset = new Vector3(0f, 15f, 0f);
        }
        else if (aCameraOffset == 2)
        {
            cameraOffset = new Vector3(0f, 25f, 0f);
        }
    }
}
