using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    private float Hoverheight;

    private Transform PlayerLocation;
    private InventoryObject thisObjectScript;

    private void Start()
    {
        thisObjectScript = GetComponent<InventoryObject>();
    }

    private void FixedUpdate()
    {
        if (PlayerInventory.InventoryObjects.Contains(thisObjectScript))
        {
            follow();
        }
    }

    private void follow()
    {
        this.transform.position = PlayerLocation.position + new Vector3(0, Hoverheight, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            PlayerLocation = other.transform;
    }
}
