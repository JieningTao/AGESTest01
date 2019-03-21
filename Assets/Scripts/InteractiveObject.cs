using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractables
{
    [SerializeField]
    protected string displayText = nameof(InteractiveObject);


    private AudioSource InteractSound;

    public string DisplayText => displayText;

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
