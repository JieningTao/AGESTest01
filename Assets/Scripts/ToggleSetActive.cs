using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject
{
    [Tooltip("The Object to toggle active or not")]
    [SerializeField]
    private GameObject ObjectToToggle;
    [Tooltip("Can this be toggled more than once")]
    [SerializeField]
    private bool IsReusable;

    private bool hasBeenUsed = false;

    /// <summary>
    /// toggle the game object given on and off when the player interacts with it.
    /// </summary>
    public override void InteractWith()
    {


        if (IsReusable||!hasBeenUsed)
        {
            base.InteractWith();
            ObjectToToggle.SetActive(!ObjectToToggle.activeSelf);
            hasBeenUsed = true;
            if (!IsReusable)
                displayText = string.Empty;
        }
        
    }







}
