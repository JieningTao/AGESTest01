using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceLights : MonoBehaviour
{




    private Light spotlight;

    void Start()
    {
        spotlight = GetComponentInChildren<Light>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            spotlight.enabled = true;
    }

}
