using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorScript : InteractiveObject
{
    [Tooltip("Can this be toggled more than once")]
    [SerializeField]
    private bool IsReusable;

    [Tooltip("Does This door start Open")]
    [SerializeField]
    private bool IsOpen;

    private bool hasBeenUsed = false;
    private Animator animator;


    /// <summary>
    /// using constructor to make display text
    /// </summary>
    public DoorScript()
    {
        displayText = nameof(DoorScript);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// toggle the door open or close when the player interacts with it.
    /// </summary>
    public override void InteractWith()
    {


        if (IsReusable || !hasBeenUsed)
        {
            IsOpen = !IsOpen;
            animator.SetBool("Open", IsOpen);
            hasBeenUsed = true;
            if (!IsReusable)
                displayText = string.Empty;
        }

    }


}
