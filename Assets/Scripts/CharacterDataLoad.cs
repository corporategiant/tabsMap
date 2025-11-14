using UnityEngine;
using UnityEngine.Networking;
using System.Collections;


public class CharacterDataLoad : MonoBehaviour
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
        public int ColourSkin;
        public int StampNumber;

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

                // Now, parse the JSON string using Unity's JsonUtility or a third-party library
                // Example with JsonUtility (requires a serializable class matching your JSON structure)
                CharacterData data = JsonUtility.FromJson<CharacterData>(jsonString);
                Debug.Log("Parsed data CHLook : " + data.ChLook);
                Debug.Log("Parsed data CHLook : " + data.StampNumber);

                // Use the data        

                SnorkelAddOn = data.SnorkelAddOn;
                SpaceHelmetAddOn = data.SpaceHelmetAddOn;
                MothWingsAddOn = data.MothWingsAddOn;
                SnorkelIsOn = data.SnorkelIsOn;
                MothWingsIsOn = data.MothWingsIsOn;
                SpaceHelmetIsOn = data.SpaceHelmetIsOn;
                ChLook = data.ChLook;
                GlassesRoundIsOn = data.GlassesRoundIsOn;
                GlassesSquareIsOn = data.GlassesSquareIsOn;
                TShirtIsOn = data.TShirtIsOn;
                ColourBody = data.ColourBody;
                ColourLegs = data.ColourLegs;
                ColourHair = data.ColourHair;
                ColourSkin = data.ColourSkin;
                StampNumber = data.StampNumber;



                PlayerPrefs.SetInt(username + StudentID + "SnorkelAddOn", SnorkelAddOn);
                PlayerPrefs.SetInt(username + StudentID + "SpaceHelmetAddOn", SpaceHelmetAddOn);
                PlayerPrefs.SetInt(username + StudentID + "MothWingsAddOn", MothWingsAddOn);
                PlayerPrefs.SetInt(username + StudentID + "SnorkelIsOn", SnorkelIsOn);
                PlayerPrefs.SetInt(username + StudentID + "MothWingsIsOn", MothWingsIsOn);
                PlayerPrefs.SetInt(username + StudentID + "SpaceHelmetIsOn", SpaceHelmetIsOn);
                PlayerPrefs.SetInt(username + StudentID + "ChLook", ChLook);
                PlayerPrefs.SetInt(username + StudentID + "TShirtIsOn", TShirtIsOn);
                PlayerPrefs.SetInt(username + StudentID + "ColourBody", ColourBody);
                PlayerPrefs.SetInt(username + StudentID + "ColourLegs", ColourLegs);
                PlayerPrefs.SetInt(username + StudentID + "ColourHair", ColourHair);
                PlayerPrefs.SetInt(username + StudentID + "ColourSkin", ColourSkin);
                PlayerPrefs.SetInt(username + StudentID + "StampNumber", StampNumber);
               
            
            }
            else
            {
                Debug.LogError("Error fetching JSON: " + webRequest.error);
            }
        }
                     


                


            }
        }

