using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandMoveBlock : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;

    [SerializeField]
    private bool up = false;

    [SerializeField]
    private float maxHeight = 37;

    [SerializeField]
    private float minHeight = 0;

    [SerializeField]
    private string IDForCommand;

    void FixedUpdate()
    {
        if (up && transform.position.y < maxHeight)
        {
            transform.SetPositionAndRotation(transform.position + new Vector3(0, moveSpeed, 0), transform.rotation);
        }
        else if (!up && transform.position.y > minHeight)
        {
            transform.SetPositionAndRotation(transform.position + new Vector3(0, -moveSpeed, 0), transform.rotation);
        }
    }

    


    private void OnCrowCommand(List<string> commands)
    {
        if (commands[0] == IDForCommand)
        {
            if (commands[1] == "Up" || commands[1] == "up")
                up = true;
            else if (commands[1] == "Down" || commands[1] == "down")
                up = false;
        }
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
