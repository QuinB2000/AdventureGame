using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class GameController : MonoBehaviour
{
    void Start()
    {
        DisplayScenarioText();
        DisplayLoggedText();
    }


    public Text displayText;
    public InputAction[] inputActions;

    [HideInInspector] public ScenarioNavigation scenarioNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInScenario = new List<string>();

    List<string> actionLog = new List<string>();

    private void Awake()
    {
        scenarioNavigation = GetComponent<ScenarioNavigation>();

    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());

        displayText.text = logAsText;
    }

    public void DisplayScenarioText()
    {
        
        ClearCollectionsForNewScenario();
        UnpackScenario();

        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInScenario.ToArray());

        string combinedText = scenarioNavigation.currentScenario.text + "\n" + joinedInteractionDescriptions;

        LogStringWithReturn(combinedText);
    }

    void UnpackScenario()
    {
        scenarioNavigation.UnpackNextScenarios();
    }

    void ClearCollectionsForNewScenario()
    {
        interactionDescriptionsInScenario.Clear();
        scenarioNavigation.ClearNextScenarios();
    }



    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }
}
