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

    private string sceneLoaded;
    public static event Action<string> SaidToPlayer;
    public static event Action<string,string> CrowCommand;
    private float eventStartTime;
    private List<string> Gibberish = new List<string>();
    private Collider proximityDetect;
    private bool playerClose;
    private bool readyToLeaveScene;

    void Awake()
    {
        sceneLoaded = SceneManager.GetActiveScene().name;
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

    private void Start()
    {
        readyToLeaveScene = false;
        if (sceneLoaded == "The Facility")
            StartCoroutine(FacilityIntro());
        if (sceneLoaded == "Pond")
            StartCoroutine(PondIntro());
        if (sceneLoaded == "Lighting")
            StartCoroutine(LightingIntro());
        if (sceneLoaded == "Office")
            StartCoroutine(OfficeIntro());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        switch (sceneLoaded)
        {
            case "The Facility":
                FacilityIntro();
                break;
            case "Pond":
                PondIntro();
                break;
            case "Office":
                OfficeUpdate();
                break;
            case "Lighting":
                LightingIntro();
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
        */
    }

    /*
    void FacilityIntro()
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
    *///
    private IEnumerator FacilityIntro()
    {
            WorkPanels.gameObject.SetActive(true);
            SaidToPlayer.Invoke("That looks okay.");
        yield return new WaitForSeconds(3);
            SaidToPlayer.Invoke("At least it doesn't look that bad.");
        yield return new WaitForSeconds(4);
            SaidToPlayer.Invoke("I think.");
        yield return new WaitForSeconds(4);
            SaidToPlayer.Invoke("And they say it was stupid complicated.");
        yield return new WaitForSeconds(10);
            SaidToPlayer.Invoke("That should be just about all done.");
        yield return new WaitForSeconds(10);
            SaidToPlayer.Invoke("Crap, forgot about the droids.");

    }

    /*
    void PondIntro()
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
            sceneLoaded = "Mumble";
        }
            
    }
    */

    private IEnumerator PondIntro()
    {
            SaidToPlayer.Invoke("Hi again.");
        yield return new WaitForSeconds(2);
            SaidToPlayer.Invoke("Welcome to the pond.");
        yield return new WaitForSeconds(4);
            SaidToPlayer.Invoke("This is where I come to think.");
        yield return new WaitForSeconds(4);
            SaidToPlayer.Invoke("I always find myself a bit more realaxed in a natural setting.");
        yield return new WaitForSeconds(4);
            SaidToPlayer.Invoke("Even if it is simulated.");
        yield return new WaitForSeconds(2);
            SaidToPlayer.Invoke("Like listening to rainstorms while you sleep.");
        yield return new WaitForSeconds(4);
            SaidToPlayer.Invoke("Except I hate rain.");
        yield return new WaitForSeconds(2);
            SaidToPlayer.Invoke("Because of the whole get wet deal.");
        yield return new WaitForSeconds(3);
            WorkPanels.gameObject.SetActive(true);
            SaidToPlayer.Invoke("Look around for a bit, I have some backstage work to get done here.");
        yield return new WaitForSeconds(4);
        StartCoroutine(JibberishMumbule());

    }

    private IEnumerator SeesBomb()
    {
        WorkPanels.gameObject.SetActive(false);
        SaidToPlayer.Invoke("Don't go near that!");
        yield return new WaitForSeconds(2);
        SaidToPlayer.Invoke("It's a demo charge made for an astroid mining game.");
        yield return new WaitForSeconds(3);
        SaidToPlayer.Invoke("I'm still working on it.");
        yield return new WaitForSeconds(2.5f);
        SaidToPlayer.Invoke("It's also armed so...");
        yield return new WaitForSeconds(2);
        SaidToPlayer.Invoke("Don't touch it.");
        WorkPanels.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SaidToPlayer.Invoke("I would much rather not reimport the pond.");
        yield return new WaitForSeconds(4);
        StartCoroutine(JibberishMumbule());

        yield return new WaitForSeconds(30);
        PlayerProceededTo("ReadyToLeavePond");

    }

    private IEnumerator ReadyToLeavePond()
    {
        SaidToPlayer.Invoke("That's it, I got what I need.");
        yield return new WaitForSeconds(3);
        WorkPanels.gameObject.SetActive(false);
        SaidToPlayer.Invoke("How do you like the pond?");
        yield return new WaitForSeconds(3);
        SaidToPlayer.Invoke("I know nature isn't for everyone.");
        yield return new WaitForSeconds(2);
        SaidToPlayer.Invoke("But it is for me, oddly enough.");
        yield return new WaitForSeconds(2.5f);
        SaidToPlayer.Invoke("This became my thinking space ages ago.");
        yield return new WaitForSeconds(3);
        SaidToPlayer.Invoke("This scene followed me through many games.");
        yield return new WaitForSeconds(3);
        SaidToPlayer.Invoke("I would just bring it along to waht ever game I was working on.");
        yield return new WaitForSeconds(4f);
        SaidToPlayer.Invoke("Just to think.");
        yield return new WaitForSeconds(2);
        SaidToPlayer.Invoke("Like when I don't have ideas for new levels.");
        yield return new WaitForSeconds(3);
        SaidToPlayer.Invoke("Or I need a break from all the work.");
        yield return new WaitForSeconds(2.5f);
        SaidToPlayer.Invoke("Alright, enough about me, let's go to the office.");
        yield return new WaitForSeconds(3);
        SaidToPlayer.Invoke("Not that I have a work office");
        yield return new WaitForSeconds(3);
        SaidToPlayer.Invoke("It's some where I use to contact my friends and collegues.");
        yield return new WaitForSeconds(3.5f);
        SaidToPlayer.Invoke("Come to me when you're ready.");
        readyToLeaveScene = true;
        yield return new WaitForSeconds(4);
        StartCoroutine(JibberishMumbule());
    }

    private IEnumerator OfficeIntro()
    {
        yield return new WaitForSeconds(3);
    }
    /*
    void LightingIntro()
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
            sceneLoaded = "Mumble";
        }
    }*/
    private IEnumerator LightingIntro()
    {
            SaidToPlayer.Invoke("Hi, and welcome to...");
        yield return new WaitForSeconds(3);
            SaidToPlayer.Invoke("Where'd you go?");
        yield return new WaitForSeconds(3.5f);
            SaidToPlayer.Invoke("Oh crap.");
        yield return new WaitForSeconds(4);
            SaidToPlayer.Invoke("I think I just lost you.");
        yield return new WaitForSeconds(4);
            SaidToPlayer.Invoke("Don't panic, just follow my voice.");
        yield return new WaitForSeconds(2);
            SaidToPlayer.Invoke("I knew the random spawn location thing was a pain in the tail.");
        yield return new WaitForSeconds(4);
            SaidToPlayer.Invoke("It's ok, i'm sure you can find me.");
        yield return new WaitForSeconds(2);
            SaidToPlayer.Invoke("I hope.");
        yield return new WaitForSeconds(4);
            eventStartTime = ScriptStarted;
    }


    private void PlayerProceededTo(string pointMessage)
    {
        //eventStartTime = Time.fixedTime;
        StopAllCoroutines();

        if (pointMessage == "Player met Crow")
            StartCoroutine(FirstEncounter());


        if (pointMessage == "Player entered respawn room 2")
            StartCoroutine(RespawnRoom2());

        if (pointMessage == "Player sees bomb")
            StartCoroutine(SeesBomb());

        if (pointMessage == "ReadyToLeavePond")
            StartCoroutine(ReadyToLeavePond());

    }

    /*
    private void RespawnRoom2()
    {
        if (ScriptStarted == 0.5f)
            SaidToPlayer.Invoke("Yeah, as you can see, I don't have a lot going on in that room yet.");

        if (ScriptStarted == 3f)
            SaidToPlayer.Invoke("In the future perhaps it will have more going on.");

        if (ScriptStarted == 5f)
            SaidToPlayer.Invoke("In any case, I need to go get some stuff.");

        if (ScriptStarted == 6.5f)
            SaidToPlayer.Invoke("You're welcome to follow me if you'd like.");

        if (ScriptStarted == 8f)
            SaidToPlayer.Invoke("Come to me when you're ready.");

        if (ScriptStarted == 9f)
            sceneLoaded = "PreparingToLeaveFacility";
    }
    *///Old script that didn't use coroutine, left to provide record.
    private IEnumerator RespawnRoom2()
    {
            SaidToPlayer.Invoke("Yeah, as you can see, I don't have a lot going on in that room yet.");
        yield return new WaitForSeconds(3);
            SaidToPlayer.Invoke("In the future perhaps it will have more going on.");
        yield return new WaitForSeconds(2);
            SaidToPlayer.Invoke("In any case, I need to go get some stuff.");
        yield return new WaitForSeconds(2);
            SaidToPlayer.Invoke("You're welcome to follow me if you'd like.");
        yield return new WaitForSeconds(2);
            SaidToPlayer.Invoke("Come to me when you're ready.");
        yield return new WaitForSeconds(1.5f);
        readyToLeaveScene = true;
        yield return new WaitForSeconds(3);
        StartCoroutine(JibberishMumbule());


    }

    /*
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
            sceneLoaded = "PreparingToLeaveFacility";
        }

        
    }
    */
    private IEnumerator LeavingFacility()
    {
        SaidToPlayer.Invoke("All ready to go?");
        yield return new WaitForSeconds(2f);
                SaidToPlayer.Invoke("I'll take that as a yes.");
        yield return new WaitForSeconds(2f);
                SaidToPlayer.Invoke("Leaving in 3...");
        yield return new WaitForSeconds(1f);
                SaidToPlayer.Invoke("2...");
        yield return new WaitForSeconds(1f);
                SaidToPlayer.Invoke("1...");
        yield return new WaitForSeconds(1f);
                SceneManager.LoadScene("Pond");
    }

    private IEnumerator LeavingPond()
    {
        SaidToPlayer.Invoke("good to go?");
        yield return new WaitForSeconds(1.5f);
        SaidToPlayer.Invoke("Alright");
        yield return new WaitForSeconds(1.5f);
        SaidToPlayer.Invoke("Leaving Pond in 3...");
        yield return new WaitForSeconds(1f);
        SaidToPlayer.Invoke("2...");
        yield return new WaitForSeconds(1f);
        SaidToPlayer.Invoke("1...");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Office");
    }

    private IEnumerator LeavingOffice()
    {
        //unchanged from copy of leavefacility.
        SaidToPlayer.Invoke("All ready to go?");
        yield return new WaitForSeconds(1.5f);
        SaidToPlayer.Invoke("All ready to go?");
        yield return new WaitForSeconds(1.5f);
        SaidToPlayer.Invoke("I'll take that as a yes.");
        yield return new WaitForSeconds(2f);
        SaidToPlayer.Invoke("Leaving in 3...");
        yield return new WaitForSeconds(1f);
        SaidToPlayer.Invoke("2...");
        yield return new WaitForSeconds(1f);
        SaidToPlayer.Invoke("1...");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Lighting");
    }

    private void ReadyToLeave()
    {
        if (readyToLeaveScene)
        {
            switch (sceneLoaded)
            {
                case "The Facility":
                    StartCoroutine(LeavingFacility());
                    break;
                case "Pond":
                    StartCoroutine(LeavingPond());
                    break;
                case "Office":
                    StartCoroutine(LeavingOffice());
                    break;
                case "Lighting":
                    //LightingIntro();
                    break;
            }
        }
    }

    /*
    private void PreparingToLeaveFacility()
    {
        if (!playerClose)
        {
            JibberishMumbule();
        }
        else
        {
            eventStartTime = Time.fixedTime;
            sceneLoaded = "LeavingFacility";
        }
    }
    */


    private void FoundCrowInLighting()
    {
        if (ScriptStarted == 0.5f)
            SaidToPlayer.Invoke("Oh there you are.");
    }

    /*
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
            SaidToPlayer.Invoke("I tend to mumble a bit to myself a bit when I work, don't mind me.");

        if (ScriptStarted == 32)
        {
            WorkPanels.gameObject.SetActive(true);
            sceneLoaded = "JibberishMumble";
        }
        //Debug.Log(ScriptStarted);
    }
    *///Old script that didn't use coroutine, left to provide record.
    private IEnumerator FirstEncounter()
    {
        SaidToPlayer.Invoke("Oh...         ");
        WorkPanels.gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
            SaidToPlayer.Invoke("You...");
        yield return new WaitForSeconds(2);
            SaidToPlayer.Invoke("Are you a player?");
        yield return new WaitForSeconds(2);
            SaidToPlayer.Invoke("You're not supposed to be here.");
        yield return new WaitForSeconds(3);
            SaidToPlayer.Invoke("The game's not done.");
        yield return new WaitForSeconds(2);
            SaidToPlayer.Invoke("It's not ready.");
        yield return new WaitForSeconds(2);
            SaidToPlayer.Invoke("How did you even get here?");
        yield return new WaitForSeconds(2);
            SaidToPlayer.Invoke("Can you speak?");
        yield return new WaitForSeconds(1.5f);
            SaidToPlayer.Invoke("Try typing.");
        yield return new WaitForSeconds(2.5f);
            SaidToPlayer.Invoke("Oh yeah, I didn't Implement the speech system yet.");
        yield return new WaitForSeconds(3);
            SaidToPlayer.Invoke("Well the game isn't finished so...");
        yield return new WaitForSeconds(2);
            SaidToPlayer.Invoke("I mean, I'm not gonna ask you to leave.");
        yield return new WaitForSeconds(2);
            SaidToPlayer.Invoke("Feel free to take a look around I guess.");
        yield return new WaitForSeconds(2);
            SaidToPlayer.Invoke("I tend to mumble a bit to myself a bit when I work, don't mind me.");
        yield return new WaitForSeconds(2);
            WorkPanels.gameObject.SetActive(true);
        StartCoroutine(JibberishMumbule());

    }

    /*
    private void JibberishMumbule()
    {
        if ((ScriptStarted) % 6 == 0)
        {
            SaidToPlayer.Invoke( Gibberish[UnityEngine.Random.Range(0, Gibberish.Count - 1)]);
        }
    }
    *///Old script that didn't use coroutine, left to provide record.
    private IEnumerator JibberishMumbule()
    {
        for (int i = 0; i < 5; i=i)
        {
            SaidToPlayer.Invoke(Gibberish[UnityEngine.Random.Range(0, Gibberish.Count - 1)]);
            yield return new WaitForSeconds(UnityEngine.Random.Range(5,10));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerClose = true;
            if (readyToLeaveScene)
            {
                StopAllCoroutines();
                ReadyToLeave();
            }
            else
            {
                SaidToPlayer.Invoke("I'm sorry, I have some more work to do");
            }
                
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerClose = false;
            if (readyToLeaveScene)
            {
                StopAllCoroutines();
                StartCoroutine(JibberishMumbule());
            }
                
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
