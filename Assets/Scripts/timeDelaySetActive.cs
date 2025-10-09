using UnityEngine;
using System.Collections;

public class timeDelaySetActive : MonoBehaviour
{
    public GameObject[] Targets;
    public float Delay;
    public bool SetActive;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SetActive == true)
        {
            StartCoroutine(StartTimeDelaySetActive());
        }
        if (SetActive == false)
        {
            StartCoroutine(StartTimeDelaySetInactive());
        }
    }

    public void Skip()
    {
        if (SetActive == true)
        {
            StopAllCoroutines();
            foreach (GameObject Target in Targets){
            Target.SetActive(true);
        }
        }
        if (SetActive == false)
        {
            StopAllCoroutines();
            foreach (GameObject Target in Targets)
        {
            Target.SetActive(false);
        }

        }    
    }

    IEnumerator StartTimeDelaySetActive()
    {
        yield return new WaitForSeconds(Delay);
        foreach (GameObject Target in Targets){
            Target.SetActive(true);
        }
    }

    IEnumerator StartTimeDelaySetInactive()
    {
        yield return new WaitForSeconds(Delay);
        foreach (GameObject Target in Targets)
        {
            Target.SetActive(false);
        }
    }

    // Update is called once per frame
        void Update()
    {
        
    }
}
