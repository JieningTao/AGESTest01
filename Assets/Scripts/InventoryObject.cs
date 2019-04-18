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

    private new Collider collider;
    private new Renderer renderer;
    private Renderer[] childrenrenders;

    public string ObjectName => objectName;
    public Sprite Icon => icon;
    public string Description => description;

    public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }

    private void Start()
    {
        collider = GetComponent<Collider>();
        renderer = GetComponent<Renderer>();
        childrenrenders = GetComponentsInChildren<Renderer>();
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
        collider.enabled = false;
        if (renderer != null)
            renderer.enabled = false;
        else
        {
            foreach (Renderer r in childrenrenders)
            {
                r.enabled = false;
            }

        }
    }
}
