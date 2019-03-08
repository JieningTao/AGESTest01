using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingStairs : MonoBehaviour
{
    [SerializeField]
    private float RisingSpeed = 5.0f;
    [SerializeField]
    private bool Rising = false;
    [SerializeField]
    Transform Stairs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Rising&&Stairs.position.y<=37)
        {
            
            Stairs.transform.SetPositionAndRotation(Stairs.transform.position+new Vector3(0,RisingSpeed,0),Stairs.transform.rotation);

        }
    }


}
