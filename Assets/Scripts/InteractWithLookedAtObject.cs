using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// detects when the player presses the interact button while looking at interactable, if so activats interactable
/// </summary>

public class InteractWithLookedAtObject : MonoBehaviour
{

    [SerializeField]
    private DetectLookedAtInteractive Detectedscript;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact")&&Detectedscript.LookedAtInteractive != null)
        {

            Detectedscript.LookedAtInteractive.InteractWith();
        }
    }
}
