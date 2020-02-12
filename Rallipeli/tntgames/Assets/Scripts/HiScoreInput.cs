using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HiScoreInput : MonoBehaviour
{
    [SerializeField]List<GameObject> listOfLetters = new List<GameObject>();
    [SerializeField] Text scoreText;
    public int selectedLetter = 0;
    int numberOfLetters = 3;
    int AlphaBet = 0;
    public float raceFinishTime;
    private GameObject RaceFinishLineGameObject;
    public bool end = false;

    void OnEnable()
    {
        RaceFinishLineGameObject = GameObject.Find("RaceFinishLine");
        raceFinishTime = RaceFinishLineGameObject.GetComponent<Timer>().timeStart;
        raceFinishTime = (float)Math.Round(raceFinishTime, 2);
        scoreText.text = raceFinishTime.ToString();
        Destroy(RaceFinishLineGameObject);
    }


    void Update()
    {

    }

    public void NextAlphaBet() {
        if (AlphaBet < 25)
        {
            AlphaBet++;
        }
        char word = (char)(AlphaBet + 65);
        listOfLetters[selectedLetter].GetComponent<Text>().text = word.ToString();
    }


    public void PrevAlphaBet() {
        if (AlphaBet > 0)
        {
            AlphaBet--;
        }
        char word = (char)(AlphaBet + 65);
        listOfLetters[selectedLetter].GetComponent<Text>().text = word.ToString();

    }

    public void NextLetter() {
        if (selectedLetter == 2)
        {
            HiScore.Instance.Save(listOfLetters[0].GetComponent<Text>().text + listOfLetters[1].GetComponent<Text>().text + listOfLetters[2].GetComponent<Text>().text, raceFinishTime);
            end = true;

        }
        else
        {
            listOfLetters[selectedLetter].GetComponent<Animator>().enabled = false;
            selectedLetter += 1;
            listOfLetters[selectedLetter].GetComponent<Animator>().enabled = true;
        }
        

        
        
    }
}
