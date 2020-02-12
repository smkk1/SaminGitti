using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    
    public GameObject CP1;
    public GameObject CP2;
    public GameObject CP3;
    [SerializeField] public GameObject RaceFinishline;
    public bool cp1check = false;
    public bool cp2check = false;
    public bool cp3check = false;
    public bool ableToFinish = false;

    private void Start()
    {
        RaceFinishline.GetComponent<MeshRenderer>().enabled = false;
    }

    void OnTriggerEnter(Collider collision)

    {

        if (collision.name == "CP1")
        {
            cp1check = true;
            Debug.Log("CP1 checked!");
        }

        if (collision.name == "CP2")
        {
            cp2check = true;
            Debug.Log("CP2 checked!");
        }

        if (collision.name == "CP3")
        {
            cp3check = true;
            Debug.Log("CP3 checked!");
        }

        if (cp1check == true && cp2check == true && cp3check == true)
        {
            ableToFinish = true;
        }
        
        if(collision.gameObject.name == "RaceFinishLine" && ableToFinish == true)
        {
            RaceFinishline.GetComponent<Timer>().RaceFinished();
        }

    }

}