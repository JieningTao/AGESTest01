using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// detects when the player presses the interact button while looking at interactable, if so activats interactable
/// </summary>

public class InteractWithLookedAtObject : MonoBehaviour
{

    private IInteractables lookedAtInteractable;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact")&& lookedAtInteractable != null)
        {
            lookedAtInteractable.InteractWith();
        }
    }

    private void OnLookedAtInteractiveChanged(IInteractables NewLookedAtInteractable)
    {
        lookedAtInteractable = NewLookedAtInteractable;
    }

    #region Event Sub/Unsub
    /// <summary>
    /// subs and unsubs from event when object is enabled and disabled.
    /// </summary>


    private void OnEnable()
    {
        DetectLookedAtInteractive.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectLookedAtInteractive.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
    }
    #endregion

}
