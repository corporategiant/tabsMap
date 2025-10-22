using UnityEngine;

public class mapOn : MonoBehaviour
{

    public GameObject MapGrp;
    public bool SpeechboxAOn;
    public GameObject SpeechboxA;


    void Start()
    {
        PlayerPrefs.SetInt("mapOn",0);
    }

    void OnMouseDown()
    {
            
            if (PlayerPrefs.GetInt("mapOn") == 0)
            {
            MapGrp.gameObject.GetComponent<SpringScale>().startDelaySpringScale();
            PlayerPrefs.SetInt("mapOn", 1);
            if (SpeechboxAOn == true)
            {
                SpeechboxA.SetActive(true);
            }
            if (SpeechboxAOn == false)
            {
                SpeechboxA.SetActive(false);
            }
        }
    
        }

        
    

    public void ResetMapScale()
    {
        MapGrp.gameObject.GetComponent<SpringScale>().ResetScale();

        PlayerPrefs.SetInt("mapOn", 0);
        if (SpeechboxAOn == true)
        {
            SpeechboxA.SetActive(false);
        }
    }
}
