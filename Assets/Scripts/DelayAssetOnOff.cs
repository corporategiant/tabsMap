using UnityEngine;
using System.Collections;

public class DelayAssetOnOff : MonoBehaviour {

	public bool OnAtStart;
	public float Pause;

	public bool flag;

	void Start(){

		if (OnAtStart == true)
		{
			StartCoroutine(DelayAssetOn());
		}

	}

	IEnumerator DelayAssetOn() {
		
		yield return new WaitForSeconds (Pause);
		
		{
			foreach( Transform child in transform )
			{
				child.gameObject.SetActive(true);
			} 
		}
		
	}

	IEnumerator DelayAssetOff() {
		
		yield return new WaitForSeconds (Pause);
		
		{
			foreach( Transform child in transform )
			{
				child.gameObject.SetActive(false);
			} 
			flag = false;
			Debug.Log ("StartDelayAssetOff says Flag False");
		}
		
	}
	
	public void StartDelayAssetOn() 
	{
		//Debug.Log ("Delaydisabled says Starting Coroutine StartDelayAssetOn");

			if (flag == true) {
			StartCoroutine (DelayAssetOn ());
			flag = false;
		}

			if (flag == false) {

			foreach( Transform child in transform )
			{
				child.gameObject.SetActive(false);
			} 
			flag = true;

		}


	}	

	public void StartDelayAssetOff()
	{
		//Debug.Log ("Delaydisabled says Starting Coroutine StartDelayAssetOff");


		if (flag == true) {
			StartCoroutine (DelayAssetOff ());
			flag = false;
			Debug.Log ("StartDelayAssetOff says Flag False");
		}
		
		if (flag == false) {
			
			foreach( Transform child in transform )
			{
				child.gameObject.SetActive(true);
			} 
			flag = true;
			
		}
	}
	
}

