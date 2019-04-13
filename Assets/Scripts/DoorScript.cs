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

    [Tooltip("Check this to lock the door at start")]
    [SerializeField]
    private bool IsLocked;

    [Tooltip("Text that shows when the door is locked")]
    [SerializeField]
    private string LockedText = "Locked";

    [Tooltip("Door can't open clip")]
    [SerializeField]
    private AudioClip LockedSound;

    [Tooltip("Door opening sound")]
    [SerializeField]
    private AudioClip UnlockedSound;

    public override string DisplayText => IsLocked ? LockedText : base.DisplayText;

    private bool hasBeenUsed = false;
    private Animator animator;


    /// <summary>
    /// using constructor to make display text
    /// </summary>
    public DoorScript()
    {
        displayText = nameof(DoorScript);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// toggle the door open or close when the player interacts with it.
    /// </summary>
    public override void InteractWith()
    {


        if ((IsReusable || !hasBeenUsed) && !IsLocked)
        {
            InteractSound.clip = UnlockedSound;
            
            IsOpen = !IsOpen;
            animator.SetBool("Open", IsOpen);
            hasBeenUsed = true;
            if (!IsReusable)
                displayText = string.Empty;

        }
        else if (IsLocked)
        {
            InteractSound.clip = LockedSound;
        }


        base.InteractWith();
    }


}
