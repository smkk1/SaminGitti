using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarExhaust : MonoBehaviour
{

    [SerializeField]private ParticleSystem psFirst;
    [SerializeField]private ParticleSystem psSecond;
    private ParticleSystem.MainModule psMainFirst;
    private ParticleSystem.MainModule psMainSecond;

    private float carSpeed;

    void Start()
    {
        psMainFirst = psFirst.main;
        psMainSecond = psSecond.main;
    }


    public void UpdateStarLifeTime(float speed)
    {

        if((int)speed != 0)
        {
            carSpeed = (int)(160f / speed) ^ (1 / 4);
            if (carSpeed < 1)
            {
                psMainFirst.startLifetime = 0.1f;
                psMainSecond.startLifetime = 0.1f;
            }
            else
            {
                psMainFirst.startLifetime = carSpeed / 8;
                psMainSecond.startLifetime = carSpeed / 8;
            }
        }
        
    }
}
