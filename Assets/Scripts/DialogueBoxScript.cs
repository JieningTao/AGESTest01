using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxScript : MonoBehaviour
{


    private string stuffToDisplay;
    
    private Text displayText;
    private int timer;

    private void Awake()
    {
        displayText = GetComponent<Text>();
        UpdateDisplayText();
    }

    private void UpdateDisplayText()
    {
        if (stuffToDisplay != "")
            displayText.text = "[Crow]: \n"+stuffToDisplay;
        else
            displayText.text = string.Empty;
    }


    private void OnSaidToPlayer(string stuffHeard)
    {
        stuffToDisplay = stuffHeard;
        timer = stuffToDisplay.Length * 4 + 70;
        UpdateDisplayText();
    }

    private void FixedUpdate()
    {
        if (timer <= 0)
        {
            stuffToDisplay = "";
            UpdateDisplayText();
        }
        else
        timer--;
    }


    #region Event Sub/Unsub
    /// <summary>
    /// subs and unsubs from event when object is enabled and disabled.
    /// </summary>
    private void OnEnable()
    {
        BirdScript.SaidToPlayer += OnSaidToPlayer;
    }

    private void OnDisable()
    {
        BirdScript.SaidToPlayer -= OnSaidToPlayer;
    }
    #endregion
}
