using UnityEngine;

public class clickChangeGlasses : MonoBehaviour
{

    public GameObject GlassesRound;
    public GameObject GlassesSquare;

    public string username;
    public string StudentID;

    public bool GlassesRoundIsOn;
    public bool GlassesSquareIsOn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        username = (PlayerPrefs.GetString("username"));
        StudentID = (PlayerPrefs.GetString("StudentID"));

        if (PlayerPrefs.GetInt(username + StudentID + "GlassesRoundIsOn") == 1)
        {
            GlassesRound.SetActive(true);
            GlassesRoundIsOn = true;

        }
        else if (PlayerPrefs.GetInt(username + StudentID + "GlassesRoundIsOn") == 0)
        {
            GlassesRound.SetActive(false);
            GlassesRoundIsOn = false;
        }

        if (PlayerPrefs.GetInt(username + StudentID + "GlassesSquareIsOn") == 1)
        {
            GlassesSquare.SetActive(true);
            GlassesSquareIsOn = true;

        }
        else if (PlayerPrefs.GetInt(username + StudentID + "GlassesSquareIsOn") == 0)
        {
            GlassesSquare.SetActive(false);
            GlassesSquareIsOn = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt(username + StudentID + "GlassesRoundIsOn") == 1)
        {
            GlassesRound.SetActive(true);

        }

        else if (PlayerPrefs.GetInt(username + StudentID + "GlassesRoundIsOn") == 0)
        {
            GlassesRound.SetActive(false);

        }

        if (PlayerPrefs.GetInt(username + StudentID + "GlassesSquareIsOn") == 1)
        {
            GlassesSquare.SetActive(true);

        }

        else if (PlayerPrefs.GetInt(username + StudentID + "GlassesSquareIsOn") == 0)
        {
            GlassesSquare.SetActive(false);

        }
    }

    void OnMouseDown()
    {
        if (GlassesRoundIsOn == false && GlassesSquareIsOn == false)
        {
            GlassesRound.SetActive(true);
            GlassesRoundIsOn = true;
            PlayerPrefs.SetInt(username + StudentID + "GlassesRoundIsOn",1);
        }

        else if (GlassesRoundIsOn == true)
        {
            GlassesRound.SetActive(false);
            GlassesRoundIsOn = false;
            PlayerPrefs.SetInt(username + StudentID + "GlassesRoundIsOn", 0);
            GlassesSquare.SetActive(true);
            GlassesSquareIsOn = true;
            PlayerPrefs.SetInt(username + StudentID + "GlassesSquareIsOn", 1);

        }

        else if (GlassesRoundIsOn == false && GlassesSquareIsOn == true)
        {
            GlassesRound.SetActive(false);
            GlassesRoundIsOn = false;
            PlayerPrefs.SetInt(username + StudentID + "GlassesRoundIsOn", 0);
            GlassesSquare.SetActive(false);
            GlassesSquareIsOn = false;
            PlayerPrefs.SetInt(username + StudentID + "GlassesSquareIsOn", 0);

        }
    }
}
