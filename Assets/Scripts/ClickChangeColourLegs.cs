using UnityEngine;
using System.Collections;

public class ClickChangeColourLegs : MonoBehaviour {

	private float temps;
	public Material Shader;
	public Color[] ColorSelect;
	public string username;
	public string StudentID;
	int arrayPos = 0;

	void Start()
	{
		username = PlayerPrefs.GetString("username");
		StudentID = PlayerPrefs.GetString("StudentID");
		
	}
	void OnMouseDown(){
		
		if (Input.GetMouseButtonDown (0))
		{
			temps = Time.time;

			if (arrayPos >= ColorSelect.Length - 1)
			{
				arrayPos = 0;
			}
			else
			{
				arrayPos += 1;
			}

		}
	}
	
	void OnMouseUp(){
		
		if ( Input.GetMouseButtonUp (0) )
		{
			if (Time.time - temps <= 0.5)
			{
				// this object was clicked - do something
				Debug.Log ("CLICK_CHANGE_COLOUR Says Was Clicked");
				PlayerPrefs.SetInt(username + StudentID + "ColourLegs",arrayPos);
				Shader.SetColor("_Color", ColorSelect[arrayPos]);
			
			}
			
		}
		
	}
}   