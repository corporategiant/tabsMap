using UnityEngine;
using UnityEngine.AI;

public class mapOff : MonoBehaviour
{

    public GameObject MapGrp;
    public GameObject Player;
    public GameObject HUD;
    

    void OnMouseDown()
    {
            ResetMapScale();
    }


    public void ResetMapScale()
    {
        MapGrp.gameObject.GetComponent<SpringScale>().ResetScale();
        PlayerPrefs.SetInt("mapOn", 0);
        HUD.SetActive(true);
        Player.GetComponent<NavMeshAgent>().enabled = true;
        Player.GetComponent<PlayerController>().enabled = true;
    }
}
