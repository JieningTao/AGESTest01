using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLookedAtInteractive : MonoBehaviour
{
    /// <summary>
    /// This class is used as part of interactive objects to detect objects players looking at
    /// </summary>

    [SerializeField]
    private Transform rayCastOrigin;
    [SerializeField]
    private float rayCastDistance = 5.0f;

    [SerializeField]
    private LayerMask Avoid;

    public static event Action<IInteractables> LookedAtInteractiveChanged;
    private IInteractables lookedAtInteractive;

    // Update is called once per frame
    void FixedUpdate()
    {
        LookedAtInteractive = GetLookedAtInteractive();
    }

    private IInteractables GetLookedAtInteractive()
    {
        //returns first Iinteractive hit by raycast, or null if none are found.
        Debug.DrawRay(rayCastOrigin.position, rayCastOrigin.forward * rayCastDistance, Color.blue);

        RaycastHit Hitinfo;

        if (Physics.Raycast(rayCastOrigin.position, rayCastOrigin.forward, out Hitinfo, rayCastDistance, Avoid))
        {
            //Debug.Log("Player is looking at: "+Hitinfo.collider.gameObject.name);
            if (Hitinfo.collider.gameObject.GetComponent<IInteractables>() != null)
            {

                return Hitinfo.collider.gameObject.GetComponent<IInteractables>();
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }

    }

    public IInteractables LookedAtInteractive
    {
        get
        {
            return lookedAtInteractive;
        }
        set
        {
            bool isInteractiveChanges = value != lookedAtInteractive;
            if (isInteractiveChanges)
            {

                lookedAtInteractive = value;

                if(LookedAtInteractiveChanged!=null)
                LookedAtInteractiveChanged.Invoke(lookedAtInteractive);
            }
            
        }
    }

}
