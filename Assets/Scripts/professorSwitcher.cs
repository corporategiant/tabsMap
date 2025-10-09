using UnityEngine;
using System.Collections;

public class professorSwitcher : MonoBehaviour
{
    public GameObject Manager;
    public GameObject KimHead;
    public GameObject TerutsukiHead;
    public GameObject KohsakaHead;
    public GameObject TakashimaHead;
    public Color ColourSkinKim;
    public Color ColourSkinTerutsuki;
    public Color ColourSkinKohsaka;
    public Color ColourSkinTakashima;
    public Color ColourBodyKim;
    public Color ColourBodyTerutsuki;
    public Color ColourBodyKohsaka;
    public Color ColourBodyTakashima;
    public Color ColourLegsKim;
    public Color ColourLegsTerutsuki;
    public Color ColourLegsKohsaka;
    public Color ColourLegsTakashima;
    public Material matSkinProf;
    public Material matBodyProf;
    public Material matLegsProf;


    void Start()
    {
        if (Manager.GetComponent<selectMajor>().AdvancedTextiles == true)
        {
            KimHead.SetActive(true);
            TerutsukiHead.SetActive(false);
            KohsakaHead.SetActive(false);
            TakashimaHead.SetActive(false);

            matSkinProf.SetColor("_Color", ColourSkinKim);
            matBodyProf.SetColor("_Color", ColourBodyKim);
            matLegsProf.SetColor("_Color", ColourLegsKim);


        }
        else if (Manager.GetComponent<selectMajor>().Robotics == true)
        {
            KimHead.SetActive(false);
            TerutsukiHead.SetActive(true);
            KohsakaHead.SetActive(false);
            TakashimaHead.SetActive(false);

            matSkinProf.SetColor("_Color", ColourSkinTerutsuki);
            matBodyProf.SetColor("_Color", ColourBodyTerutsuki);
            matLegsProf.SetColor("_Color", ColourLegsTerutsuki);

        }
        else if (Manager.GetComponent<selectMajor>().Chemistry == true)
        {
            KimHead.SetActive(false);
            TerutsukiHead.SetActive(false);
            KohsakaHead.SetActive(true);
            TakashimaHead.SetActive(false);

            matSkinProf.SetColor("_Color", ColourSkinKohsaka);
            matBodyProf.SetColor("_Color", ColourBodyKohsaka);
            matLegsProf.SetColor("_Color", ColourLegsKohsaka);

        }
        else if (Manager.GetComponent<selectMajor>().Biology == true)
        {
            KimHead.SetActive(false);
            TerutsukiHead.SetActive(false);
            KohsakaHead.SetActive(false);
            TakashimaHead.SetActive(true);

            matSkinProf.SetColor("_Color", ColourSkinTakashima);
            matBodyProf.SetColor("_Color", ColourBodyTakashima);
            matLegsProf.SetColor("_Color", ColourLegsTakashima);

        }
    }



}



