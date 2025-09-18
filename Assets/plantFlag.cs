using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.InputSystem.Interactions;
using System.Collections;

public class plantFlag : MonoBehaviour
{
    public GameObject flag;
    public GameObject flagLocator;
    public GameObject flag1;
    public GameObject flag2;
    public GameObject flag3;

    public int flagCount;

    public void startPlantFlag()
    {
        StartCoroutine(plantTheFlag());
        this.gameObject.GetComponent<Animator>().SetBool("plantFlag",true);
        this.gameObject.GetComponent<Animator>().Play("PlantFlag");
        flag.SetActive(true);
    }


    IEnumerator plantTheFlag()
    {
        flag.SetActive(true);
        this.gameObject.GetComponent<Animator>().Play("PlantFlag");
        yield return new WaitForSeconds(2.2f);
        flag.SetActive(false);
        this.gameObject.GetComponent<Animator>().SetBool("PlantFlag", false);
        this.gameObject.GetComponent<NavMeshAgent>().enabled = true;
        if (flagCount == 1) { 
        flag1.transform.position = flagLocator.transform.position;
            flagCount = 2;
        }
        else if (flagCount == 2)
        {
            flag2.transform.position = flagLocator.transform.position;
            flagCount = 3;
        }
        else if (flagCount == 3)
        {
            flag3.transform.position = flagLocator.transform.position;
            flagCount = 1;
        }
    }
}
