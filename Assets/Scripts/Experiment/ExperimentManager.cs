using UnityEngine;



public class ExperimentManager : MonoBehaviour
{
    public bool RunningExperiment { get; private set; } = false;

    public float ExperimentTime = 5f;
    public GameObject[] Stimuli;

    private MenuController MenuController;
    private float startTime = 0f;
    private int stimuliCounter = 0;

    public string CurrentStimuliName;

    private void Start()
    {
        MenuController = FindObjectOfType<MenuController>();
        ShuffleStimuli();
    }
    private void ShuffleStimuli()
    {
        for(int i=0;i<9;i++)
        {
            int switchNum=Random.Range(0,9);
            GameObject current=Stimuli[i];
            Stimuli[i]=Stimuli[switchNum];
            Stimuli[switchNum]=current;
        }
    }
    
    private void Update()
    {
        if(RunningExperiment && Time.time - startTime > ExperimentTime)
        {
            WaitForNextStimulus();
        }
    }
    public void StartExperiment()
    {
        MenuController.TurnOffMenues();
        ShowNextStimulus();
    }
    //public void StopExperiment()
    //{
    //    RunningExperiment = false;
    //    MenuController.TurnOnMenues();
    //}
    public void WaitForNextStimulus()
    {
        RunningExperiment = false;

        // Deactivate previous stimulus if this isn't the first stimulus
        if (stimuliCounter != 0)
        {
            GameObject go = (GameObject)Stimuli.GetValue(stimuliCounter - 1);
            go.SetActive(false);
        }

        MenuController.WaitForNextStimulus();
    }
    public bool ShowNextStimulus()
    {
        if (stimuliCounter >= Stimuli.Length)
            return false;
        
        // Activate new stimulus
        GameObject go = (GameObject)Stimuli.GetValue(stimuliCounter);
        go.SetActive(true);
        CurrentStimuliName=go.name;

        if (go.name == "RateResultScreen")
        {
            FindObjectOfType<RatingData>().ShowResult();
            return false;
        }

        stimuliCounter++;
        startTime = Time.time;
        RunningExperiment = true;

        

        return true;
    }
}
