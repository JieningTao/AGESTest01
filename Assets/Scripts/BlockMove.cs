using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    [SerializeField]
    public float speed = 5.0f;
    [SerializeField]
    public bool rising = false;
    [SerializeField]
    public bool moving = false;
    [Tooltip("max height that the block can go")]
    [SerializeField]
    public float maxHeight;
    [Tooltip("min height that the block can go")]
    [SerializeField]
    public float minHeight;
    [Tooltip("if the block will auto reverse once reaching ma")]
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
                //GetComponent<Rigidbody>().velocity = new Vector3(0, Speed, 0);
            }
            else if (!rising && this.transform.position.y > minHeight)
            {
                transform.SetPositionAndRotation(transform.position + new Vector3(0, -speed, 0), transform.rotation);
                //GetComponent<Rigidbody>().velocity = new Vector3(0, Speed, 0);
            }
            else
            {
                //GetComponent<Rigidbody>().velocity = Vector3.zero;
            }

        }
        else
        {
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
