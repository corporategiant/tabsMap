using UnityEngine;
using UnityEngine.AI;

public class clickMap : MonoBehaviour
{

    public GameObject MapGrp;
    public GameObject Player;
    public GameObject HUD;
    void OnMouseDown()
    {
        MapGrp.gameObject.GetComponent<SpringScale>().startDelaySpringScale();
        HUD.SetActive(false);
        Player.GetComponent<NavMeshAgent>().enabled = false;
        Player.GetComponent<PlayerController>().enabled = false;
        
    }


}
