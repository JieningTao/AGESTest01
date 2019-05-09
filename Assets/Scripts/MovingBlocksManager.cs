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
    private GameObject crow;

    [SerializeField]
    private float maxHeight = 6;

    [SerializeField] 
    private float minHeight = 0;

    private GameObject[,] Blocks;
    private BlockMove[,] BlockScripts;
    private float timeExecuted;
    public bool pause;
    private int timer;
    private GameObject player;
    private Vector3 ParentPosition;
    // Start is called before the first frame update

    private void Awake()
    {
        Blocks = new GameObject[width, depth];
        BlockScripts = new BlockMove[width, depth];
        CreateBlocks();
        SetAllBlocksRise(true);
        ParentPosition = GetComponentInParent<Transform>().position;
    }

    private void CreateBlocks()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < depth; j++)
            {
                GameObject BlockClone = (GameObject)Instantiate(block, (new Vector3(1 + (i * 2), 0, 1 + (j * 2)) + transform.position), Quaternion.identity);
                BlockMove CloneScript = BlockClone.GetComponent<BlockMove>();

                CloneScript.speed = speed;
                CloneScript.maxHeight = transform.position.y + maxHeight;
                CloneScript.minHeight = transform.position.y + minHeight;
                BlockClone.transform.parent = transform;
                CloneScript.coorInGrid = i + "," + j;
                Blocks[i,j] = BlockClone;
                BlockScripts[i, j] = CloneScript;
            }
        }
    }

    private void SetAllBlocksBounce(bool bounceToSet)
    {
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                BlockScripts[i,j].bounce = bounceToSet;
            }
        }
    }

    private void SetAllBlocksRise(bool riseToSet)
    {
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                BlockScripts[i,j].rising = riseToSet;
            }
        }
    }

    private void SetAllBlocksMove(bool moveToSet,float delay)
    {
        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                BlockScripts[i, j].moving = moveToSet;
                BlockScripts[i, j].delayTimer = delay;
            }
        }
    }

    void FixedUpdate()
    {
        /*
        if (Time.fixedTime == 1)
        {
            RaisePath(9, 0, 18, 10);
        }
        */

        //Debug.Log( GetClosestBlock(player.transform.position));

        //Ripple(9, 10);

        /*
        if (player != null)
            MoveIfExist((int)ClosestBlockCoor.x,(int)ClosestBlockCoor.y, true);
        */


    }

    public void ParentToClosestBlock(GameObject child)
    {
        Vector2 Closest = GetClosestBlock(child.transform.position);
        child.transform.parent = Blocks[(int)Closest.x, (int)Closest.y].transform;
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
                    MoveIfExist(i, columnRow, true, delay+(i - start) * 0.3f,true);
                }
                delay = (finish - start) * 0.3f;
                return delay;
            }
            if (start > finish)
            {
                for (int i = start; i > finish; i--)
                {
                    MoveIfExist(i, columnRow, true, delay + (i - start) * 0.3f,true);
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
                    MoveIfExist(columnRow, i, true, delay + (i - start) * 0.3f,true);
                }
                delay = (finish - start) * 0.3f;
                return delay;
            }
            if (start > finish)
            {
                for (int i = start; i > finish; i--)
                {
                    MoveIfExist(columnRow, i, true, delay + (i - start) * 0.3f,true);
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
    

    private void Ripple(int x,int y,float delay)
    {
        SetAllBlocksBounce(true);
        
        MoveIfExist(x, y, true);

        for (int i = 0; i < width + depth; i++)
        {
            MoveIfExist(x + i, y, true, delay*i);
            MoveIfExist(x - i, y, true, delay*i);
            MoveIfExist(x, y+i, true, delay * i);
            MoveIfExist(x, y-i, true, delay * i);
            for (int j = 0; j < i; j++)
            {
                if (j > 0)
                {
                    MoveIfExist(x + j, y + i - j, true, delay * i);
                    MoveIfExist(x + j, y - i + j, true, delay * i);
                    MoveIfExist(x - j, y + i - j, true, delay * i);
                    MoveIfExist(x - j, y - i + j, true, delay * i);
                }
            }


        }








        /*
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
        */

    }

    private void MoveIfExist(int x,int y,bool moveOrNot)
    {
        if (x >= 0 && x < width && y >= 0 && y < depth && BlockScripts[x, y].moving != moveOrNot)
        {
            BlockScripts[x, y].moving = moveOrNot;
        }
            
    }

    private void MoveIfExist(int x, int y, bool moveOrNot,float delay)
    {
        if (x >= 0 && x < width && y >= 0 && y < depth&& BlockScripts[x,y].moving!=moveOrNot)
        {
            BlockScripts[x,y].moving = moveOrNot;
            BlockScripts[x,y].delayTimer = delay;
        }
            
    }

    private void MoveIfExist(int x, int y, bool moveOrNot, float delay, bool rise)
    {
        if (x >= 0 && x < width && y >= 0 && y < depth && BlockScripts[x, y].moving != moveOrNot)
        {
            BlockScripts[x, y].moving = moveOrNot;
            BlockScripts[x, y].delayTimer = delay;
            BlockScripts[x, y].rising = rise;
        }

    }


    private Vector2 GetClosestBlock(Vector3 point)
    {
        point = point - transform.position;
        return new Vector2((int)(point.x / 2),(int)(point.z/2));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
        }
        
    }

    private void OnCrowCommand(List<string> commands)
    {
        if (commands[0] == "BlocksParentCrow")
            ParentToClosestBlock(crow);
        else if (commands[0] == "BlocksStartRipple")
            Ripple(int.Parse(commands[1]), int.Parse(commands[2]), float.Parse(commands[3]));
        else if (commands[0] == "BlocksAllStop")
            SetAllBlocksMove(false,0);
        else if (commands[0] == "BlocksRippleCrow")
        {
            Vector2 Closest = GetClosestBlock(crow.transform.position);
            Ripple((int)Closest.x, (int)Closest.y, float.Parse(commands[1]));
        }
        else if (commands[0] == "BlocksAllBounceFalse")
            SetAllBlocksBounce(false);
        else if (commands[0] == "BlocksPathFromPlayer")
        {
            Vector2 Closest = GetClosestBlock(player.transform.position);
            RaisePath((int)Closest.x, (int)Closest.y, int.Parse(commands[1]), int.Parse(commands[2]));
        }
        else if (commands[0] == "BlocksPathToPlayer")
        {
            Vector2 Closest = GetClosestBlock(player.transform.position);
            RaisePath(int.Parse(commands[1]), int.Parse(commands[2]), (int)Closest.x, (int)Closest.y);
        }
        else if (commands[0] == "BlocksPlayerPlatform")
        {
            Vector2 Closest = GetClosestBlock(player.transform.position);

            MoveIfExist((int)Closest.x, (int)Closest.y, true,0,true);
            MoveIfExist((int)Closest.x + 1, (int)Closest.y, true, 0, true);
            MoveIfExist((int)Closest.x - 1, (int)Closest.y, true, 0, true);
            MoveIfExist((int)Closest.x, (int)Closest.y + 1, true, 0, true);
            MoveIfExist((int)Closest.x, (int)Closest.y - 1, true, 0, true);
            MoveIfExist((int)Closest.x + 1, (int)Closest.y - 1, true, 0, true);
            MoveIfExist((int)Closest.x - 1, (int)Closest.y + 1, true, 0, true);
            MoveIfExist((int)Closest.x + 1, (int)Closest.y + 1, true, 0, true);
            MoveIfExist((int)Closest.x - 1, (int)Closest.y - 1, true, 0, true);
        }
        else if (commands[0] == "BlocksPlayer")
        {
            Vector2 Closest = GetClosestBlock(player.transform.position);
            if (commands.Contains("Up") || commands.Contains("up"))
                BlockScripts[(int)Closest.x, (int)Closest.y].rising = true;
            if (commands.Contains("down") || commands.Contains("Down"))
                BlockScripts[(int)Closest.x, (int)Closest.y].rising = false;
            if (commands.Contains("move") || commands.Contains("Move"))
                BlockScripts[(int)Closest.x, (int)Closest.y].moving = true;
            if (commands.Contains("stop") || commands.Contains("Stop"))
                BlockScripts[(int)Closest.x, (int)Closest.y].moving = false;
            if (commands.Contains("bounce") || commands.Contains("Bounce"))
                BlockScripts[(int)Closest.x, (int)Closest.y].moving = true;
            if (commands.Contains("nobounce") || commands.Contains("NoBounce"))
                BlockScripts[(int)Closest.x, (int)Closest.y].moving = false;

        }
        else if (commands[0] == "BlocksCrow")
        {
            Vector2 Closest = GetClosestBlock(crow.transform.position);
            if (commands.Contains("Up") || commands.Contains("up"))
                BlockScripts[(int)Closest.x, (int)Closest.y].rising = true;
            if (commands.Contains("down") || commands.Contains("Down"))
                BlockScripts[(int)Closest.x, (int)Closest.y].rising = true;
            if (commands.Contains("move") || commands.Contains("Move"))
                BlockScripts[(int)Closest.x, (int)Closest.y].moving = true;
            if (commands.Contains("stop") || commands.Contains("Stop"))
                BlockScripts[(int)Closest.x, (int)Closest.y].moving = true;
        }
        else if (commands[0] == "BlocksResetAll")
        {
            SetAllBlocksRise(false);
            SetAllBlocksMove(true,0);
            SetAllBlocksBounce(false);
        }
             

        /*
        if (commands[0] == "BlocksRaisePath")
            RaisePath(int.Parse(commands[1]), int.Parse(commands[2], int.Parse(commands[3]), int.Parse(commands[4]);
            */
    }


    #region Event Sub/Unsub
    /// <summary>
    /// subs and unsubs from event when object is enabled and disabled.
    /// </summary>
    private void OnEnable()
    {
        BirdScript.CrowCommand += OnCrowCommand;
    }

    private void OnDisable()
    {
        BirdScript.CrowCommand -= OnCrowCommand;
    }
    #endregion


}
