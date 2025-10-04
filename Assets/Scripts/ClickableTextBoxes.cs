using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickableTextBoxes : MonoBehaviour {

	public bool MultipleTextBox;

	public GameObject TextBoxOn;
    public GameObject Player;

    public GameObject HUDFlag;

    public GameObject[] TextBoxes;

	public bool TextBoxesOn;

    public bool TextBoxClickable;

    private float temps;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log ("Player Entered Trigger");
        TextBoxClickable = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player Exited Trigger");
        TextBoxClickable = false;
        TextBoxOn.GetComponent<SpringScale>().ResetScale();
    }

    void OnMouseDown(){

        if (TextBoxClickable == true){
            if (Input.GetMouseButtonDown (0)) {
                temps = Time.time;
            }
        }
    }



    void OnMouseUp(){

        if (TextBoxClickable == true)
        {
            if ( Input.GetMouseButtonUp (0) )
		{
            
            if (Time.time - temps <= 0.5)
			{
				// this object was clicked - do something
				Debug.Log ("Clickable Says Was Clicked");
                    HUDFlag.SetActive(false);

                    TextBoxOn.GetComponent<SpringScale> ().startDelaySpringScale ();
				if (MultipleTextBox == true) 
				{
                    foreach (GameObject Textbox in TextBoxes)
                    {

                        Textbox.GetComponent<SpringScale>().ResetScale();

                    }
                    
				}

                }

            }
            
        }

	}
}   

