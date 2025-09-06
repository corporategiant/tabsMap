using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class displayWebImage : MonoBehaviour
{
    public Image imageToUpdate;

    void Start()
    {

        StartCoroutine(downloadImage());
    }
    
IEnumerator downloadImage()
{
    string url = "https://www.corporategiant.co.uk/noticeBoardTest/noticeBoardTest.png";

    UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

    DownloadHandler handle = www.downloadHandler;

    //Send Request and wait
    yield return www.SendWebRequest();

    if (www.result == UnityWebRequest.Result.ProtocolError || www.result == UnityWebRequest.Result.ConnectionError)
    {
        UnityEngine.Debug.Log("Error while Receiving: " + www.error);
    }
    else
    {
        UnityEngine.Debug.Log("Success");

        //Load Image
        Texture2D texture2d = DownloadHandlerTexture.GetContent(www);

        Sprite sprite = null;
        sprite = Sprite.Create(texture2d, new Rect(0, 0, texture2d.width, texture2d.height), Vector2.zero);

        if (sprite != null)
        {
            imageToUpdate.sprite = sprite;
        }
    }
}
}
