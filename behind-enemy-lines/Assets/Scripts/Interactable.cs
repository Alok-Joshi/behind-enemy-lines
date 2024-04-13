using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvents;
    [SerializeField]
    public string promptMessage;

    public virtual string OnLook()
    {
        return promptMessage;

    }
    public void BaseInteract(){
        if (useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke(); //null check
        Interact();
    }
    protected virtual void Interact(){

    }
}
