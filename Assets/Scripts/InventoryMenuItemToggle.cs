using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemToggle : MonoBehaviour
{


    [Tooltip("Image that appears in menu")]
    [SerializeField]
    private Image itemImage;

    [Tooltip("Name that appears in menu")]
    [SerializeField]
    private Text itemName;




    public static event Action<InventoryObject> InventoryMenuItemSelected;
    
    private InventoryObject linkedObject;
    private AudioSource audioSource;

    public InventoryObject LinkedObject
    {
        get { return linkedObject; }
        set
        {
            linkedObject = value;
            itemImage.sprite = linkedObject.Icon;
            itemName.text = linkedObject.ObjectName;
        }
    }

    private void Awake()
    {
        GetComponent<Toggle>().group = GetComponentInParent<ToggleGroup>();
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// this will be plugged into the onvalu changed function of the toggle to update information
    /// </summary>
    public void InventoryItemWasToggled(bool isOn)
    {
        //only proceed when toggle is selected, not when deselected
        Debug.Log("Toggled: "+isOn);
        if (isOn)
        {
            audioSource.Play();
            InventoryMenuItemSelected?.Invoke(linkedObject);
        }
    }
}
