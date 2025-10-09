using UnityEngine;
using System.Collections;

public class RotateDiscreet : MonoBehaviour {

	public int x;
	public int y;
	public int z;
	public float Pause;
	public int numRotations;

	
	IEnumerator Start()
	{

		for(int i = 0; i < numRotations; i++)
	{
	
		{		
			yield return new WaitForSeconds(Pause);		
			transform.Rotate (x,y,-z);		
		}
	}
}
}