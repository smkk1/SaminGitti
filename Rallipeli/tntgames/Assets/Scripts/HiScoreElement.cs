using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HiScoreElement 
{
    private string name;
    private float score;

    public HiScoreElement(string aName, float aScore)
    {
        name = aName;
        score = aScore;
    }
    
    public string Name
    {
        get
        {
            return name;
        }
    }
    
    public float Score
    {
        get
        {
            return score;
        }
    }

}
