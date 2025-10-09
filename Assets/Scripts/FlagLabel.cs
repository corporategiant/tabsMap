using System;
using UnityEngine;
using TMPro;

public class FlagLabel : MonoBehaviour
{
    public String FlagName;
    public GameObject FlagLabelBox;

    public TextMeshProUGUI FlagNameTMP;

    private float temps;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnMouseDown(){
		if (Input.GetMouseButtonDown (0)) {
			temps = Time.time;
			}
		}

	
	void OnMouseUp(){
		
		if ( Input.GetMouseButtonUp (0) )
		{
            if (Time.time - temps <= 0.5)
            {
                // this object was clicked - do something
                Debug.Log("FlagLabel Says Was Clicked");
                FlagLabelBox.GetComponent<SpringScaleFlag> ().startDelaySpringScale ();
                
			}
			
		}

	}
}
