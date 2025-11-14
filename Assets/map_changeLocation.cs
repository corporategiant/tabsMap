using UnityEngine;
using UnityEngine.AI;
public class map_changeLocation : MonoBehaviour
{
    public GameObject[] mapLocatorIcons;
    public GameObject activeMapLocatorIcon;
    public Material matMapIconOn;
    public Material matMapIconOff;
    public NavMeshAgent minime;
    public GameObject mapLocator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void OnMouseDown()
    {
        foreach (GameObject mapLocatorIcon in mapLocatorIcons)
        {
            mapLocatorIcon.GetComponent<MeshRenderer>().material = matMapIconOff;
            mapLocatorIcon.GetComponent<Animator>().enabled = false;

        }


        activeMapLocatorIcon.GetComponent<MeshRenderer>().material = matMapIconOn;
        activeMapLocatorIcon.GetComponent<Animator>().enabled = true;
        minime.Warp(mapLocator.transform.position);
    }
    
}
