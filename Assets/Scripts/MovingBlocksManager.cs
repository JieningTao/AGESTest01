using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlocksManager : MonoBehaviour
{
    [SerializeField]
    GameObject block;
    [SerializeField]
    private int width=19;
    [SerializeField]
    private int depth = 20;

    [SerializeField]
    private float maxHeight = 6;
    [SerializeField]
    private float minHeight = 0;


    private GameObject[,] Blocks;
    private float timeExecuted;

    private int timer;
    // Start is called before the first frame update


    private void Awake()
    {
     Blocks = new GameObject[width, depth];
     CreateBlocks();
    }
    void Start()
    {
        
        //SetAllBlocksBounce(true);
        
    }

    private void CreateBlocks()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < depth; j++)
            {
                GameObject BlockClone = (GameObject)Instantiate(block, (new Vector3(1 + (i * 2), 0, 1 + (j * 2)) + transform.position), Quaternion.identity);
                BlockClone.GetComponent<BlockMove>().maxHeight = transform.position.y + maxHeight;
                BlockClone.GetComponent<BlockMove>().minHeight = transform.position.y + minHeight;
                BlockClone.transform.parent = transform;
                Blocks[i,j] = BlockClone;


            }
        }
    }

    private void SetAllBlocksBounce(bool bounceToSet)
    {
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                Blocks[i, j].GetComponent<BlockMove>().bounce = bounceToSet;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {



        Ripple(5,10);

        timer++;
    }

    private void Wave()
    {

        //this is a proof of convept test for the moveable blocks.
        if (timer % 20 == 0&& timer<width*20)
        {
            for (int i = 0; i < depth; i++)
            {
                MoveIfExist(timer / 20, i,true);
            }
        }
    }

    private void Ripple(int x,int y)
    {
        if (timer % 20 == 0)
        {
            for(int i = 0; i<(timer / 20)+1;i++)
            {
                MoveIfExist(x, y, true);

                for (int j = 0; j < i; j++)
                {
                    MoveIfExist(x + i - j, y + j, true);
                    MoveIfExist(x - i + j, y + j, true);
                    MoveIfExist(x + i - j, y - j, true);
                    MoveIfExist(x - i + j, y - j, true);
                }



                //MoveIfExist(x + i, y, true);
                MoveIfExist(x, y + i, true);
                //MoveIfExist(x - i, y, true);
                MoveIfExist(x, y - i, true);








                /*
                if (timer / 20 > 1)
                {
                    for (int j = 0; j < i; j++)
                    {
                        MoveIfExist(x + i, y + j, true);
                        MoveIfExist(x - i, y + j, true);
                        MoveIfExist(x - i, y - j, true);
                        MoveIfExist(x + i, y - j, true);

                        MoveIfExist(x + j, y + i, true);
                        MoveIfExist(x - j, y + i, true);
                        MoveIfExist(x - j, y - i, true);
                        MoveIfExist(x + j, y - i, true);
                    }

                    MoveIfExist(x + i, y + i,true);
                    MoveIfExist(x - i, y + i, true);
                    MoveIfExist(x - i, y - i, true);
                    MoveIfExist(x + i, y - i, true);
                }
                */
            }





            /*

            switch (timer/20)
            {
                case 0:
                    MoveIfExist(x, y, true);
                    break;
                default:
                    MoveIfExist(x + timer / 20, y + timer / 20, true);
                    MoveIfExist(x + timer / 20, y - timer / 20, true);
                    MoveIfExist(x - timer / 20, y - timer / 20, true);
                    MoveIfExist(x - timer / 20, y + timer / 20, true);
                    break;
            }
            */
        }





    }

    private void MoveIfExist(int x,int y,bool moveOrNot)
    {
        if (x >= 0 && x < width&&y>=0&&y<depth)
            Blocks[x, y].GetComponent<BlockMove>().moving = moveOrNot;
    }


}
