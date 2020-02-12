using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class HiScoreList{

    public List<HiScoreElement> hiScoreList;

    public void AddToList(HiScoreElement aElement) {
        int count = 0;

        if (hiScoreList.Count == 0)
        {
            hiScoreList.Add(aElement);
            return;
        }
        foreach (var list in hiScoreList)
        {
            if(aElement.Score <= list.Score)
            {
                hiScoreList.Insert(count, aElement);
                if (hiScoreList.Count >= 21)
                {
                    hiScoreList.RemoveAt(20);
                    return;
                }
                return;
            }
            count++;
        }
        hiScoreList.Insert(count, aElement);

        if (hiScoreList.Count >= 21)
        {
            hiScoreList.RemoveAt(20);
            return;
        }

    }


}
