using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookedAtInteractiveDisplayText : MonoBehaviour
{

    private IInteractables lookedAtInteractable;
    private Text displayText;

    private void Awake()
    {
        displayText = GetComponent<Text>();
        UpdateDisplayText();
    }

    private void UpdateDisplayText()
    {
        if (lookedAtInteractable != null)
            displayText.text = lookedAtInteractable.DisplayText;
        else
            displayText.text = string.Empty;
    }

    private void OnLookedAtInteractiveChanged(IInteractables NewLookedAtInteractable)
    {
        lookedAtInteractable = NewLookedAtInteractable;
        UpdateDisplayText();
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
