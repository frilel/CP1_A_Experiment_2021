using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatingData : MonoBehaviour
{

    private List<RateData> ratings = new List<RateData>();
    public Text Result1;
    public Text Result2;

    public void AddData(int num)
    {
        string name = FindObjectOfType<ExperimentManager>().CurrentStimuliName;
        ratings.Add(new RateData(name, num));
    }

    public void ShowResult()
    {
        for (int i = 0; i < ratings.Count; i++)
        {
            if (i < 9)
            {
                Result1.text += ratings[i].name + ": " + ratings[i].num + "\n";
            }
            else
            {
                Result2.text += ratings[i].name + ": " + ratings[i].num + "\n";       
            }
            /*else
            {
                Result3.text += "Stimuli " + (i + 1).ToString() + ": " + ratings[i] + "\n";

            }*/



        }

    }
}
public class RateData
{
    public string name;
    public int num;
    public RateData(string n, int numb)
    {
        name = n;
        num = numb;
    }

}