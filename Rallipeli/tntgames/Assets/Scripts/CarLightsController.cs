using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLightsController : MonoBehaviour
{
    [SerializeField]
    private GameObject tailLights;
    private InputManager im;

    void Start()
    {
        tailLights.SetActive(false);
        im = FindObjectOfType<InputManager>();
    }

    void Update()
    {
        tailLights.SetActive(im.space);  
    }
    public void TailLights(bool x)
    {
        tailLights.SetActive(x);
    }
}
