using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffToAddByCrow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string commandToSpawn;

    [SerializeField]
    private GameObject objectToSpawn;



    private void OnCrowCommand(List<string> commands)
    {
        if (commands[0] == commandToSpawn)
        {
            objectToSpawn.SetActive(true);
        }

    }

    #region Event Sub/Unsub
    /// <summary>
    /// subs and unsubs from event when object is enabled and disabled.
    /// </summary>
    private void OnEnable()
    {
        BirdScript.CrowCommand+=OnCrowCommand;
    }

    private void OnDisable()
    {
        BirdScript.CrowCommand -= OnCrowCommand;
    }
    #endregion
    
}
