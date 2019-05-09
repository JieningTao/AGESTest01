using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRoomBlocksManager : MonoBehaviour
{
    private BlockMove[] darkRoomBlocks;

    void Start()
    {
        darkRoomBlocks = GetComponentsInChildren<BlockMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        InitiateMaze();
    }

    private void InitiateMaze()
    {
        foreach (BlockMove BM in darkRoomBlocks)
        {
            BM.moving = true;
            BM.rising = true;
            BM.delayTimer = Random.Range(0f, 2f);
        }
    }
}
