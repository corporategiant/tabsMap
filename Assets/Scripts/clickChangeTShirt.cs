using UnityEngine;

public class clickChangeTShirt : MonoBehaviour
{

    public GameObject TShirt;

    public string username;
    public string StudentID;

    public bool TShirtIsOn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        username = (PlayerPrefs.GetString("username"));
        StudentID = (PlayerPrefs.GetString("StudentID"));

        if (PlayerPrefs.GetInt(username + StudentID + "TShirtIsOn") == 1)
        {
            TShirt.SetActive(true);
            TShirtIsOn = true;

        }
        else if (PlayerPrefs.GetInt(username + StudentID + "TShirtIsOn") == 0)
        {
            TShirt.SetActive(false);
            TShirtIsOn = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt(username + StudentID + "TShirtIsOn") == 1)
        {
            TShirt.SetActive(true);

        }

        else if (PlayerPrefs.GetInt(username + StudentID + "TShirtIsOn") == 0)
        {
            TShirt.SetActive(false);

        }
    }

    void OnMouseDown()
    {
        if (TShirtIsOn == false)
        {
            TShirt.SetActive(true);
            TShirtIsOn = true;
            PlayerPrefs.SetInt(username + StudentID + "TShirtIsOn", 1);
        }

        else if (TShirtIsOn == true)
        {
            TShirt.SetActive(false);
            TShirtIsOn = false;
            PlayerPrefs.SetInt(username + StudentID + "TShirtIsOn", 0);
        }
    }
}

