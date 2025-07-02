using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ScenarioNavigation : MonoBehaviour
{
    public Scenario currentScenario;

    Dictionary<string, Scenario> nextScenarioDictionary = new Dictionary<string, Scenario> ();
    GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public void UnpackNextScenarios()
    {
        for (int i = 0; i < currentScenario.nextScenarios.Length; i++)
        {
            nextScenarioDictionary.Add(currentScenario.nextScenarios[i].keyString, currentScenario.nextScenarios[i].valueScenario);
            controller.interactionDescriptionsInScenario.Add(currentScenario.nextScenarios[i].exitDescription);
        }
    }

    public void AttemptToChangeScenario(string directionNoun)
    {
        if(nextScenarioDictionary.ContainsKey(directionNoun))
        {
            currentScenario = nextScenarioDictionary[directionNoun];
            controller.LogStringWithReturn("Turn the page");
            controller.DisplayScenarioText();
        }else
        {
            controller.LogStringWithReturn("There is no such option");
        }
    }

    public void ClearNextScenarios()
    {
        nextScenarioDictionary.Clear();
    }

}
