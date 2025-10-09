using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;


public class importFlagLocations : MonoBehaviour
{
    // The URL where your PHP script is hosted
    private const string phpUrl = "https://www.corporategiant.co.uk/tabsMapData/GetSavedLocations.php";
    public GameObject Flag;
    public LocationData[] allLocations;

    // Mark the class as serializable to work with JsonUtility
    [Serializable]
    public class LocationData
    {
        public string flagName;

        public Vector3 position;
        public float x;
        public float y;
        public float z;
        // Add other fields as per your JSON
    }
    [Serializable]
    public class LocationList // Top-level class to hold the array
    {
    public LocationData[] items;
    }


        void Start()
    {
        StartCoroutine(GetJsonData());
    }

    IEnumerator GetJsonData()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(phpUrl))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error fetching JSON: " + www.error);
            }
            else
            {
                // Get the raw JSON text from the request
                string jsonText = www.downloadHandler.text;

                // Unity's JsonUtility cannot deserialize a raw array.
                // You must wrap the JSON array in a fake root object.
                jsonText = "{\"items\":" + jsonText + "}";

                // Deserialize the modified JSON string into the C# class
                LocationList itemList = JsonUtility.FromJson<LocationList>(jsonText);

                // Assign the array of items
                allLocations = itemList.items;

                Debug.Log("Successfully fetched " + allLocations.Length + " items.");

                // Example of how to use the data
                foreach (var item in allLocations)
                {
                    Debug.Log("Flag name: " + item.flagName + ", x: " + item.x + ", y: " + item.y + ", z: " + item.z);
                    GameObject newInstance = Instantiate(Flag, transform.position, transform.rotation);
                    //GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    newInstance.name = item.flagName;
                    newInstance.transform.position = new Vector3(item.x, item.y, item.z);

                    newInstance.GetComponent<FlagLabel>().FlagName = item.flagName;
                    newInstance.GetComponent<FlagLabel>().FlagNameTMP.text = item.flagName;
                    newInstance.GetComponent<BoxCollider>().isTrigger = true;
                    

                
                }
            }
        }
    }
}