using UnityEngine;
using System.Collections;

public class ClickChangeColour : MonoBehaviour {

	private float temps;

	public Material Shader;

	public Color[] ColorSelect;

	int arrayPos = 0;
	
	void OnMouseDown(){
		if (Input.GetMouseButtonDown (0)) {
			temps = Time.time;

			if (arrayPos >= ColorSelect.Length -1) {
				arrayPos = 0;
			}
			else {
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
				
				Shader.SetColor("_Color", ColorSelect[arrayPos]);
			
			}
			
		}
		
	}
}   