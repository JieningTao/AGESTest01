using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToTake : InteractiveObject
{

    public override void InteractWith()
    {
        base.InteractWith();
        Debug.Log("Player Took: " + gameObject.name);

        this.gameObject.SetActive(false);
    }

}
