using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class SpringScaleFlag : MonoBehaviour {

	public bool LaunchatStart;
	public bool Open;
    public bool EndScreenOn;

    public GameObject StartScale;


	public float StartTime;
	public float ScaleTime;

	public float longDelay;

	

	// Use this for initialization
	void Start () {
        

		if (LaunchatStart == true)
        {
            this.gameObject.transform.localScale = StartScale.transform.localScale;
            StartCoroutine(DelaySpringScale());
        }
			
	}

	public void startDelaySpringScale(){

		if (Open == false)
		{
			Debug.Log("StartingDelaySpringScale");
			StartCoroutine (DelaySpringScale());
		
		}

		else if (Open == true)
		{
			iTween.StopByName ("SpScale");
			this.gameObject.transform.localScale = StartScale.transform.localScale;
			Open = false;


        }

	}

    public void startLongDelaySpringScale()
    {

        if (Open == false)
        {
            Debug.Log("StartingLongDelaySpringScale");
            StartCoroutine(LongDelaySpringScale());

        }

        else if (Open == true)
        {
            iTween.StopByName("SpScale");
            StopCoroutine("LongDelaySpringScale");
            StopCoroutine("DelaySpringScale");
            this.gameObject.transform.localScale = StartScale.transform.localScale;
            Open = false;

        }

    }

    public void ResetScale()
	{
		iTween.StopByName ("SpScale");
		StopCoroutine("LongDelaySpringScale");
        StopCoroutine("DelaySpringScale");
        this.gameObject.transform.localScale = StartScale.transform.localScale;
		Open = false;

    }

	public void SetFlagOpen()
	{
		Open = true;

    }

	public void SetFlagClosed()
	{
		Open = false;

    }

	IEnumerator DelaySpringScale()
	{
		yield return new WaitForSeconds (StartTime);
		iTween.ScaleTo(gameObject, iTween.Hash("name", "SpScale", "scale", new Vector3(1f, 1f, 1f), "time", ScaleTime, "easeType", iTween.EaseType.spring));
		Open = true;

    }

	IEnumerator LongDelaySpringScale()
	{
		yield return new WaitForSeconds(longDelay);
		if (EndScreenOn == true) { 
			iTween.ScaleTo(gameObject, iTween.Hash("name", "SpScale", "scale", new Vector3(1f, 1f, 1f), "time", ScaleTime, "easeType", iTween.EaseType.spring));
			Open = true;


        }
    }
    
}
