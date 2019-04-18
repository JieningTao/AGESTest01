using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    [Tooltip("max height that the block can go")]
    [SerializeField]
    public float maxHeight;

    [Tooltip("min height that the block can go")]
    [SerializeField]
    public float minHeight;

    [Tooltip("if the block will auto reverse once reaching ma")]
    [SerializeField]
    public bool bounce;

    public float speed = 5.0f;
    public bool rising = false;
    public bool moving = false;
    public float delayTimer;
    public string coorInGrid;

    void FixedUpdate()
    {
        if (delayTimer <= 0)
        {
            if (bounce)
            {
                if ((this.transform.position.y >= maxHeight && rising) || (this.transform.position.y <= minHeight && !rising))
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
            }

        }
        else
        {
            delayTimer -= Time.deltaTime;
        }

    }
}
