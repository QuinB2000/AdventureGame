using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Go")]
public class Go : InputAction
{
    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        controller.scenarioNavigation.AttemptToChangeScenario(seperatedInputWords[1]);  
    }
}
