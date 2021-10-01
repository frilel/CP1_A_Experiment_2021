using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatingData : MonoBehaviour
{
    public List<int> ratings = new List<int>();
    public Text result;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddData(int num)
    {
        ratings.Add(num);
    }
    public void ShowResult()
    {
        for (int i = 0; i < ratings.Count; i++)
        {
            result.text += "Stimuli " + (i + 1).ToString() + ": " + ratings[i] + "\n";
        }

    }
}