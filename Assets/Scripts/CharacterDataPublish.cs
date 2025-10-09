using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.InputSystem.Interactions;
using System.Collections;
using UnityEngine.Networking;
using System.Text;

public class CharacterDataPublish : MonoBehaviour
{
    public string username;
    public string StudentID;
    public string serverUrl = "https://www.corporategiant.co.uk/tabsBookData/SaveCharacterData.php";
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




    [System.Serializable]
    public class MyCharacterData
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
    }


    public void startPublishCharacterData()
    {
        fileName = PlayerPrefs.GetString("username")+PlayerPrefs.GetString("StudentID");
        SnorkelAddOn = PlayerPrefs.GetInt(username + StudentID + "SnorkelAddOn");
        SpaceHelmetAddOn = PlayerPrefs.GetInt(username + StudentID + "SpaceHelmetAddOn");
        MothWingsAddOn = PlayerPrefs.GetInt(username + StudentID + "MothWingsAddOn");
        SnorkelIsOn = PlayerPrefs.GetInt(username + StudentID + "SnorkelIsOn");
        MothWingsIsOn = PlayerPrefs.GetInt(username + StudentID + "MothWingsIsOn");
        SpaceHelmetIsOn = PlayerPrefs.GetInt(username + StudentID + "SpaceHelmetIsOn");
        ChLook = PlayerPrefs.GetInt(username + StudentID + "ChLook");
        GlassesRoundIsOn = PlayerPrefs.GetInt(username + StudentID + "GlassesRoundIsOn");
        GlassesSquareIsOn = PlayerPrefs.GetInt(username + StudentID + "GlassesSquareIsOn");
        TShirtIsOn = PlayerPrefs.GetInt(username + StudentID + "TShirtIsOn");
        ColourBody = PlayerPrefs.GetInt(username + StudentID + "ColourBody");
        ColourLegs = PlayerPrefs.GetInt(username + StudentID + "ColourLegs");
        ColourHair = PlayerPrefs.GetInt(username + StudentID + "ColourHair");
        ColourSkin = PlayerPrefs.GetInt(username + StudentID + "ColourSkin");

        StartCoroutine(publishCharacterData());
    }


    IEnumerator publishCharacterData()
    {
        //Send data to json

        // Create a new data object and populate it
        MyCharacterData data = new MyCharacterData();
        data.fileName = fileName;
        data.ChLook = ChLook;
        data.SnorkelAddOn = SnorkelAddOn;
        data.SpaceHelmetAddOn = SpaceHelmetAddOn;
        data.MothWingsAddOn = MothWingsAddOn;
        data.SnorkelIsOn = SnorkelIsOn;
        data.MothWingsIsOn = SpaceHelmetAddOn;
        data.SpaceHelmetIsOn = MothWingsAddOn;
        data.ChLook = MothWingsAddOn;
        data.GlassesRoundIsOn = MothWingsAddOn;
        data.GlassesSquareIsOn = MothWingsAddOn;
        data.TShirtIsOn = MothWingsAddOn;
        data.ColourBody = ColourBody;
        data.ColourLegs = ColourLegs;
        data.ColourHair = ColourHair;
        data.ColourSkin = ColourSkin;


        // Convert the object to a JSON string
        string jsonData = JsonUtility.ToJson(data);

        // Create the web request
        using (UnityWebRequest request = new UnityWebRequest(serverUrl, "POST"))
        {
            byte[] jsonToSend = new UTF8Encoding().GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(jsonToSend);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            // Send the request
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Successfully sent location data to server: " + request.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error sending data: " + request.error);
            }
        }
    }
}

