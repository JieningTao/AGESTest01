using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [Tooltip("A reference to the crow's work panels")]
    [SerializeField]
    private GameObject WorkPanels;

    private string scriptLoaded;
    public static event Action<string> SaidToPlayer;
    public static event Action<string,string> CrowCommand;
    private float eventStartTime;
    private List<string> Gibberish = new List<string>();
    private Collider proximityDetect;
    private bool playerClose;

    void Awake()
    {
        scriptLoaded = SceneManager.GetActiveScene().name;
        setupGibberish();
        WorkPanels.gameObject.SetActive(false);
        proximityDetect = GetComponent<Collider>();
        playerClose = false;
        eventStartTime = Time.fixedTime;
    }

    private float ScriptStarted
    {
        get { return Time.fixedTime - eventStartTime; }
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
            case "Mumble":
                JibberishMumbule();
                break;
            case "RespawnRoom2":
                RespawnRoom2();
                break;
            case "LeavingFacility":
                LeavingFacility();
                break;
            case "PreparingToLeaveFacility":
                PreparingToLeaveFacility();
                break;
            case "JibberishMumble":
                JibberishMumbule();
                break;
        }
    }

    void FacilityUpdate()
    {

        if (ScriptStarted == 1)
        {
            WorkPanels.gameObject.SetActive(true);
            SaidToPlayer.Invoke("That looks okay.");
        } 

        if (ScriptStarted == 3)
            SaidToPlayer.Invoke("At least it doesn't look that bad.");

        if (ScriptStarted == 6.5)
            SaidToPlayer.Invoke("I think.");

        if (ScriptStarted == 10)
            SaidToPlayer.Invoke("And they say it was stupid complicated.");

        if (ScriptStarted == 20)
            SaidToPlayer.Invoke("That should be just about all done.");

        if (ScriptStarted == 22)
            SaidToPlayer.Invoke("Crap, forgot about the droids.");

    }

    void PondUpdate()
    {
        if (ScriptStarted == 1)
            SaidToPlayer.Invoke("Hi again.");

        if (ScriptStarted == 3)
            SaidToPlayer.Invoke("Welcome to the pond.");

        if (ScriptStarted == 6.5)
            SaidToPlayer.Invoke("This is where I come to think.");

        if (ScriptStarted == 10)
            SaidToPlayer.Invoke("I always find myself a bit more realaxed in a natural setting.");

        if (ScriptStarted == 14)
            SaidToPlayer.Invoke("Even if it is simulated.");

        if (ScriptStarted == 16)
            SaidToPlayer.Invoke("Like listening to rainstorms while you sleep.");

        if (ScriptStarted == 20)
            SaidToPlayer.Invoke("Except I hate rain.");

        if (ScriptStarted == 22)
            SaidToPlayer.Invoke("Because of the whole get wet deal.");

        if (ScriptStarted == 25)
        {
            WorkPanels.gameObject.SetActive(true);
            SaidToPlayer.Invoke("Look around for a bit, I have some backstage work to get done here.");
        }
            
        if (ScriptStarted == 26)
        {
            eventStartTime = ScriptStarted;
            scriptLoaded = "Mumble";
        }
            
    }

    void OfficeUpdate()
    {

    }

    void LightingUpdate()
    {
        if (ScriptStarted == 1)
            SaidToPlayer.Invoke("Hi, and welcome to...");

        if (ScriptStarted == 3)
            SaidToPlayer.Invoke("Where'd you go?");

        if (ScriptStarted == 6.5)
            SaidToPlayer.Invoke("Oh crap.");

        if (ScriptStarted == 10)
            SaidToPlayer.Invoke("I think I just lost you.");

        if (ScriptStarted == 14)
            SaidToPlayer.Invoke("Don't panic, just follow my voice.");

        if (ScriptStarted == 16)
            SaidToPlayer.Invoke("I knew the random spawn location thing was a pain in the tail.");

        if (ScriptStarted == 20)
            SaidToPlayer.Invoke("It's ok, i'm sure you can find me.");

        if (ScriptStarted == 22)
            SaidToPlayer.Invoke("I hope.");

        if (ScriptStarted == 26)
        {
            eventStartTime = ScriptStarted;
            scriptLoaded = "Mumble";
        }
    }

    private void PlayerProceededTo(string pointMessage)
    {
        eventStartTime = Time.fixedTime;
        if (pointMessage == "Player met Crow")
            scriptLoaded = "FirstEncounter";

        if (pointMessage == "Player entered respawn room 2")
            scriptLoaded = "RespawnRoom2";

       
    }

    private void RespawnRoom2()
    {
        if (ScriptStarted == 0.5f)
            SaidToPlayer.Invoke("Yeah, as you can see, i don't have a lot going on in that room yet.");

        if (ScriptStarted == 3f)
            SaidToPlayer.Invoke("In the future perhaps it will have more going on.");

        if (ScriptStarted == 5f)
            SaidToPlayer.Invoke("In any case, I need to go get some stuff.");

        if (ScriptStarted == 6.5f)
            SaidToPlayer.Invoke("You're welcome to follow me if you'd like.");

        if (ScriptStarted == 8f)
            SaidToPlayer.Invoke("Come to me when you're ready.");

        if (ScriptStarted == 9f)
            scriptLoaded = "PreparingToLeaveFacility";
    }

    private void LeavingFacility()
    {
        if (playerClose)
        {
            if (ScriptStarted == 0.5f)
                SaidToPlayer.Invoke("All ready to go?");

            if (ScriptStarted == 1.5f)
                SaidToPlayer.Invoke("All ready to go?");

            if (ScriptStarted == 2.5f)
                SaidToPlayer.Invoke("I'll take that as a yes.");

            if (ScriptStarted == 4f)
                SaidToPlayer.Invoke("Leaving in 3...");

            if (ScriptStarted == 5f)
                SaidToPlayer.Invoke("2...");

            if (ScriptStarted == 6f)
                SaidToPlayer.Invoke("1...");

            if (ScriptStarted == 7f)
                SceneManager.LoadScene("Pond");
        }
        else
        {
            eventStartTime = Time.fixedTime;
            scriptLoaded = "PreparingToLeaveFacility";
        }

        
    }

    private void PreparingToLeaveFacility()
    {
        if (!playerClose)
        {
            JibberishMumbule();
        }
        else
        {
            eventStartTime = Time.fixedTime;
            scriptLoaded = "LeavingFacility";
        }
    }


    private void FoundCrowInLighting()
    {
        if (ScriptStarted == 0.5f)
            SaidToPlayer.Invoke("Oh there you are.");
    }

    private void FirstEncounter()
    {

        if (ScriptStarted == 1f)
        {
            SaidToPlayer.Invoke("Oh...         ");
            WorkPanels.gameObject.SetActive(false);
        }
            
        if (ScriptStarted == 4)
            SaidToPlayer.Invoke("You...");

        if (ScriptStarted == 6)
            SaidToPlayer.Invoke("Are you a player?");

        if (ScriptStarted == 8)
            SaidToPlayer.Invoke("You're not supposed to be here.");

        if (ScriptStarted == 11)
            SaidToPlayer.Invoke("The game's not done.");

        if (ScriptStarted == 13)
            SaidToPlayer.Invoke("It's not ready.");

        if (ScriptStarted == 15)
            SaidToPlayer.Invoke("How did you even get here?");

        if (ScriptStarted == 17)
            SaidToPlayer.Invoke("Can you speak?");

        if (ScriptStarted == 18.5)
            SaidToPlayer.Invoke("Try typing.");

        if (ScriptStarted == 21)
            SaidToPlayer.Invoke("Oh yeah, I didn't Implement the speech system yet.");

        if (ScriptStarted == 24)
            SaidToPlayer.Invoke("Well the game isn't finished so...");

        if (ScriptStarted == 26)
            SaidToPlayer.Invoke("I mean, I'm not gonna ask you to leave.");

        if (ScriptStarted == 28)
            SaidToPlayer.Invoke("Feel free to take a look around I guess.");

        if (ScriptStarted == 30)
            SaidToPlayer.Invoke("I tend to mumble a bit to myself a bit when i work, don't mind me.");

        if (ScriptStarted == 32)
        {
            WorkPanels.gameObject.SetActive(true);
            scriptLoaded = "JibberishMumble";
        }
        //Debug.Log(ScriptStarted);
    }

    private void JibberishMumbule()
    {
        if ((ScriptStarted) % 6 == 0)
        {
            SaidToPlayer.Invoke( Gibberish[UnityEngine.Random.Range(0, Gibberish.Count - 1)]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerClose = false;
        }
    }

    private void setupGibberish()
    {
        Gibberish.Add("Hummmm......");
        Gibberish.Add("Is that a?");
        Gibberish.Add("Well, I guess that's the best I can do for now.");
        Gibberish.Add("Oh shi-");
        Gibberish.Add("And set that to 5.");
        Gibberish.Add("I thought I removed that.");
        Gibberish.Add("Was this the build with the giant spiders?");
        Gibberish.Add("I really need to implement the player breathing mechanic");
        Gibberish.Add("You doing alright? hows does things look? oh yeah, I didn't inplment a seech system, nevermind.");
        Gibberish.Add("That looks okay.");

        if (SceneManager.GetActiveScene().name == "The Facility")
        {
            Gibberish.Add("Should the walls be white? or more grayish?");
            Gibberish.Add("That antenna is really out of place.");
            Gibberish.Add("I need to talk to that art team about that");
        }

        if (SceneManager.GetActiveScene().name == "Pond")
        {
            Gibberish.Add("I might need a bigger pond.");
            Gibberish.Add("That reminds me, do you know how to swim?");
            Gibberish.Add("I spend quite some time putting all the grass and stones in place.");
        }

        if (SceneManager.GetActiveScene().name == "Office")
        {
            Gibberish.Add("Who the hell stuck gum to the bottom of this table?");

        }

        if (SceneManager.GetActiveScene().name == "Lighting")
        {
            Gibberish.Add("Marco");
            Gibberish.Add("Marco?");
        }
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
