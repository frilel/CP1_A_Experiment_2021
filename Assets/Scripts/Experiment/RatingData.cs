using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatingData : MonoBehaviour
{

    private List<int> ratings = new List<int>();
    public Text Result;
    
    public void AddData(int num)
    {
        ratings.Add(num);
    }

    public void ShowResult()
    {
        for (int i = 0; i < ratings.Count; i++)
        {
            Result.text += "Stimuli " + (i + 1).ToString() + ": " + ratings[i] + "\n";
        }

    }
}