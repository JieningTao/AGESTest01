﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{

    // TODO: Add long discription field
    // TODO: Add icon field

    [Tooltip("The name of the object as appeared in the inventory menu")]
    [SerializeField]
    private string objectName = "thing";


    private new Collider collider;
    private new Renderer renderer;



    public InventoryObject()
    {
        displayText = $"Take {objectName}";

    }

    private void Start()
    {
        collider = GetComponent<Collider>();
        renderer = GetComponent<Renderer>();
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
        collider.enabled = false;
        renderer.enabled = false;
    }








}
