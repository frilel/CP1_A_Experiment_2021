using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExperimentMenuController : MonoBehaviour
{
    public Button StartExperimentButton;

    private MenuController MenuController;
    private ExperimentManager ExperimentManager;

    private void Awake()
    {
        StartExperimentButton.onClick.AddListener(StartExperimentClick);
        MenuController = FindObjectOfType<MenuController>();
        ExperimentManager = FindObjectOfType<ExperimentManager>();
    }

    private void StartExperimentClick()
    {
        MenuController.TurnOffMenues();
        ExperimentManager.StartExperiment();
    }

    public void EndWarmUp()
    {
        SceneManager.LoadScene("Experiment1");
    }
}
