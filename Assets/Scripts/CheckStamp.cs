using UnityEngine;
using TMPro;
public class CheckStamp : MonoBehaviour
{
    public int StampNumber;
    public string username;
    public string StudentID;
    public GameObject[] Stamps;
    public TextMeshProUGUI usernametext;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartCheckStamp()
    {
        username = PlayerPrefs.GetString("username");
        StudentID = PlayerPrefs.GetString("StudentID");
        StampNumber = PlayerPrefs.GetInt(username + StudentID + "StampNumber");
        usernametext.text = username;
        for (int i = 0; i < StampNumber && i < Stamps.Length; i++)
        {
            if (Stamps[i] != null) // Check if the element is not null
            {
                Stamps[i].SetActive(true);
            }
        }

    }


}
