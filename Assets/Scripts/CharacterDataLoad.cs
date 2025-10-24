using UnityEngine;
using UnityEngine.Networking;
using System.Collections;


public class CharacterDataLoad : MonoBehaviour
{

    // The URL where your PHP script is hosted
    public string username;
    public string StudentID;
    public string phpUrl = "https://www.corporategiant.co.uk/tabsBookData/GetCharacterData.php";
    public string url;

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

    }


    void Start()
    {
        username = PlayerPrefs.GetString("username");
        StudentID = PlayerPrefs.GetString("StudentID");
        fileName = username + StudentID;
        url =  "https://www.corporategiant.co.uk/tabsBookData/characterData/"+fileName;
        StartCoroutine(GetJsonFromUrl());

    }

    IEnumerator GetJsonData()
    {
        //string url = phpUrl + "?filename=" + filename;

        using (UnityWebRequest webRequest = UnityWebRequest.Get(phpUrl))
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

            }
            else
            {
                Debug.LogError("Error fetching JSON: " + webRequest.error);
            }
        }






    }
            IEnumerator GetJsonFromUrl()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Send the request and wait for a response
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                // Get the downloaded JSON text
                string jsonText = webRequest.downloadHandler.text;
                Debug.Log("Received JSON: " + jsonText);

                // Deserialize the JSON into your C# class
                CharacterData data = JsonUtility.FromJson<CharacterData>(jsonText);

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

            }
        }
    }
        }

