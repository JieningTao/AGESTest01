using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    public bool rising = false;
    [SerializeField]
    public bool moving = false;
    [Tooltip("max height that the block can go")]
    [SerializeField]
    private float maxHeight;
    [Tooltip("min height that the block can go")]
    [SerializeField]
    private float minHeight;
    [Tooltip("if the block will auto reverse once reaching max or min height, used by wave in manager")]
    [SerializeField]
    public bool bounce;
    
    void FixedUpdate()
    {
        if (bounce)
        {
            if ((this.transform.position.y >= maxHeight && rising)||(this.transform.position.y <= minHeight && !rising))
            {
                rising = !rising;
            }
        }

        if (moving)
        {
            if (rising && this.transform.position.y < maxHeight)
            {
                transform.SetPositionAndRotation(transform.position + new Vector3(0, speed, 0), transform.rotation);
            }
            else if (!rising && this.transform.position.y > minHeight)
            {
                transform.SetPositionAndRotation(transform.position + new Vector3(0, -speed, 0), transform.rotation);
            }
            else
            {
            }

        }
        else
        {
        }
    }
}
