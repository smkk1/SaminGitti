using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour {

    [SerializeField] private GameObject hiScoreTable;
    [SerializeField] private GameObject hiScoreElement;
    [SerializeField] private GameObject hiScoreBoard;
    [SerializeField] private GameObject hiScoreInput;
    List<HiScoreElement> list = new List<HiScoreElement>();
    HiScoreList hiScoreStore;

    private static HiScore instance;
    public static HiScore Instance {
        get {
            return instance;
        }
    }
    void Start() {
        instance = this;

        hiScoreStore = ReadScore();


        UpdateScoreBoard(hiScoreStore.hiScoreList);

        hiScoreInput.gameObject.SetActive(true);
        hiScoreInput.gameObject.SetActive(false);

        if (hiScoreInput.GetComponent<HiScoreInput>().raceFinishTime != 0f)
        {
            
            hiScoreInput.gameObject.SetActive(true);
        }
        else
        {
            hiScoreBoard.SetActive(true);
            hiScoreElement.gameObject.SetActive(true);
        }

    }


    void UpdateScoreBoard(List<HiScoreElement> aList) {

        hiScoreElement.GetComponent<Text>().text = "";

        string holeList = "";
        foreach (var item in aList)
        {
            holeList += item.Name.ToString() + " ";
            holeList += item.Score.ToString();
            holeList += Environment.NewLine;
        }
        hiScoreElement.GetComponent<Text>().text = holeList;

    }

    public void Save(string aName, float aScore) {

        
        hiScoreStore.AddToList(new HiScoreElement(aName, aScore));

        SaveScoreBoard(hiScoreStore);


        hiScoreInput.gameObject.SetActive(false);

        UpdateScoreBoard(hiScoreStore.hiScoreList);

        hiScoreBoard.SetActive(true);
        hiScoreElement.gameObject.SetActive(true);

    }


    public void SaveScoreBoard(HiScoreList aSb) {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/s002.save");
        bf.Serialize(file, aSb);
        file.Close();
    }

    HiScoreList ReadScore() {
        HiScoreList sb = null;

        if (File.Exists(Application.persistentDataPath + "/s002.save")) {


            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/s002.save", FileMode.Open);
            sb = (HiScoreList)bf.Deserialize(file);
            file.Close();

        } else {
            sb = new HiScoreList();
            sb.hiScoreList = new List<HiScoreElement>();
            //sb.AddToList(new HiScoreElement("ABC", (float)15.12));
            //sb.AddToList(new HiScoreElement("CCC", (float)10.43));
            //sb.AddToList(new HiScoreElement("DDD", (float)5.54));
            //sb.AddToList(new HiScoreElement("EEE", (float)2.34));
            SaveScoreBoard(sb);
        }
        return sb;
    }
}
