using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocadeScript : MonoBehaviour
{
    [SerializeField]
    private bool Open = false;
    [SerializeField]
    private GameObject B1;
    [SerializeField]
    private GameObject B2;
    [SerializeField]
    private GameObject B3;
    [SerializeField]
    private GameObject B4;
    [SerializeField]
    private GameObject B5;

    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Open)
        {
            if(timer >=10)
            B3.GetComponent<BlockMove>().moving = true;

            if (timer >= 50)
            {
                B2.GetComponent<BlockMove>().moving = true;
                B4.GetComponent<BlockMove>().moving = true;
            }

            if (timer >= 90)
            {
                B1.GetComponent<BlockMove>().moving = true;
                B5.GetComponent<BlockMove>().moving = true;
            }

            timer++;
        }
    }
}
