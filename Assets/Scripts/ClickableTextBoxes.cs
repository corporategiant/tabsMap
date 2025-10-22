using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class ClickableTextBoxes : MonoBehaviour {

	public bool MultipleTextBox;

	public GameObject TextBoxOn;
    public GameObject Player;

    public GameObject HUDFlag;

    public GameObject[] TextBoxes;

	public bool TextBoxesOn;

    public bool TextBoxClickable;

    private float temps;

    void Start()
    {
        StartCoroutine("StartNotClickable");
    }

    IEnumerator StartNotClickable()
    {
        yield return new WaitForSeconds(0.1f);
        TextBoxClickable = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Entered Trigger");
        TextBoxClickable = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player Exited Trigger");
        TextBoxClickable = false;
        TextBoxOn.GetComponent<SpringScaleCH>().ResetScale();
    }

    void OnMouseDown(){

        if (TextBoxClickable == true){
            if (Input.GetMouseButtonDown (0)) {
                temps = Time.time;
            }
        }
    }
    public void CloseAllBoxes()
    {
        HUDFlag.SetActive(true);
        TextBoxOn.GetComponent<SpringScaleCH> ().ResetScale ();
        TextBoxesOn = false;
        if (MultipleTextBox == true) 
        {
            foreach (GameObject Textbox in TextBoxes)
            {
                Textbox.GetComponent<SpringScaleCH>().ResetScale();
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
                
                if(TextBoxesOn == false)
                {
                    HUDFlag.SetActive(false);
                    TextBoxOn.GetComponent<SpringScaleCH> ().startDelaySpringScale ();
                    TextBoxesOn = true;
                    if (MultipleTextBox == true) 
                    {
                        foreach (GameObject Textbox in TextBoxes)
                        {
                            Textbox.GetComponent<SpringScaleCH>().ResetScale();
                        }
                    }                    
				}
                if(TextBoxesOn == true)
                {
                    HUDFlag.SetActive(true);
                    TextBoxOn.GetComponent<SpringScaleCH> ().ResetScale ();
                    TextBoxesOn = false;
				    if (MultipleTextBox == true) 
                    {
                        foreach (GameObject Textbox in TextBoxes)
                        {
                            Textbox.GetComponent<SpringScaleCH>().ResetScale();
                        }
                    }                    
				}
                }

            }
            
        }

	}
}   

