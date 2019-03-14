using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    [SerializeField]
    private float Speed = 5.0f;
    [SerializeField]
    public bool Rising = false;
    [SerializeField]
    public bool Moving = false;
    [SerializeField]
    private float MaxHeight;
    [SerializeField]
    private float MinHeight;
    [SerializeField]
    public bool Bounce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        if (Bounce)
        {
            if ((this.transform.position.y >= MaxHeight && Rising)||(this.transform.position.y <= MinHeight && !Rising))
            {
                Rising = !Rising;
            }
        }

        if (Moving)
        {
            

            if (Rising && this.transform.position.y < MaxHeight)
            {
                transform.SetPositionAndRotation(transform.position + new Vector3(0, Speed, 0), transform.rotation);
                //GetComponent<Rigidbody>().velocity = new Vector3(0, Speed, 0);
            }
            else if (!Rising && this.transform.position.y > MinHeight)
            {
                transform.SetPositionAndRotation(transform.position + new Vector3(0, -Speed, 0), transform.rotation);
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
    
    private void Update()
    {
        //this.GetComponent<Rigidbody>().velocity = new Vector3(0, -Speed, 0);
    }
}
