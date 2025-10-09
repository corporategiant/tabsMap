using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject Hat;
    public GameObject HairA;
    public GameObject HairB;
    public GameObject HairC;
    public GameObject HairD;
    public GameObject HairB1;
    public GameObject HairC1;
    public GameObject Hijab;
    public GameObject Snorkel;
    public GameObject RubberRing;
    public GameObject SpaceHelmet;
    public GameObject MothWings;

    public GameObject GlassesRound;
    public GameObject GlassesSquare;

    public GameObject TShirt;

    public int ChLook;
    public string username;
    public string StudentID;

    void Awake()
    {
        username = (PlayerPrefs.GetString("username"));
        StudentID = (PlayerPrefs.GetString("StudentID"));
 
        if (PlayerPrefs.GetInt(username + StudentID + "TShirtIsOn") == 1)
        {
            TShirt.SetActive(true);
        }

        if (PlayerPrefs.GetInt(username + StudentID + "TShirtIsOn") == 0)
        {
            TShirt.SetActive(false);
        }

        if (PlayerPrefs.GetInt(username + StudentID + "GlassesRoundIsOn") == 1)
        {
            GlassesRound.SetActive(true);
        }

        if (PlayerPrefs.GetInt(username + StudentID + "GlassesRoundIsOn") == 0)
        {
            GlassesRound.SetActive(false);
        }

        if (PlayerPrefs.GetInt(username + StudentID + "GlassesSquareIsOn") == 1)
        {
            GlassesSquare.SetActive(true);
        }

        if (PlayerPrefs.GetInt(username + StudentID + "GlassesSquareIsOn") == 0)
        {
            GlassesSquare.SetActive(false);
        }

        if (PlayerPrefs.GetInt(username + StudentID + "SnorkelIsOn") == 1)
        {
            Snorkel.SetActive(true);
            RubberRing.SetActive(true);
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "SnorkelIsOn") == 0)
        {
            Snorkel.SetActive(false);
            RubberRing.SetActive(false);
        }

        if (PlayerPrefs.GetInt(username + StudentID + "SpaceHelmetIsOn") == 1)
        {
            SpaceHelmet.SetActive(true);
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "SpaceHelmetIsOn") == 0)
        {
            SpaceHelmet.SetActive(false);
        }

        if (PlayerPrefs.GetInt(username + StudentID + "MothWingsIsOn") == 1)
        {
            MothWings.SetActive(true);
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "MothWingsIsOn") == 0)
        {
            MothWings.SetActive(false);
        }

        ChLook = PlayerPrefs.GetInt(username + StudentID + "ChLook");

        if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 0)
        {
            Hat.gameObject.SetActive(true);
            HairA.gameObject.SetActive(false);
            HairB.gameObject.SetActive(false);
            HairC.gameObject.SetActive(false);
            HairD.gameObject.SetActive(false);
            HairB1.gameObject.SetActive(true);
            HairC1.gameObject.SetActive(false);
            Hijab.gameObject.SetActive(false);
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 1)
        {
            Hat.gameObject.SetActive(true);
            HairA.gameObject.SetActive(true);
            HairB.gameObject.SetActive(false);
            HairC.gameObject.SetActive(false);
            HairD.gameObject.SetActive(false);
            HairB1.gameObject.SetActive(true);
            HairC1.gameObject.SetActive(false);
            Hijab.gameObject.SetActive(false);
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 2)
        {
            Hat.gameObject.SetActive(false);
            HairA.gameObject.SetActive(true);
            HairB.gameObject.SetActive(true);
            HairC.gameObject.SetActive(false);
            HairD.gameObject.SetActive(false);
            HairB1.gameObject.SetActive(false);
            HairC1.gameObject.SetActive(false);
            Hijab.gameObject.SetActive(false);
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 3)
        {
            Hat.gameObject.SetActive(false);
            HairA.gameObject.SetActive(false);
            HairB.gameObject.SetActive(true);
            HairC.gameObject.SetActive(false);
            HairD.gameObject.SetActive(false);
            HairB1.gameObject.SetActive(false);
            HairC1.gameObject.SetActive(false);
            Hijab.gameObject.SetActive(false);
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 4)
        {
            Hat.gameObject.SetActive(false);
            HairA.gameObject.SetActive(false);
            HairB.gameObject.SetActive(false);
            HairC.gameObject.SetActive(false);
            HairD.gameObject.SetActive(false);
            HairB1.gameObject.SetActive(false);
            HairC1.gameObject.SetActive(false);
            Hijab.gameObject.SetActive(true);
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 5)
        {
            Hat.gameObject.SetActive(false);
            HairA.gameObject.SetActive(false);
            HairB.gameObject.SetActive(false);
            HairC.gameObject.SetActive(false);
            HairD.gameObject.SetActive(true);
            HairB1.gameObject.SetActive(false);
            HairC1.gameObject.SetActive(false);
            Hijab.gameObject.SetActive(false);
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 6)
        {
            Hat.gameObject.SetActive(false);
            HairA.gameObject.SetActive(true);
            HairB.gameObject.SetActive(false);
            HairC.gameObject.SetActive(true);
            HairD.gameObject.SetActive(false);
            HairB1.gameObject.SetActive(false);
            HairC1.gameObject.SetActive(false);
            Hijab.gameObject.SetActive(false);
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 7)
        {
            Hat.gameObject.SetActive(true);
            HairA.gameObject.SetActive(true);
            HairB.gameObject.SetActive(false);
            HairC.gameObject.SetActive(false);
            HairD.gameObject.SetActive(false);
            HairB1.gameObject.SetActive(false);
            HairC1.gameObject.SetActive(true);
            Hijab.gameObject.SetActive(false);
        }

    }

   

    


}
