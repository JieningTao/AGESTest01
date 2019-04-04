using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BirdScript : MonoBehaviour
{



    private string scriptLoaded;
    public static event Action<string> SaidToPlayer;
    public float eventStartTime;
    // Start is called before the first frame update


    void Awake()
    {
        scriptLoaded = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        switch (scriptLoaded)
        {
            case "The Facility":
                FacilityUpdate();
                break;
            case "Pond":
                PondUpdate();
                break;
            case "Office":
                OfficeUpdate();
                break;
            case "Lighting":
                LightingUpdate();
                break;
            case "FirstEncounter":
                FirstEncounter();
                break;
                



        }

        //Debug.Log(Time.fixedTime);
        
    }

    void FacilityUpdate()
    {
        if (Time.fixedTime == 1)
            SaidToPlayer.Invoke("That looks okay.");

        if (Time.fixedTime == 3)
            SaidToPlayer.Invoke("At least it doesn't look that bad.");

        if (Time.fixedTime == 6.5)
            SaidToPlayer.Invoke("I think.");

        if (Time.fixedTime == 10)
            SaidToPlayer.Invoke("And they say ");

    }

    void PondUpdate()
    {

    }

    void OfficeUpdate()
    {

    }

    void LightingUpdate()
    {

    }


    private void PlayerProceededTo(string pointMessage)
    {
        eventStartTime = Time.fixedTime;
        if (pointMessage == "Player met Crow")
            scriptLoaded = "FirstEncounter";
    }


    private void FirstEncounter()
    {
        if (Time.fixedTime - eventStartTime == 1)
            SaidToPlayer.Invoke("Oh...         ");

        if (Time.fixedTime - eventStartTime == 4)
            SaidToPlayer.Invoke("You...");

        if (Time.fixedTime - eventStartTime == 6)
            SaidToPlayer.Invoke("Are you a player?");

        if (Time.fixedTime - eventStartTime == 8)
            SaidToPlayer.Invoke("You're not supposed to be here.");

        Debug.Log(Time.fixedTime - eventStartTime);
    }

    #region Event Sub/Unsub
    /// <summary>
    /// subs and unsubs from event when object is enabled and disabled.
    /// </summary>
    private void OnEnable()
    {
        PlayerPointDetection.ReachedByPlayer += PlayerProceededTo;
    }

    private void OnDisable()
    {
        PlayerPointDetection.ReachedByPlayer -= PlayerProceededTo;
    }
    #endregion
}
