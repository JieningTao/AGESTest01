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
    private float speed = 0.06f;

    [SerializeField]
    private float maxHeight = 6;

    [SerializeField] 
    private float minHeight = 0;

    private GameObject[,] Blocks;
    private float timeExecuted;
    public bool pause;
    private int timer;
    // Start is called before the first frame update

    private void Awake()
    {
        Blocks = new GameObject[width, depth];
        CreateBlocks();
        SetAllBlocksRise(true);
    }

    private void CreateBlocks()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < depth; j++)
            {
                GameObject BlockClone = (GameObject)Instantiate(block, (new Vector3(1 + (i * 2), 0, 1 + (j * 2)) + transform.position), Quaternion.identity);
                BlockMove cloneScript = BlockClone.GetComponent<BlockMove>();

                cloneScript.speed = speed;
                cloneScript.maxHeight = transform.position.y + maxHeight;
                cloneScript.minHeight = transform.position.y + minHeight;
                BlockClone.transform.parent = transform;
                cloneScript.coorInGrid = i + "," + j;
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

    private void SetAllBlocksRise(bool riseToSet)
    {
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                Blocks[i, j].GetComponent<BlockMove>().rising = riseToSet;
            }
        }
    }

    private void SetAllBlocksMove(bool moveToSet)
    {
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                Blocks[i, j].GetComponent<BlockMove>().moving = moveToSet;
            }
        }
    }

    void FixedUpdate()
    {
        //contains a lot of stuff commented out because is currently being worked on and constantly changing
        if (Time.fixedTime == 1)
        {
            RaisePath(9, 0, 18, 10);
            /*
            Blocks[1, 0].GetComponent<BlockMove>().delayTimer = 0;
            Blocks[1, 0].GetComponent<BlockMove>().moving = true;

            Blocks[2, 0].GetComponent<BlockMove>().delayTimer = 0.1f;
            Blocks[2, 0].GetComponent<BlockMove>().moving = true;

            Blocks[3, 0].GetComponent<BlockMove>().delayTimer = 0.2f;
            Blocks[3, 0].GetComponent<BlockMove>().moving = true;

            Blocks[4, 0].GetComponent<BlockMove>().delayTimer = 0.3f;
            Blocks[4, 0].GetComponent<BlockMove>().moving = true;
            */
            //Ripple(0,0);
        }
        

        /*
        if (!pause)
        {
            Ripple(9, 15);
            timer++;
            if (timer == 50)
            {
                pause = true;
                SetAllBlocksMove(false);
            }
                
        }
        */

    }

    private void Wave()
    {
        //old version, no longer works with delayed block movement
        //this is a proof of convept test for the moveable blocks.
        if (timer % 20 == 0&& timer<width*20)
        {
            for (int i = 0; i < depth; i++)
            {
                MoveIfExist(timer / 20, i,true);
            }
        }
    }

    private void RaisePath(int startX,int startY,int DestX,int DestY)
    {
        //raising line Horizontal first 
        //RaiseLine(false,DestX,startY,DestY,RaiseLine(true, startY, startX, DestX, 0));
        //raising line Vertical first
        RaiseLine(true, DestY, startX, DestX, RaiseLine(false, startX, startY, DestY, 0));
    }

    private float RaiseLine(bool horizontal, int columnRow,  int start , int finish, float delay)
    {
        if (horizontal)
        {
            if (start < finish)
            {
                for (int i = start; i < finish; i++)
                {
                    MoveIfExist(i, columnRow, true, delay+(i - start) * 0.3f);
                }
                delay = (finish - start) * 0.3f;
                return delay;
            }
            if (start > finish)
            {
                for (int i = start; i > finish; i--)
                {
                    MoveIfExist(i, columnRow, true, delay + (i - start) * 0.3f);
                }
                delay = (finish - start) * 0.3f;
                return delay;
            }
            else
            {
                return delay;
            }

        }
        else
        {

            if (start < finish)
            {
                for (int i = start; i < finish; i++)
                {
                    MoveIfExist(columnRow, i, true, delay + (i - start) * 0.3f);
                }
                delay = (finish - start) * 0.3f;
                return delay;
            }
            if (start > finish)
            {
                for (int i = start; i > finish; i--)
                {
                    MoveIfExist(columnRow, i, true, delay + (i - start) * 0.3f);
                }
                delay = (finish - start) * 0.3f;
                return delay;
            }
            else
            {
                return delay;
            }
        }
    }
    

    private void Ripple(int x,int y)
    {
        SetAllBlocksBounce(true);
        
        MoveIfExist(x, y, true);
        for (int h = 0; h< 1000; h++)
        {
            if (h % 20 == 0)
            {

                for (int i = 0; i < (h / 20) + 1; i++)
                {

                    for (int j = 0; j < i; j++)
                    {

                        MoveIfExist(x + i - j, y + j, true, h/ 20);
                        MoveIfExist(x - i + j, y + j, true, h / 20);
                        MoveIfExist(x + i - j, y - j, true, h / 20);
                        MoveIfExist(x - i + j, y - j, true, h / 20);
                    }

                    //MoveIfExist(x + i, y, true);
                    MoveIfExist(x, y + i, true, h / 20);
                    //MoveIfExist(x - i, y, true);
                    MoveIfExist(x, y - i, true, h / 20);

                }
            }
        }

    }

    private void MoveIfExist(int x,int y,bool moveOrNot)
    {
        if (x >= 0 && x < width&&y>=0&&y<depth && Blocks[x, y].GetComponent<BlockMove>().moving != moveOrNot)
            Blocks[x, y].GetComponent<BlockMove>().moving = moveOrNot;
    }

    private void MoveIfExist(int x, int y, bool moveOrNot,float delay)
    {
        if (x >= 0 && x < width && y >= 0 && y < depth&& Blocks[x, y].GetComponent<BlockMove>().moving!=moveOrNot)
        {
            Blocks[x, y].GetComponent<BlockMove>().moving = moveOrNot;
            Blocks[x, y].GetComponent<BlockMove>().delayTimer = delay;
        }
            
    }

}
