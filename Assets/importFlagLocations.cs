using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;


public class importFlagLocation : MonoBehaviour
{
    // The URL where your PHP script is hosted
    private const string phpUrl = "https://www.corporategiant.co.uk/tabsMapData/saved_locations/get_data.php";
    public GameObject Flag;
    // Mark the class as serializable to work with JsonUtility
    [Serializable]
    public class Location
    {
        public string flagName;

        public Vector3 position;
        public float x;
        public float y;
        public float z;
        // Add other fields as per your JSON
    }


    void Start()
    {
        // Start the coroutine to fetch the data
        StartCoroutine(FetchJsonData());
    }
    
        IEnumerator FetchJsonData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(phpUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                string jsonString = webRequest.downloadHandler.text;
                Debug.Log("Received JSON: " + jsonString);

                // Deserialize the JSON string
                Location data = JsonUtility.FromJson<Location>(jsonString);

                Debug.Log("flag name : " + data.flagName);
                Debug.Log("x : " + data.x);
                Debug.Log("y : " + data.y);
                Debug.Log("z : " + data.z);

                GameObject newInstance = Instantiate(Flag, transform.position, transform.rotation);
                //GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                newInstance.name = data.flagName;
                newInstance.transform.position = new Vector3(data.x,data.y,data.z);

                

            }
            else
            {
                Debug.LogError("Error fetching JSON: " + webRequest.error);
            }
        }
    }
}