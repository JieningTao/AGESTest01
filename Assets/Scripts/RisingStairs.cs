using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingStairs : MonoBehaviour
{
    [SerializeField]
    private float risingSpeed = 5.0f;
    [SerializeField]
    private bool rising = false;
    [SerializeField]
    Transform stairs;

    void FixedUpdate()
    {
        if (rising&&stairs.position.y<=37)
        {
            stairs.transform.SetPositionAndRotation(stairs.transform.position+new Vector3(0,risingSpeed,0),stairs.transform.rotation);
        }
    }
}
