using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneSimple : MonoBehaviour
{
    public string SceneToLoad;
    public void LoadScene()
    {

        SceneManager.LoadScene(SceneToLoad);
    }
}
