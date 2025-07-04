using UnityEngine;
using UnityEngine.UI;
public class TextInput : MonoBehaviour
{
    public InputField inputField;
    GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController>();
        inputField.onEndEdit.AddListener (AcceptStringInput);
    }

    void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower();
        controller.LogStringWithReturn(userInput);

        char[] delimiterCharacters = { ' ' };
        string[] seperatedInputWords = userInput.Split(delimiterCharacters);

        for (int i = 0; i < controller.inputActions.Length; i++) 
        {
            InputAction inputAction = controller.inputActions[i];
            if (inputAction.keyWord == seperatedInputWords[0]) 
            {
                inputAction.RespondToInput(controller, seperatedInputWords);
            }
        }

        InputComplete();
    }

    void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }
}
