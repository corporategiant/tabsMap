using UnityEngine;

public class mapSwitcher : MonoBehaviour
{

    public GameObject MapGrp;
    public GameObject Building;
    public Material HighlightMat;
    public Material BuildingMat;
    
    public Transform Popups;
    public Transform Buildings;

    void OnMouseDown()
    {
        Popups = MapGrp.transform.parent;
        
        foreach (Transform childTransform in Popups)
        {
            childTransform.GetComponent<SpringScale>().ResetScale();

        }

        Buildings = this.transform.parent;
        foreach (Transform childTransform in Buildings)
        {
            childTransform.GetComponent<MeshRenderer>().material = BuildingMat;
            
        }
        MapGrp.gameObject.GetComponent<SpringScale>().startDelaySpringScale();
        if (Building != null)
        {
            
            {

                Building.GetComponent<MeshRenderer>().material = HighlightMat;
                
            }

        }
    }

    public void ResetMapScale()
    {
        MapGrp.gameObject.GetComponent<SpringScale>().ResetScale();
        if (Building != null)
        {
            Building.GetComponent<MeshRenderer>().material = BuildingMat;
        }
        
    }
}
