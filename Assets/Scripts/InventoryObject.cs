using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{

    [Tooltip("The name of the object as appeared in the inventory menu")]
    [SerializeField]
    private string objectName = "thing";

    [Tooltip("The description that the player will see when looked at in inventory")]
    [TextArea(3,8)]
    [SerializeField]
    private string description = "This item does not have a discription";

    [Tooltip("the icon of the object in the inventory")]
    [SerializeField]
    private Sprite icon;

    [SerializeField]
    private bool disappearOnCollect = true;

    private new Collider[] colliders;
    private new Renderer renderer;
    private Renderer[] childrenrenders;
    private Light[] childrenLights;


    public string ObjectName => objectName;
    public Sprite Icon => icon;
    public string Description => description;

    public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }

    private void Start()
    {
        childrenLights = GetComponentsInChildren<Light>();
        DontDestroyOnLoad(this);
        colliders = GetComponents<Collider>();
        renderer = GetComponent<Renderer>();
        childrenrenders = GetComponentsInChildren<Renderer>();
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// when the pick up object is interacted with,
    /// 1. add to inventory
    /// 2. remove from world
    /// </summary>
    public override void InteractWith()
    {
        base.InteractWith();
        Debug.Log("player picked up: "+this.name);
        PlayerInventory.InventoryObjects.Add(this);

        InventoryMenu.Instance.AddItemToMenu(this);

        if (disappearOnCollect)
        {
            foreach (Collider C in colliders)
                C.enabled = false;

            if (renderer != null)
                renderer.enabled = false;
            else
            {
                foreach (Renderer r in childrenrenders)
                    r.enabled = false;
                
            }

            foreach (Light G in childrenLights)
            {
                G.enabled = false;
            }
        }
    }
}
