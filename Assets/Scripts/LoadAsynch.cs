using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class LoadSceneAsynch : MonoBehaviour {

	public string SceneToLoad;
	public float Pause;

	public bool LoadAtStart;

	void Start()
	{
		if (LoadAtStart == true)
		{
			StartCoroutine("LoadScene");
		}
	}

	public void StartLoadScene()
	{
		
		StartCoroutine("LoadScene");
	}

	public void Skip()
	{

		StopAllCoroutines();
		SceneManager.LoadScene(SceneToLoad);
	}

	IEnumerator LoadScene()
	{
		yield return new WaitForSeconds(Pause);
	
		SceneManager.LoadSceneAsync(SceneToLoad);

	}
}