using UnityEngine;

public class clickItem : MonoBehaviour
{

    public GameObject Item;
   void OnMouseDown()
    {
        Item.gameObject.GetComponent<SpringScale>().startDelaySpringScale();
    }


}
