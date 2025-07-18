using UnityEngine;
using System.Collections;

public class ClickableTextBox : MonoBehaviour {

	public bool ChainTextBox;
	public bool MultiTextBox;

	public GameObject TextBoxOn;
	public GameObject TextBoxOff;

	public GameObject []TextBoxes;


	private float temps;

	public bool flag;

	int arrayPos = 0;

	void OnMouseDown(){
		if (Input.GetMouseButtonDown (0)) {
			temps = Time.time;
			

				if (flag == true)
				{
				if (arrayPos >= TextBoxes.Length -1) {
					arrayPos = 0;
				}
				else {

					arrayPos += 1;

				}
				flag = false;
			}
				else
				{
					flag = true;
				}
			}
		}

	
	void OnMouseUp(){
		
		if ( Input.GetMouseButtonUp (0) )
		{
			if (Time.time - temps <= 0.5)
			{
				// this object was clicked - do something
				Debug.Log ("ClickableTextBox Says Was Clicked");
				TextBoxOn.GetComponent<SpringScale> ().startDelaySpringScale ();
				if (ChainTextBox == true) 
				{	
					TextBoxOff.GetComponent<SpringScale> ().ResetScale ();
					foreach (GameObject TextBox in TextBoxes)
					{
						TextBox.GetComponent<SpringScale> ().ResetScale (); 
					}

				}
				
				if (MultiTextBox == true)
				{
					TextBoxOn = TextBoxes [arrayPos];

				}
			}
			
		}

	}
}

