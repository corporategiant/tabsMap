using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldForceUppercase : MonoBehaviour
{

    public TMP_InputField inputField;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        inputField.onValidateInput += delegate (string s, int i, char c) { return char.ToUpper(c); };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
