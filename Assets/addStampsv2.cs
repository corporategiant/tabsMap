using UnityEngine;
using UnityEngine.Networking;
using System.Collections;


public class AddStampsv2 : MonoBehaviour
{

    // The URL where your PHP script is hosted
    public string username;
    public string StudentID;
    private const string phpUrl = "https://www.corporategiant.co.uk/tabsBookData/GetCharacterData.php";
    public string fileName;
    public int ChLook;
    public int SnorkelAddOn;
    public int SpaceHelmetAddOn;
    public int MothWingsAddOn;
    public int SnorkelIsOn;
    public int MothWingsIsOn;
    public int SpaceHelmetIsOn;
    public int GlassesRoundIsOn;
    public int GlassesSquareIsOn;
    public int TShirtIsOn;
    public int ColourBody;
    public int ColourLegs;
    public int ColourHair;
    public int ColourSkin;
    public int StampNumber;

    // Mark the class as serializable to work with JsonUtility
    [System.Serializable]
    public class CharacterData
    {
        public string fileName;
        public int ChLook;
        public int SnorkelAddOn;
        public int SpaceHelmetAddOn;
        public int MothWingsAddOn;
        public int SnorkelIsOn;
        public int MothWingsIsOn;
        public int SpaceHelmetIsOn;
        public int GlassesRoundIsOn;
        public int GlassesSquareIsOn;
        public int TShirtIsOn;
        public int ColourBody;
        public int ColourLegs;
        public int ColourHair;
        public int StampNumber;
        public int ColourSkin;


    }


    void Start()
    {
        username = PlayerPrefs.GetString("username");
        StudentID = PlayerPrefs.GetString("StudentID");
        fileName = username + StudentID;
        StartCoroutine(GetJsonData());

    }

    IEnumerator GetJsonData()
    {
        string url = phpUrl + "?filename=" + fileName;

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                string jsonString = webRequest.downloadHandler.text;
                Debug.Log("Received JSON: " + jsonString);
            }
        }
    }
}