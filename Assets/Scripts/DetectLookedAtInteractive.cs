using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLookedAtInteractive : MonoBehaviour
{


    /// <summary>
    /// This class is used as part of interactive objects to detect objects players looking at
    /// </summary>

    [SerializeField]
    private Transform RaycastOrigin;
    [SerializeField]
    private float RaycastDistance = 5.0f;
    [SerializeField]
    private LayerMask Avoid;



    private IInteractables lookedAtInteractive;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit Hitinfo;

        if (Physics.Raycast(RaycastOrigin.position, RaycastOrigin.forward, out Hitinfo, RaycastDistance,Avoid))
        {
            //Debug.Log("Player is looking at: "+Hitinfo.collider.gameObject.name);
            if (Hitinfo.collider.gameObject.GetComponent<IInteractables>() != null)
            {
                lookedAtInteractive = Hitinfo.collider.gameObject.GetComponent<IInteractables>();
            }
        }



        Debug.DrawRay(RaycastOrigin.position, RaycastOrigin.forward*RaycastDistance,Color.blue);
    }





    public IInteractables LookedAtInteractive
    {
        get
        {
            return lookedAtInteractive;
        }
        set
        {
            lookedAtInteractive = value;
        }
    }

}
