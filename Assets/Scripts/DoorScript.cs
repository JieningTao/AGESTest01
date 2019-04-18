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

    

    [Tooltip("Text that shows when the door is locked")]
    [SerializeField]
    private string LockedText = "Locked";

    [Tooltip("Door can't open clip")]
    [SerializeField]
    private AudioClip LockedSound;

    [Tooltip("Door opening sound")]
    [SerializeField]
    private AudioClip UnlockedSound;

    [Tooltip("The key taht opens this door")]
    [SerializeField]
    private InventoryObject keyRequired;

    [Tooltip("Does this door consume the key?")]
    [SerializeField]
    private bool ConsumeKey;

    public override string DisplayText
    {
        get
        {
            string toreturn;
            if (IsLocked)
                toreturn = HasKey ? $"Use {keyRequired.gameObject.name}" : LockedText;
            else
                toreturn = base.DisplayText;

            return toreturn;
        }
    }


    private bool hasBeenUsed = false;
    private Animator animator;
    private bool IsLocked;


    private bool HasKey => PlayerInventory.InventoryObjects.Contains(keyRequired);

    /// <summary>
    /// using constructor to make display text
    /// </summary>
    public DoorScript()
    {
        displayText = nameof(DoorScript);
    }

    private void Start()
    {
        if (keyRequired != null)
        {
            IsLocked = true;
        }
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// toggle the door open or close when the player interacts with it.
    /// </summary>
    public override void InteractWith()
    {
        if ((IsReusable || !hasBeenUsed) && (!IsLocked || HasKey))
        {
            InteractSound.clip = UnlockedSound;

            IsOpen = !IsOpen;
            animator.SetBool("Open", IsOpen);
            hasBeenUsed = true;
            if (!IsReusable)
                displayText = string.Empty;

            if (IsLocked)
            {
                UnlockDoor();
            }

            if (!IsReusable)
                displayText = string.Empty;
        }
        else if (IsLocked && !HasKey)
        {
            InteractSound.clip = LockedSound;

        }
        base.InteractWith();
    }

    private void UnlockDoor()
    {
        IsLocked = false;
        if (keyRequired != null && ConsumeKey)
        {
            PlayerInventory.InventoryObjects.Remove(keyRequired);
        }
    }
}
