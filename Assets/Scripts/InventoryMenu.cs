using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject inventoryMenuItemToglePrefab;

    [SerializeField]
    private GameObject toggleScrollList;

    [SerializeField]
    private Text itemLabelText;

    [SerializeField]
    private Text descriptionText;

    [SerializeField]
    private Image itemImage;

    [SerializeField]
    private AudioClip openSound;
    [Range(0, 2)]
    [SerializeField]
    private float openSoundVolume;

    [SerializeField]
    private AudioClip closeSound;
    [Range(0,2)]
    [SerializeField]
    private float closeSoundVolume;


    private static InventoryMenu instance;
    private CanvasGroup myCanvasGorup;
    private AudioSource audioSource;
    
    private FirstPersonController playerFPSScript;

    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
                throw new System.Exception("There is currently no inventory menu instance but you are trying to access it.");
            return instance;
        }
        private set { instance = value; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            throw new System.Exception("there is already an instance of inventory menu. there can be only one.");

        playerFPSScript = FindObjectOfType<FirstPersonController>();

        myCanvasGorup = GetComponent<CanvasGroup>();

        audioSource = GetComponent<AudioSource>();

        myCanvasGorup.alpha = 0;
        myCanvasGorup.interactable = false;
    }

    public void AddItemToMenu(InventoryObject inventoryItemToAdd)
    {
        GameObject clone =  Instantiate(inventoryMenuItemToglePrefab,toggleScrollList.transform);
        InventoryMenuItemToggle toggle = clone.GetComponent<InventoryMenuItemToggle>();
        toggle.LinkedObject = inventoryItemToAdd;
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Toggle Inventory"))
        {
            ToggleInventoryMenu();

        }
             
    }

    private void ToggleInventoryMenu()
    {
        myCanvasGorup.interactable = !myCanvasGorup.interactable;

        if (myCanvasGorup.interactable)
        {
            myCanvasGorup.alpha = 1;
            playerFPSScript.enabled = false;//disables cursor script on FPS controller to maually modify. 
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            audioSource.Play();
        }
        else
        {
            myCanvasGorup.alpha = 0;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            playerFPSScript.enabled = true;//happens after setting cursor so the cursor script FPS controller has don't interfere
            audioSource.Play();
        }

    }

    private void PlaySoundEffect(AudioClip soundToPlay, float volumeToPlay)
    {
        audioSource.clip = soundToPlay;
        audioSource.volume = volumeToPlay;
        audioSource.Play();
    }

    public void ExitMenu()
    {
        myCanvasGorup.interactable = false;
        myCanvasGorup.alpha = 0;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerFPSScript.enabled = true;//happens after setting cursor so the cursor script FPS controller has don't interfere
    }


    /// <summary>
    /// event handler for inventory menu selected
    /// </summary>
    /// <param name="inventoryObjectThatWasSelected"></param>
    private void OnInventoryMenuSelected(InventoryObject inventoryObjectThatWasSelected)
    {
        itemLabelText.text = inventoryObjectThatWasSelected.ObjectName;
        descriptionText.text = inventoryObjectThatWasSelected.Description;
        itemImage.sprite = inventoryObjectThatWasSelected.Icon;
    }

    private void OnEnable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected += OnInventoryMenuSelected;
    }

    private void OnDisable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected -= OnInventoryMenuSelected;
    }
}
