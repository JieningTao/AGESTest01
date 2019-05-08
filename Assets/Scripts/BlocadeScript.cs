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


    private BlockMove[] blockScripts = new BlockMove[5];
    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        blockScripts[0] = B1.GetComponent<BlockMove>();
        blockScripts[1] = B2.GetComponent<BlockMove>();
        blockScripts[2] = B3.GetComponent<BlockMove>();
        blockScripts[3] = B4.GetComponent<BlockMove>();
        blockScripts[4] = B5.GetComponent<BlockMove>();
        //OpenBlocade();
    }

    // Update is called once per frame

    private void OpenBlocade()
    {

        blockScripts[2].moving = true;

        blockScripts[1].moving = true;
        blockScripts[1].delayTimer = 0.5f;
        blockScripts[3].moving = true;
        blockScripts[3].delayTimer = 0.5f;

        blockScripts[0].moving = true;
        blockScripts[0].delayTimer = 1f;
        blockScripts[4].moving = true;
        blockScripts[4].delayTimer = 1f;
    }

    private void OnCrowCommand(List<string> commands)
    {
        if (commands[0] == "OpenBlocade")
            OpenBlocade();
    }

    private void OnEnable()
    {
        BirdScript.CrowCommand += OnCrowCommand;
    }

    private void OnDisable()
    {
        BirdScript.CrowCommand -= OnCrowCommand;
    }
}
