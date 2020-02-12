using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    
    [SerializeField]private Text textBox;

    public float timeStart;
    public bool raceStarted = false;
    public static Timer singleton = null;
    public Checkpoint check;

    void Start()
    {
        textBox.text = timeStart.ToString("F2");
    }

    void Update()
    {
        if (raceStarted)
        {
            timeStart += Time.deltaTime;
            textBox.text = timeStart.ToString("F2");
        }
    }
    void DontDestroy()
    {
        DontDestroyOnLoad(this.gameObject);
        if (singleton == null)
        {
            singleton = this;
        }
    }
    

    public void TurnRaceOn()
    {
        raceStarted = true;
    }
    

    public void RaceFinished()
    {
        FindObjectOfType<AudioManager>().Play("Fireworks");
        DontDestroy();
        raceStarted = !raceStarted;
        SceneManager.LoadScene(2);
    }

}
