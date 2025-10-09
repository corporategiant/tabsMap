using UnityEngine;

public class ResetInput : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerPrefs.SetInt("QuestionNo",1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
