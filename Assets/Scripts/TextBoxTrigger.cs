using UnityEngine;

public class TextBoxTrigger : MonoBehaviour
{
    public GameObject NPC;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Entered Trigger");
        NPC.GetComponent<ClickableTextBoxes>().TextBoxClickable = true;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Player Exited Trigger");
        NPC.GetComponent<ClickableTextBoxes>().TextBoxClickable = false;
    }
}
