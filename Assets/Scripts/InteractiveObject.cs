using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour, IInteractables
{
    [SerializeField]
    private string displayText = nameof(InteractiveObject);

    public string DisplayText => displayText;

    public void InteractWith()
    {
        Debug.Log("Player interacted with: " + gameObject.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
