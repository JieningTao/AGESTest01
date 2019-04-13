using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractables
{
    [Tooltip("This is what the player sees when they look at the object in the world")]
    [SerializeField]
    protected string displayText = nameof(InteractiveObject);


    protected AudioSource InteractSound;

    public virtual string DisplayText => displayText;

    public virtual void InteractWith()
    {
        Debug.Log("Player interacted with: " + gameObject.name);
        InteractSound.Play();
    }

    private void Awake()
    {
        InteractSound = GetComponent<AudioSource>();
    }


}
