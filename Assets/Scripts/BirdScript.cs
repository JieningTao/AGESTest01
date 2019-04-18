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
    private float eventStartTime;
    private List<string> Gibberish = new List<string>();

    void Awake()
    {
        scriptLoaded = SceneManager.GetActiveScene().name;
        setupGibberish();
        WorkPanels.gameObject.SetActive(false);
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
        }
    }

    void FacilityUpdate()
    {

        if (Time.fixedTime == 1)
        {
            WorkPanels.gameObject.SetActive(true);
            SaidToPlayer.Invoke("That looks okay.");
        } 

        if (Time.fixedTime == 3)
            SaidToPlayer.Invoke("At least it doesn't look that bad.");

        if (Time.fixedTime == 6.5)
            SaidToPlayer.Invoke("I think.");

        if (Time.fixedTime == 10)
            SaidToPlayer.Invoke("And they say it was stupid complicated.");

        if (Time.fixedTime == 20)
            SaidToPlayer.Invoke("That should be just about all done.");

        if (Time.fixedTime == 22)
            SaidToPlayer.Invoke("Crap, forgot about the droids.");

    }

    void PondUpdate()
    {
        if (Time.fixedTime == 1)
            SaidToPlayer.Invoke("Hi again.");

        if (Time.fixedTime == 3)
            SaidToPlayer.Invoke("Welcome to the pond.");

        if (Time.fixedTime == 6.5)
            SaidToPlayer.Invoke("This is where I come to think.");

        if (Time.fixedTime == 10)
            SaidToPlayer.Invoke("I always find myself a bit more realaxed in a natural setting.");

        if (Time.fixedTime == 14)
            SaidToPlayer.Invoke("Even if it is simulated.");

        if (Time.fixedTime == 16)
            SaidToPlayer.Invoke("Like listening to rainstorms while you sleep.");

        if (Time.fixedTime == 20)
            SaidToPlayer.Invoke("Except I hate rain.");

        if (Time.fixedTime == 22)
            SaidToPlayer.Invoke("Because of the whole get wet deal.");

        if (Time.fixedTime == 25)
        {
            WorkPanels.gameObject.SetActive(true);
            SaidToPlayer.Invoke("Look around for a bit, I have some backstage work to get done here.");
        }
            
        if (Time.fixedTime == 26)
        {
            eventStartTime = Time.fixedTime;
            scriptLoaded = "Mumble";
        }
            
    }

    void OfficeUpdate()
    {

    }

    void LightingUpdate()
    {
        if (Time.fixedTime == 1)
            SaidToPlayer.Invoke("Hi, and welcome to...");

        if (Time.fixedTime == 3)
            SaidToPlayer.Invoke("Where'd you go?");

        if (Time.fixedTime == 6.5)
            SaidToPlayer.Invoke("Oh crap.");

        if (Time.fixedTime == 10)
            SaidToPlayer.Invoke("I think I just lost you.");

        if (Time.fixedTime == 14)
            SaidToPlayer.Invoke("Don't panic, just follow my voice.");

        if (Time.fixedTime == 16)
            SaidToPlayer.Invoke("I knew the random spawn location thing was a pain in the tail.");

        if (Time.fixedTime == 20)
            SaidToPlayer.Invoke("It's ok, i'm sure you can find me.");

        if (Time.fixedTime == 22)
            SaidToPlayer.Invoke("I hope.");
    }

    private void PlayerProceededTo(string pointMessage)
    {
        eventStartTime = Time.fixedTime;
        if (pointMessage == "Player met Crow")
            scriptLoaded = "FirstEncounter";
    }

    private void FoundCrowInLighting()
    {
        if (Time.fixedTime - eventStartTime == 0.5f)
            SaidToPlayer.Invoke("Oh there you are.");
    }

    private void FirstEncounter()
    {

        if (Time.fixedTime - eventStartTime == 1f)
        {
            SaidToPlayer.Invoke("Oh...         ");
            WorkPanels.gameObject.SetActive(false);
        }
            
        if (Time.fixedTime - eventStartTime == 4)
            SaidToPlayer.Invoke("You...");

        if (Time.fixedTime - eventStartTime == 6)
            SaidToPlayer.Invoke("Are you a player?");

        if (Time.fixedTime - eventStartTime == 8)
            SaidToPlayer.Invoke("You're not supposed to be here.");

        if (Time.fixedTime - eventStartTime == 11)
            SaidToPlayer.Invoke("The game's not done.");

        if (Time.fixedTime - eventStartTime == 13)
            SaidToPlayer.Invoke("It's not ready.");

        if (Time.fixedTime - eventStartTime == 15)
            SaidToPlayer.Invoke("How did you even get here?");

        if (Time.fixedTime - eventStartTime == 17)
            SaidToPlayer.Invoke("Can you speak?");

        if (Time.fixedTime - eventStartTime == 18.5)
            SaidToPlayer.Invoke("Try typing.");

        if (Time.fixedTime - eventStartTime == 21)
            SaidToPlayer.Invoke("Oh yeah, I didn't Implement the speech system yet.");

        if (Time.fixedTime - eventStartTime == 24)
            SaidToPlayer.Invoke("Well the game isn't finished so...");

        if (Time.fixedTime - eventStartTime == 26)
            SaidToPlayer.Invoke("I mean, I'm not gonna ask you to leave.");

        if (Time.fixedTime - eventStartTime == 28)
            SaidToPlayer.Invoke("Feel free to take a look around I guess.");

        if (Time.fixedTime - eventStartTime == 30)
            SaidToPlayer.Invoke("I tend to mumble a bit to myself a bit when i work, don't mind me.");

        //Debug.Log(Time.fixedTime - eventStartTime);
    }

    private void JibberishMumbule()
    {
        if ((Time.fixedTime - eventStartTime) % 6 == 0)
        {
            SaidToPlayer.Invoke( Gibberish[UnityEngine.Random.Range(0, Gibberish.Count - 1)]);
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
