using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatingData : MonoBehaviour
{

    private List<int> ratings = new List<int>();
    public Text Result1;
    public Text Result2;
    public Text Result3;
    
    public void AddData(int num)
    {
        ratings.Add(num);
    }

    public void ShowResult()
    {
        for (int i = 0; i < ratings.Count; i++)
        {
            if(i<9)
            {
                Result1.text += "Stimuli " + (i + 1).ToString() + ": " + ratings[i] + "\n";
            }
            else if(i<18)
            {
                Result2.text += "Stimuli " + (i + 1).ToString() + ": " + ratings[i] + "\n";            
            }
            else
            {
                Result3.text += "Stimuli " + (i + 1).ToString() + ": " + ratings[i] + "\n";

            }
            


        }

    }
}