using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorWay : MonoBehaviour
{
    public string SceneToLoad;


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Entered DoorWay");
        StartCoroutine(LoadYourAsyncScene());
    }


IEnumerator LoadYourAsyncScene()
{

    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneToLoad);

    // Wait until the asynchronous scene fully loads
    while (!asyncLoad.isDone)
    {
        yield return null;
    }
}
}
       
    
