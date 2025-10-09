using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class selectMajor : MonoBehaviour
{
    //[SerializeField] MajorSubject type = new MajorSubject();
    public string ProfessorName;
    public string MajorName;
    public string MajorItem;
    public bool AdvancedTextiles;
    public bool Robotics;
    public bool Chemistry;
    public bool Biology;
    public GameObject MenuAdvTex;
    public GameObject MenuRobotics;
    public GameObject MenuChemistry;
    public GameObject MenuBiology;
    public GameObject MenuYes;
    public GameObject MenuNo;
    public int Major;

    void Start()
    {
        Major = PlayerPrefs.GetInt("Major", 0);

        if (Major == 1)
        {
            SetMajorAdvancedTextiles();
        }

        if (Major == 2)
        {
            SetMajorRobotics();
        }

        if (Major == 3)
        {
            SetMajorChemistry();
        }

        if (Major == 4)
        {
            SetMajorBiology();
        }

        MenuYes.GetComponent<fontSwitcher>().switchFontLight();
        MenuNo.GetComponent<fontSwitcher>().switchFontLight();
    }

    public enum MajorSubject
    {
        AdvancedTextiles,
        Robotics,
        Chemistry,
        Biology
    }

    public void SetMajorAdvancedTextiles ()
    {
        MenuAdvTex.GetComponent<fontSwitcher>().switchFontBold();
        MenuRobotics.GetComponent<fontSwitcher>().switchFontLight();
        MenuChemistry.GetComponent<fontSwitcher>().switchFontLight();
        MenuBiology.GetComponent<fontSwitcher>().switchFontLight();
        PlayerPrefs.SetInt("Major", 1);
        //type = MajorSubject.AdvancedTextiles;
        ProfessorName = "Kim";
        MajorName = "Advanced Textiles";
        MajorItem = "Sensor Suit";
        AdvancedTextiles = true;
        Robotics = false;
        Chemistry = false;
        Biology = false;

    }

    public void SetMajorRobotics()
    {
        MenuAdvTex.GetComponent<fontSwitcher>().switchFontLight();
        MenuRobotics.GetComponent<fontSwitcher>().switchFontBold();
        MenuChemistry.GetComponent<fontSwitcher>().switchFontLight();
        MenuBiology.GetComponent<fontSwitcher>().switchFontLight();
        PlayerPrefs.SetInt("Major", 2);
        //type = MajorSubject.Robotics;
        ProfessorName = "Terutsuki";
        MajorName = "Robotics";
        MajorItem = "Advanced Bio-Hybrid Drone";
        AdvancedTextiles = false;
        Robotics = true;
        Chemistry = false;
        Biology = false;

    }

    public void SetMajorChemistry()
    {
        MenuAdvTex.GetComponent<fontSwitcher>().switchFontLight();
        MenuRobotics.GetComponent<fontSwitcher>().switchFontLight();
        MenuChemistry.GetComponent<fontSwitcher>().switchFontBold();
        MenuBiology.GetComponent<fontSwitcher>().switchFontLight();
        PlayerPrefs.SetInt("Major", 3);
        //type = MajorSubject.Chemistry;
        ProfessorName = "Kohsaka";
        MajorName = "Chemistry";
        MajorItem = "Non Corrosive Adhesive";
        AdvancedTextiles = false;
        Robotics = false;
        Chemistry = true;
        Biology = false;


    }

    public void SetMajorBiology()
    {
        MenuAdvTex.GetComponent<fontSwitcher>().switchFontLight();
        MenuRobotics.GetComponent<fontSwitcher>().switchFontLight();
        MenuChemistry.GetComponent<fontSwitcher>().switchFontLight();
        MenuBiology.GetComponent<fontSwitcher>().switchFontBold();
        PlayerPrefs.SetInt("Major", 4);
        //type = MajorSubject.Biology;
        ProfessorName = "Takashima";
        MajorName = "Biology";
        MajorItem = "Regenerative Stem Cell Hamster";
        AdvancedTextiles = false;
        Robotics = false;
        Chemistry = false;
        Biology = true;


    }
}