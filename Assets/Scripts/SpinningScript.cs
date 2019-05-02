using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningScript : MonoBehaviour
{
    [SerializeField]
    private float spinSpeed;
    private void FixedUpdate()
    {
       //transform.rotation = transform.rotation.y + spinSpeed;
    }
}
