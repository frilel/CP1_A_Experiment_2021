using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Image BlackUIBackground;
    
    public GameObject ExperimentMenu;
    public GameObject SettingsMenu;
    public GameObject ControlsMenu;
    public GameObject NextStimulusScreen;

    public Button ExperimentButton;
    public Button SettingsButton;
    public Button ControlsButton;
    public Button ShowNextStimulusButton;
    public Button[] RateButtons;

    private ExperimentManager experimentManager;

    private void Awake()
    {
        experimentManager = FindObjectOfType<ExperimentManager>();

        if(SceneManager.GetActiveScene().name != "ExperimentWarmUp")
            BlackUIBackground.canvasRenderer.SetAlpha(1f);

        ExperimentMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        ControlsMenu.SetActive(false);

        ExperimentButton.onClick.AddListener(OnExperimentClick);
        SettingsButton.onClick.AddListener(OnSettingsClick);
        ControlsButton.onClick.AddListener(OnControlsClick);
        ShowNextStimulusButton.onClick.AddListener(OnShowNextStimulus);
        for(int i=0;i<RateButtons.Length;i++)
        {
            RateButtons[i].onClick.AddListener(OnShowNextStimulus);
        }
    }
    private void OnShowNextStimulus()
    {
        TurnOffMenues();

        if (experimentManager.ShowNextStimulus() == false)
        {
            ShowEndOfExperiment();
        }
    }

    private void ShowEndOfExperiment()
    {
        NextStimulusScreen.SetActive(true);
        BlackUIBackground.canvasRenderer.SetAlpha(1f);

        //foreach (GameObject child in NextStimulusScreen.transform)
        //{
        //    if (child.name == "Instructions")
        //    {
        //        child.GetComponent<Text>().text = "The experiment is over. You may remove the headset and adress the researchers";
        //    }
        //    else if (child.name == "ShowNextStimulus Button")
        //    {
        //        foreach (GameObject grandChild in child.transform)
        //        {
        //            if (grandChild.name == "Text")
        //            {
        //                grandChild.GetComponent<Text>().text = "Exit application";
        //                grandChild.GetComponent<Button>().onClick.AddListener(() => { Application.Quit(); });
        //            }
        //        }
        //    }
        //}
    }

    private void OnExperimentClick()
    {
        ExperimentMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        ControlsMenu.SetActive(false);
    }

    private void OnSettingsClick()
    {
        ExperimentMenu.SetActive(false);
        SettingsMenu.SetActive(true);
        ControlsMenu.SetActive(false);
    }

    private void OnControlsClick()
    {
        ExperimentMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        ControlsMenu.SetActive(true);
    }

    private void ToggleBlackScreen(bool active)
    {
        if(active)
            BlackUIBackground.CrossFadeAlpha(1f, 1f, false);
        else
            BlackUIBackground.CrossFadeAlpha(0f, 1f, false);
    }

    private void ToggleButtons(bool active)
    {
        ExperimentButton.gameObject.SetActive(active);
        SettingsButton.gameObject.SetActive(active);
        ControlsButton.gameObject.SetActive(active);
    }

    private void TurnOnExperimentMenu()
    {
        ExperimentMenu.SetActive(true);
        SettingsMenu.SetActive(false);
        ControlsMenu.SetActive(false);
    }

    public void TurnOffMenues()
    {
        ToggleBlackScreen(false);
        ToggleButtons(false);

        ExperimentMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        NextStimulusScreen.SetActive(false);
    }

    public void TurnOnMenues()
    {
        ToggleBlackScreen(true);
        ToggleButtons(true);

        TurnOnExperimentMenu();
    }

    public void WaitForNextStimulus()
    {
        ToggleBlackScreen(true);

        NextStimulusScreen.SetActive(true);
    }

}
