using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/Scenario")]
public class Scenario : ScriptableObject
{
    [TextArea]
    public string text;
    public string scenarioName;
    public NextScenario[] nextScenarios;
}
