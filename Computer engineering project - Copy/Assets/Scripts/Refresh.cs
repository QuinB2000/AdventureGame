using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Refresh")]
public class Refresh : InputAction
{
    public override void RespondToInput(GameController controller, string[] seperatedInputWords)
    {
        controller.DisplayScenarioText();
    }
}
