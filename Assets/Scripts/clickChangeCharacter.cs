using UnityEngine;
using System.Collections;

public class clickChangeCharacter : MonoBehaviour
{
    private float temps;
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
    public GameObject TShirt;
    public Material Body;
    public Material Legs;
    public Material Hair;
    public Material Skin;
    public Color[] ColourBody;
    public Color[] ColourLegs;
    public Color[] ColourHair;
    public Color[] ColourSkin;

    public int ChLook;

    public int SnorkelAddOn;
    public bool SnorkelIsOn;

    public int SpaceHelmetAddOn;
    public bool SpaceHelmetIsOn;

    public int MothWingsAddOn;
    public bool MothWingsIsOn;
    public bool NoAddon;

    public string username;
    public string StudentID;

    void Start()
    {
        username = (PlayerPrefs.GetString("username"));
        StudentID = (PlayerPrefs.GetString("StudentID"));


        SnorkelAddOn = PlayerPrefs.GetInt(username + StudentID + "SnorkelAddOn");


        SpaceHelmetAddOn = PlayerPrefs.GetInt(username + StudentID + "SpaceHelmetAddOn");


        MothWingsAddOn = PlayerPrefs.GetInt(username + StudentID + "MothWingsAddOn");

        if (PlayerPrefs.GetInt(username + StudentID + "SnorkelIsOn") == 1)
        {
            Snorkel.SetActive(true);
            RubberRing.SetActive(true);
            SnorkelIsOn = true;

        }
        else if (PlayerPrefs.GetInt(username + StudentID + "SnorkelIsOn") == 0)
        {
            Snorkel.SetActive(false);
            RubberRing.SetActive(false);
            SnorkelIsOn = false;
        }

        if (PlayerPrefs.GetInt(username + StudentID + "MothWingsIsOn") == 1)
        {
            MothWings.SetActive(true);
            MothWingsIsOn = true;
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "MothWingsIsOn") == 0)
        {
            MothWings.SetActive(false);
            MothWingsIsOn = false;
        }

