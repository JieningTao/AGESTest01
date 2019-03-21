using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorSpin : MonoBehaviour
{
    [SerializeField]
    private float spinSpeed;





    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
