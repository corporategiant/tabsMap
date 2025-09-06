using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableType { NPC, Item }

public class Interactable : MonoBehaviour
{
    public Actor myActor { get; private set; }

    public InteractableType interactionType;

    void Awake() 
    {
        if(interactionType == InteractableType.NPC)
        { myActor = GetComponent<Actor>(); }
    }

    public void InteractWithItem()
    {
        // Pickup Item

        Debug.Log ("Interactable");
        Destroy(gameObject);
    }
}
