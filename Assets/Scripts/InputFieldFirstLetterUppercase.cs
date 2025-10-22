using UnityEngine;
using TMPro;

public class inputFieldFirstLetterUppercase : MonoBehaviour
{
    public TMP_InputField inputField;

    void Start()
    {
        // Get the TMP_InputField component if not assigned in the Inspector
        if (inputField == null)
        {
            inputField = GetComponent<TMP_InputField>();
        }

        // Subscribe to the onValueChanged event
        if (inputField != null)
        {
            inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
        }
    }

    void OnInputFieldValueChanged(string newText)
    {
        if (string.IsNullOrEmpty(newText))
        {
            return; // Do nothing if the string is empty
        }

        string formattedText = "";

        // Capitalize the first letter
        formattedText += char.ToUpper(newText[0]);

        // Convert the rest of the letters to lowercase
        if (newText.Length > 1)
        {
            formattedText += newText.Substring(1).ToLower();
        }

        // Only update if the text actually changed to avoid infinite loops
        if (inputField.text != formattedText)
        {
            inputField.text = formattedText;
            // Set caret position to the end of the text
            inputField.caretPosition = formattedText.Length;
        }
    }
}