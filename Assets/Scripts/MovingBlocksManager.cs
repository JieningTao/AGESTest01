using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlocksManager : MonoBehaviour
{
    [SerializeField]
    GameObject Block;


    private GameObject[,] Blocks = new GameObject[19,20];


    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        CreateBlocks();


        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 20; j++)
            {

                Blocks[i, j].GetComponent<BlockMove>().Bounce = true;


            }
        }

    }


    void CreateBlocks()
    {
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                GameObject BlockClone = (GameObject)Instantiate(Block, new Vector3(32 + (i * 2), 0, 101 + (j * 2)), Quaternion.identity);
                Blocks[i,j] = BlockClone;

            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Wave();
        timer++;
    }


    private void Wave()
    {
        




        if (timer % 20 == 0)
        {
            for (int i = 0; i < 20; i++)
            {
                Blocks[timer/20,i].GetComponent<BlockMove>().Moving = true;
            }
        }

    }
}
