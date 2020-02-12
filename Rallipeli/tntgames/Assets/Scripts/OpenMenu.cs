using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    private GameObject ui_canvas;
    private InputManager im;

    void Start()
    {
        ui_canvas = GameObject.Find("Menu");
        ui_canvas.GetComponent<Canvas>().enabled = false;
        im = FindObjectOfType<InputManager>();
    }

    void Update()
    {
        if (im.escape)
        {
            if (ui_canvas.GetComponent<Canvas>().enabled)
            {
                ui_canvas.GetComponent<Canvas>().enabled = false;
            }
            else
            {
                ui_canvas.GetComponent<Canvas>().enabled = true;
            }
        }

    }
}
