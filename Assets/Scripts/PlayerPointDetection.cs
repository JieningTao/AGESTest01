using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointDetection : MonoBehaviour
{
    [SerializeField]
    private string DetectedMessage;
    [SerializeField]
    private bool isSingleUse;

    public static event Action<string> ReachedByPlayer;
    private BoxCollider Checkzone;


    // Start is called before the first frame update
    void Awake()
    {
        Checkzone = GetComponent<BoxCollider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ReachedByPlayer.Invoke(DetectedMessage);
            Debug.Log(DetectedMessage);

            if (isSingleUse)
                this.gameObject.SetActive(false);
        }
            

        


    }
}