        if (PlayerPrefs.GetInt(username + StudentID + "SpaceHelmetIsOn") == 1)
        {
            SpaceHelmet.SetActive(true);
            SpaceHelmetIsOn = true;
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "SpaceHelmetIsOn") == 0)
        {
            SpaceHelmet.SetActive(false);
            SpaceHelmetIsOn = false;
        }

        if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 0)
        {
            if (PlayerPrefs.GetInt(username + StudentID + "SpaceHelmetIsOn") == 1)
            {
                SpaceHelmet.SetActive(true);
                SpaceHelmetIsOn = true;
            }
            else if (PlayerPrefs.GetInt(username + StudentID + "SpaceHelmetIsOn") == 0)
            {
                SpaceHelmet.SetActive(false);
                SpaceHelmetIsOn = false;
            }

            Hat.SetActive(true);
            HairA.SetActive(false);
            HairB.SetActive(false);
            HairC.SetActive(false);
            HairD.SetActive(false);
            HairB1.SetActive(true);
            HairC1.SetActive(false);
            Hijab.SetActive(false);
        }

        if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 1)
        {
            Hat.SetActive(true);
            HairA.SetActive(true);
            HairB.SetActive(false);
            HairC.SetActive(false);
            HairD.SetActive(false);
            HairB1.SetActive(true);
            HairC1.SetActive(false);
            Hijab.SetActive(false);
        }

        if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 2)
        {
            Hat.SetActive(false);
            HairA.SetActive(true);
            HairB.SetActive(true);
            HairC.SetActive(false);
            HairD.SetActive(false);
            HairB1.SetActive(false);
            HairC1.SetActive(false);
            Hijab.SetActive(false);
        }

        if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 3)
        {
            Hat.SetActive(false);
            HairA.SetActive(false);
            HairB.SetActive(true);
            HairC.SetActive(false);
            HairD.SetActive(false);
            HairB1.SetActive(false);
            HairC1.SetActive(false);
            Hijab.SetActive(false);
        }

        if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 4)
        {
            Hat.SetActive(false);
            HairA.SetActive(false);
            HairB.SetActive(false);
            HairC.SetActive(false);
            HairD.SetActive(false);
            HairB1.SetActive(false);
            HairC1.SetActive(false);
            Hijab.SetActive(true);
        }

        if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 5)
        {
            Hat.SetActive(false);
            HairA.SetActive(false);
            HairB.SetActive(false);
            HairC.SetActive(false);
            HairD.SetActive(true);
            HairB1.SetActive(false);
            HairC1.SetActive(false);
            Hijab.SetActive(false);
        }

        if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 6)
        {
            Hat.SetActive(false);
            HairA.SetActive(true);
            HairB.SetActive(false);
            HairC.SetActive(true);
            HairD.SetActive(false);
            HairB1.SetActive(false);
            HairC1.SetActive(false);
            Hijab.SetActive(false);
        }

        if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 7)
        {
            Hat.SetActive(true);
            HairA.SetActive(true);
            HairB.SetActive(false);
            HairC.SetActive(false);
            HairD.SetActive(false);
            HairB1.SetActive(false);
            HairC1.SetActive(true);
            Hijab.SetActive(false);
        }

        Body.SetColor("_Color", ColourBody[PlayerPrefs.GetInt(username + StudentID + "ColourBody")]);
        Legs.SetColor("_Color", ColourLegs[PlayerPrefs.GetInt(username + StudentID + "ColourLegs")]);
        Hair.SetColor("_Color", ColourHair[PlayerPrefs.GetInt(username + StudentID + "ColourHair")]);
        Skin.SetColor("_Color", ColourSkin[PlayerPrefs.GetInt(username + StudentID + "ColourSkin")]);

    }

        void OnMouseDown()
    {

        if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 0)
        {
            SpaceHelmetAddOn = PlayerPrefs.GetInt(username + StudentID + "SpaceHelmetAddOn");
            if (SpaceHelmetAddOn == 1)
            {
                if (SnorkelIsOn == false)
                {
                    if (SpaceHelmetIsOn == false)
                    {
                        SpaceHelmet.SetActive(true);
                        SpaceHelmetIsOn = true;
                        PlayerPrefs.SetInt(username + StudentID + "SpaceHelmetIsOn", 1);
                    }


                    else if (SpaceHelmetIsOn == true)
                    {
                        SpaceHelmet.SetActive(false);
                        SpaceHelmetIsOn = false;
                        PlayerPrefs.SetInt(username + StudentID + "SpaceHelmetIsOn", 0);

                        Hat.SetActive(true);
                        HairA.SetActive(true);
                        HairB.SetActive(false);
                        HairC.SetActive(false);
                        HairD.SetActive(false);
                        HairB1.SetActive(true);
                        HairC1.SetActive(false);
                        Hijab.SetActive(false);
                        PlayerPrefs.SetInt(username + StudentID + "ChLook", 1);
                        ChLook = 1;
                    }
                }
                else if (SnorkelIsOn == true)
                {
                    Hat.SetActive(true);
                    HairA.SetActive(true);
                    HairB.SetActive(false);
                    HairC.SetActive(false);
                    HairD.SetActive(false);
                    HairB1.SetActive(true);
                    HairC1.SetActive(false);
                    Hijab.SetActive(false);
                    PlayerPrefs.SetInt(username + StudentID + "ChLook", 1);
                    ChLook = 1;
                }
            }

            else if (SpaceHelmetAddOn == 0)
            {
                Hat.SetActive(true);
                HairA.SetActive(true);
                HairB.SetActive(false);
                HairC.SetActive(false);
                HairD.SetActive(false);
                HairB1.SetActive(true);
                HairC1.SetActive(false);
                Hijab.SetActive(false);
                PlayerPrefs.SetInt(username + StudentID + "ChLook", 1);
                ChLook = 1;

            }

        }
        else if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 1)
        {
            Hat.SetActive(false);
            HairA.SetActive(true);
            HairB.SetActive(true);
            HairC.SetActive(false);
            HairD.SetActive(false);
            HairB1.SetActive(false);
            HairC1.SetActive(false);
            Hijab.SetActive(false);
            PlayerPrefs.SetInt(username + StudentID + "ChLook", 2);
            ChLook = 2;
        }
        else if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 2)
        {
            Hat.SetActive(false);
            HairA.SetActive(false);
            HairB.SetActive(true);
            HairC.SetActive(false);
            HairD.SetActive(false);
            HairB1.SetActive(false);
            HairC1.SetActive(false);
            Hijab.SetActive(false);
            PlayerPrefs.SetInt(username + StudentID + "ChLook", 3);
            ChLook = 3;
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 3)
        {
            Hat.SetActive(false);
            HairA.SetActive(false);
            HairB.SetActive(false);
            HairC.SetActive(false);
            HairD.SetActive(false);
            HairB1.SetActive(false);
            HairC1.SetActive(false);
            Hijab.SetActive(true);
            PlayerPrefs.SetInt(username + StudentID + "ChLook", 4);
            ChLook = 4;
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 4)
        {
            Hat.SetActive(false);
            HairA.SetActive(false);
            HairB.SetActive(false);
            HairC.SetActive(false);
            HairD.SetActive(true);
            HairB1.SetActive(false);
            HairC1.SetActive(false);
            Hijab.SetActive(false);
            PlayerPrefs.SetInt(username + StudentID + "ChLook", 5);
            ChLook = 5;
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 5)
        {
            Hat.SetActive(false);
            HairA.SetActive(true);
            HairB.SetActive(false);
            HairC.SetActive(true);
            HairD.SetActive(false);
            HairB1.SetActive(false);
            HairC1.SetActive(false);
            Hijab.SetActive(false);
            PlayerPrefs.SetInt(username + StudentID + "ChLook", 6);
            ChLook = 6;
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 6)
        {
            Hat.SetActive(true);
            HairA.SetActive(true);
            HairB.SetActive(false);
            HairC.SetActive(false);
            HairD.SetActive(false);
            HairB1.SetActive(false);
            HairC1.SetActive(true);
            Hijab.SetActive(false);
            PlayerPrefs.SetInt(username + StudentID + "ChLook", 7);
            ChLook = 7;
        }

        else if (PlayerPrefs.GetInt(username + StudentID + "ChLook", ChLook) == 7)
        {
            Hat.SetActive(true);
            HairA.SetActive(false);
            HairB.SetActive(false);
            HairC.SetActive(false);
            HairD.SetActive(false);
            HairB1.SetActive(true);
            HairC1.SetActive(false);
            Hijab.SetActive(false);

            SnorkelAddOn = PlayerPrefs.GetInt(username + StudentID + "SnorkelAddOn");


                PlayerPrefs.SetInt(username + StudentID + "ChLook", 0);
                ChLook = 0;
            

                if (SnorkelAddOn == 1)
            {
                if (SnorkelIsOn == false)
                {
                    Snorkel.SetActive(true);
                    RubberRing.SetActive(true);
                    SnorkelIsOn = true;
                    PlayerPrefs.SetInt(username + StudentID + "SnorkelIsOn", 1);
                }

                else if (SnorkelIsOn == true)
                {
                    Snorkel.SetActive(false);
                    RubberRing.SetActive(false);
                    SnorkelIsOn = false;
                    PlayerPrefs.SetInt(username + StudentID + "SnorkelIsOn", 0);
                }

 
            }

            if (MothWingsAddOn == 1)
            {
                if (SnorkelIsOn == false)
                {
                    if (NoAddon == true)
                    {
                        MothWings.SetActive(true);

                        MothWingsIsOn = true;
                        PlayerPrefs.SetInt(username + StudentID + "MothWingsIsOn", 1);
                        NoAddon = false;
                    }

                    else if (NoAddon == false)
                    {
                        MothWings.SetActive(false);

                        MothWingsIsOn = false;
                        PlayerPrefs.SetInt(username + StudentID + "MothWingsIsOn", 0);
                        NoAddon = true;
                    }
                }

            }

 
        }

        Debug.Log("ClickChangeCharacter Says Was Clicked");

        
    }


    

}
