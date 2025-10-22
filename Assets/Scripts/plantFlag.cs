using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.InputSystem.Interactions;
using System.Collections;
using UnityEngine.Networking;
using System.Text;

public class plantFlag : MonoBehaviour
{
    public GameObject flag;
    public GameObject flagLocator;
    public GameObject flag1;

    public string serverUrl = "https://www.corporategiant.co.uk/tabsMapData/SaveFlagLocation.php";
    public string flagName;
    public string fileName;

    [System.Serializable]
    public class WorldData
    {
        public string fileName;
        public string flagName;
        public float x;
        public float y;
        public float z;
    
}


    void Start()
    {
        fileName = PlayerPrefs.GetString("username")+PlayerPrefs.GetString("StudentID");
        flagName = PlayerPrefs.GetString("username"); 
    }


    public void startPlantFlag()
    {
        StartCoroutine(plantTheFlag());
        this.gameObject.GetComponent<Animator>().SetBool("PlantFlag",true);
        this.gameObject.GetComponent<Animator>().Play("PlantFlag");
        flag.SetActive(true);
    }


    IEnumerator plantTheFlag()
    {
        //Plant the flag
        flag.SetActive(true);
        this.gameObject.GetComponent<Animator>().Play("PlantFlag");
        yield return new WaitForSeconds(2.2f);
        flag.SetActive(false);
        this.gameObject.GetComponent<Animator>().SetBool("PlantFlag", false);
        this.gameObject.GetComponent<NavMeshAgent>().enabled = true;

        flag1.transform.position = flagLocator.transform.position;

        //Send location data to json

        // Create a new data object and populate it
        WorldData data = new WorldData();
        data.flagName = flagName;
        data.fileName = fileName;
        data.x = flag1.transform.position.x;
        data.y = flag1.transform.position.y;
        data.z = flag1.transform.position.z;

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

