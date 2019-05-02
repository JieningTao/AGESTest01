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

    [SerializeField]
    private AudioClip defaultCaw01;
    [SerializeField]
    private AudioClip defaultCaw02;
    [SerializeField]
    private AudioClip defaultCaw03;
    [SerializeField]
    private AudioClip defaultCaw04;
    [SerializeField]
    private AudioClip defaultCaw05;
    [SerializeField]
    private AudioClip defaultCaw06;

    [SerializeField]
    private AudioClip funnyThingToPlay;





    private string sceneLoaded;
    public static event Action<string> SaidToPlayer;
    public static event Action<string,string> CrowCommand;
    private float eventStartTime;
    private List<string> Gibberish = new List<string>();
    private List<AudioClip> Caws = new List<AudioClip>();
    private Collider proximityDetect;
    private bool playerClose;
    private bool readyToLeaveScene;
    private AudioSource crowSpeaker;

    void Awake()
    {
        sceneLoaded = SceneManager.GetActiveScene().name;
        setupGibberish();
        WorkPanels.gameObject.SetActive(false);
        proximityDetect = GetComponent<Collider>();
        playerClose = false;
        eventStartTime = Time.fixedTime;
        crowSpeaker = GetComponent<AudioSource>();
        setupCaws();
    }

    private float ScriptStarted
    {
        get { return Time.fixedTime - eventStartTime; }
    }

    private void setupCaws()
    {
        Caws.Add(defaultCaw01);
        Caws.Add(defaultCaw02);
        Caws.Add(defaultCaw03);
        Caws.Add(defaultCaw04);
        Caws.Add(defaultCaw05);
        Caws.Add(defaultCaw06);
    }

    private AudioClip Caw()
    {
        return Caws[UnityEngine.Random.Range(0, Caws.Count - 1)];
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
            SayToPlayer("That looks okay.");
        } 

        if (ScriptStarted == 3)
            SayToPlayer("At least it doesn't look that bad.");

        if (ScriptStarted == 6.5)
            SayToPlayer("I think.");

        if (ScriptStarted == 10)
            SayToPlayer("And they say it was stupid complicated.");

        if (ScriptStarted == 20)
            SayToPlayer("That should be just about all done.");

        if (ScriptStarted == 22)
            SayToPlayer("Crap, forgot about the droids.");

    }
    *///
    private IEnumerator FacilityIntro()
    {
            WorkPanels.gameObject.SetActive(true);
            SayToPlayer("That looks okay.");
        yield return new WaitForSeconds(3);
            SayToPlayer("At least it doesn't look that bad.");
        yield return new WaitForSeconds(4);
            SayToPlayer("I think.");
        yield return new WaitForSeconds(4);
            SayToPlayer("And they say it was stupid complicated.");
        yield return new WaitForSeconds(10);
            SayToPlayer("That should be just about all done.");
        yield return new WaitForSeconds(10);
            SayToPlayer("Crap, forgot about the droids.");

    }

    /*
    void PondIntro()
    {
        if (ScriptStarted == 1)
            SayToPlayer("Hi again.");

        if (ScriptStarted == 3)
            SayToPlayer("Welcome to the pond.");

        if (ScriptStarted == 6.5)
            SayToPlayer("This is where I come to think.");

        if (ScriptStarted == 10)
            SayToPlayer("I always find myself a bit more realaxed in a natural setting.");

        if (ScriptStarted == 14)
            SayToPlayer("Even if it is simulated.");

        if (ScriptStarted == 16)
            SayToPlayer("Like listening to rainstorms while you sleep.");

        if (ScriptStarted == 20)
            SayToPlayer("Except I hate rain.");

        if (ScriptStarted == 22)
            SayToPlayer("Because of the whole get wet deal.");

        if (ScriptStarted == 25)
        {
            WorkPanels.gameObject.SetActive(true);
            SayToPlayer("Look around for a bit, I have some backstage work to get done here.");
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
            SayToPlayer("Hi again.");
        yield return new WaitForSeconds(2);
            SayToPlayer("Welcome to the pond.");
        yield return new WaitForSeconds(4);
            SayToPlayer("This is where I come to think.");
        yield return new WaitForSeconds(4);
            SayToPlayer("I always find myself a bit more realaxed in a natural setting.");
        yield return new WaitForSeconds(4);
            SayToPlayer("Even if it is simulated.");
        yield return new WaitForSeconds(2);
            SayToPlayer("Like listening to rainstorms while you sleep.");
        yield return new WaitForSeconds(4);
            SayToPlayer("Except I hate rain.");
        yield return new WaitForSeconds(2);
            SayToPlayer("Because of the whole get wet deal.");
        yield return new WaitForSeconds(3);
            WorkPanels.gameObject.SetActive(true);
            SayToPlayer("Look around for a bit, I have some backstage work to get done here.");
        yield return new WaitForSeconds(4);
        StartCoroutine(JibberishMumbule());

    }

    private IEnumerator SeesBomb()
    {
        WorkPanels.gameObject.SetActive(false);
        SayToPlayer("Don't go near that!");
        yield return new WaitForSeconds(2);
        SayToPlayer("It's a demo charge made for an astroid mining game.");
        yield return new WaitForSeconds(3);
        SayToPlayer("I'm still working on it.");
        yield return new WaitForSeconds(2.5f);
        SayToPlayer("It's also armed so...");
        yield return new WaitForSeconds(2);
        SayToPlayer("Don't touch it.");
        WorkPanels.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SayToPlayer("I would much rather not reimport the pond.");
        yield return new WaitForSeconds(4);
        StartCoroutine(JibberishMumbule());

        yield return new WaitForSeconds(30);
        PlayerProceededTo("ReadyToLeavePond");

    }

    private IEnumerator ReadyToLeavePond()
    {
        SayToPlayer("That's it, I got what I need.");
        yield return new WaitForSeconds(3);
        WorkPanels.gameObject.SetActive(false);
        SayToPlayer("How do you like the pond?");
        yield return new WaitForSeconds(3);
        SayToPlayer("I know nature isn't for everyone.");
        yield return new WaitForSeconds(2);
        SayToPlayer("But it is for me, oddly enough.");
        yield return new WaitForSeconds(2.5f);
        SayToPlayer("This became my thinking space ages ago.");
        yield return new WaitForSeconds(3);
        SayToPlayer("This scene followed me through many games.");
        yield return new WaitForSeconds(3);
        SayToPlayer("I would just bring it along to waht ever game I was working on.");
        yield return new WaitForSeconds(4f);
        SayToPlayer("Just to think.");
        yield return new WaitForSeconds(2);
        SayToPlayer("Like when I don't have ideas for new levels.");
        yield return new WaitForSeconds(3);
        SayToPlayer("Or I need a break from all the work.");
        yield return new WaitForSeconds(2.5f);
        SayToPlayer("Alright, enough about me, let's go to the office.");
        yield return new WaitForSeconds(3);
        SayToPlayer("Not that I have a work office");
        yield return new WaitForSeconds(3);
        SayToPlayer("It's some where I use to contact my friends and collegues.");
        yield return new WaitForSeconds(3.5f);
        SayToPlayer("Come to me when you're ready.");
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
            SayToPlayer("Hi, and welcome to...");

        if (ScriptStarted == 3)
            SayToPlayer("Where'd you go?");

        if (ScriptStarted == 6.5)
            SayToPlayer("Oh crap.");

        if (ScriptStarted == 10)
            SayToPlayer("I think I just lost you.");

        if (ScriptStarted == 14)
            SayToPlayer("Don't panic, just follow my voice.");

        if (ScriptStarted == 16)
            SayToPlayer("I knew the random spawn location thing was a pain in the tail.");

        if (ScriptStarted == 20)
            SayToPlayer("It's ok, i'm sure you can find me.");

        if (ScriptStarted == 22)
            SayToPlayer("I hope.");

        if (ScriptStarted == 26)
        {
            eventStartTime = ScriptStarted;
            sceneLoaded = "Mumble";
        }
    }*/
    private IEnumerator LightingIntro()
    {
            SayToPlayer("Hi, and welcome back to...");
        yield return new WaitForSeconds(2);
            SayToPlayer("Wait.");
        yield return new WaitForSeconds(2);
            SayToPlayer("This isn't the facility.");
        yield return new WaitForSeconds(3);
            SayToPlayer("Where'd you go?");
        yield return new WaitForSeconds(3.5f);
            SayToPlayer("Oh crap.");
        yield return new WaitForSeconds(4);
            SayToPlayer("I think I just lost you.");
        yield return new WaitForSeconds(4);
            SayToPlayer("Crap, I misclicked another scene.");
        yield return new WaitForSeconds(4);
            SayToPlayer("Don't panic, just follow my voice.");
        yield return new WaitForSeconds(2);
            SayToPlayer("I knew the random spawn location thing was a pain in the tail.");
        yield return new WaitForSeconds(4);
            SayToPlayer("It's ok, I'm sure you can find me.");
        yield return new WaitForSeconds(2);
            SayToPlayer("I hope.");
        
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

        if (pointMessage == "Player triggered stairs")
            StartCoroutine(StairTrap());

        if (pointMessage == "Player first found Crow")
            StartCoroutine(FoundInLighting());

    }

    private IEnumerator FoundInLighting()
    {
        SayToPlayer("Oh hey!");
        yield return new WaitForSeconds(1.5f);
        SayToPlayer("Over here!");
        yield return new WaitForSeconds(2);
        SayToPlayer("In any case, I need to go get some stuff.");
        yield return new WaitForSeconds(2);
        SayToPlayer("You're welcome to follow me if you'd like.");
        yield return new WaitForSeconds(2);
        SayToPlayer("Come to me when you're ready.");
        yield return new WaitForSeconds(1.5f);
    }

    private IEnumerator StairTrap()
    {
        readyToLeaveScene = true;
        SayToPlayer("Wait stop!");
        yield return new WaitForSeconds(1);
        SayToPlayer("Run!");
        yield return new WaitForSeconds(3);
        SayToPlayer("Are you ok?");
        yield return new WaitForSeconds(2);
        SayToPlayer("I forgot that was there.");
        yield return new WaitForSeconds(3);
        SayToPlayer("My bad.");
        yield return new WaitForSeconds(2);
        SayToPlayer("I'll find another way for you.");
        yield return new WaitForSeconds(2);
        SayToPlayer("Could've swarn I had a backdoor somewhere near here.");
        yield return new WaitForSeconds(7);

    }



    /*
    private void RespawnRoom2()
    {
        if (ScriptStarted == 0.5f)
            SayToPlayer("Yeah, as you can see, I don't have a lot going on in that room yet.");

        if (ScriptStarted == 3f)
            SayToPlayer("In the future perhaps it will have more going on.");

        if (ScriptStarted == 5f)
            SayToPlayer("In any case, I need to go get some stuff.");

        if (ScriptStarted == 6.5f)
            SayToPlayer("You're welcome to follow me if you'd like.");

        if (ScriptStarted == 8f)
            SayToPlayer("Come to me when you're ready.");

        if (ScriptStarted == 9f)
            sceneLoaded = "PreparingToLeaveFacility";
    }
    *///Old script that didn't use coroutine, left to provide record.
    private IEnumerator RespawnRoom2()
    {
            SayToPlayer("Yeah, as you can see, I don't have a lot going on in that room yet.");
        yield return new WaitForSeconds(3);
            SayToPlayer("In the future perhaps it will have more going on.");
        yield return new WaitForSeconds(2);
            SayToPlayer("In any case, I need to go get some stuff.");
        yield return new WaitForSeconds(2);
            SayToPlayer("You're welcome to follow me if you'd like.");
        yield return new WaitForSeconds(2);
            SayToPlayer("Come to me when you're ready.");
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
                SayToPlayer("All ready to go?");

            if (ScriptStarted == 1.5f)
                SayToPlayer("All ready to go?");

            if (ScriptStarted == 2.5f)
                SayToPlayer("I'll take that as a yes.");

            if (ScriptStarted == 4f)
                SayToPlayer("Leaving in 3...");

            if (ScriptStarted == 5f)
                SayToPlayer("2...");

            if (ScriptStarted == 6f)
                SayToPlayer("1...");

            if (ScriptStarted == 7f)
                SceneManager.LoadScene("Pond");
        }
        else
        {
            eventStartTime = Time.fixedTime;
            sceneLoaded = "PreparingToLeaveFacility";
        }

        
    }
    *///Old script that didn't use coroutine, left to provide record.
    private IEnumerator LeavingFacility()
    {
        SayToPlayer("All ready to go?");
        yield return new WaitForSeconds(2f);
                SayToPlayer("I'll take that as a yes.");
        yield return new WaitForSeconds(2f);
                SayToPlayer("Leaving in 3...");
        yield return new WaitForSeconds(1f);
                SayToPlayer("2...");
        yield return new WaitForSeconds(1f);
                SayToPlayer("1...");
        yield return new WaitForSeconds(1f);
                SceneManager.LoadScene("Pond");
    }

    private IEnumerator LeavingPond()
    {
        SayToPlayer("good to go?");
        yield return new WaitForSeconds(1.5f);
        SayToPlayer("Alright");
        yield return new WaitForSeconds(1.5f);
        SayToPlayer("Leaving Pond in 3...");
        yield return new WaitForSeconds(1f);
        SayToPlayer("2...");
        yield return new WaitForSeconds(1f);
        SayToPlayer("1...");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Lighting");
    }

    private IEnumerator LeavingLighting()
    {
        SayToPlayer("Thank Starclan you made it.");
        yield return new WaitForSeconds(2f);
        SayToPlayer("I was totally not getting worried");
        yield return new WaitForSeconds(2f);
        SayToPlayer("[nervous chuckle]");
        yield return new WaitForSeconds(2f);
        SayToPlayer("So what say we get back to the facility?");
        yield return new WaitForSeconds(2f);
        SayToPlayer("Getting out of this shithole in 3...");
        yield return new WaitForSeconds(1f);
        SayToPlayer("2...");
        yield return new WaitForSeconds(1f);
        SayToPlayer("1...");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("ReturnFacility");
    }

    /*
    private IEnumerator LeavingOffice()
    {
        //unchanged from copy of leavefacility.
        SayToPlayer("All ready to go?");
        yield return new WaitForSeconds(1.5f);
        SayToPlayer("All ready to go?");
        yield return new WaitForSeconds(1.5f);
        SayToPlayer("I'll take that as a yes.");
        yield return new WaitForSeconds(2f);
        SayToPlayer("Leaving in 3...");
        yield return new WaitForSeconds(1f);
        SayToPlayer("2...");
        yield return new WaitForSeconds(1f);
        SayToPlayer("1...");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Lighting");
    }
    */ //Office no longer a used scene

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
                    /*
                case "Office":
                    StartCoroutine(LeavingOffice());
                    break;
                    */
                case "Lighting":
                    StartCoroutine(LeavingLighting());
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
    *///Old script that didn't use coroutine, left to provide record.


    private void FoundCrowInLighting()
    {
        if (ScriptStarted == 0.5f)
            SayToPlayer("Oh there you are.");
    }

    /*
    private void FirstEncounter()
    {

        if (ScriptStarted == 1f)
        {
            SayToPlayer("Oh...         ");
            WorkPanels.gameObject.SetActive(false);
        }
            
        if (ScriptStarted == 4)
            SayToPlayer("You...");

        if (ScriptStarted == 6)
            SayToPlayer("Are you a player?");

        if (ScriptStarted == 8)
            SayToPlayer("You're not supposed to be here.");

        if (ScriptStarted == 11)
            SayToPlayer("The game's not done.");

        if (ScriptStarted == 13)
            SayToPlayer("It's not ready.");

        if (ScriptStarted == 15)
            SayToPlayer("How did you even get here?");

        if (ScriptStarted == 17)
            SayToPlayer("Can you speak?");

        if (ScriptStarted == 18.5)
            SayToPlayer("Try typing.");

        if (ScriptStarted == 21)
            SayToPlayer("Oh yeah, I didn't Implement the speech system yet.");

        if (ScriptStarted == 24)
            SayToPlayer("Well the game isn't finished so...");

        if (ScriptStarted == 26)
            SayToPlayer("I mean, I'm not gonna ask you to leave.");

        if (ScriptStarted == 28)
            SayToPlayer("Feel free to take a look around I guess.");

        if (ScriptStarted == 30)
            SayToPlayer("I tend to mumble a bit to myself a bit when I work, don't mind me.");

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
        SayToPlayer("Oh...         ");
        WorkPanels.gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
            SayToPlayer("You...");
        yield return new WaitForSeconds(2);
            SayToPlayer("Are you a player?");
        yield return new WaitForSeconds(2);
            SayToPlayer("You're not supposed to be here.");
        yield return new WaitForSeconds(3);
            SayToPlayer("The game's not done.");
        yield return new WaitForSeconds(2);
            SayToPlayer("It's not ready.");
        yield return new WaitForSeconds(2);
            SayToPlayer("How did you even get here?");
        yield return new WaitForSeconds(2);
            SayToPlayer("Can you speak?");
        yield return new WaitForSeconds(1.5f);
            SayToPlayer("Try typing.");
        yield return new WaitForSeconds(2.5f);
            SayToPlayer("Oh yeah, I didn't Implement the speech system yet.");
        yield return new WaitForSeconds(3);
            SayToPlayer("Well the game isn't finished so...");
        yield return new WaitForSeconds(2);
            SayToPlayer("I mean, I'm not gonna ask you to leave.");
        yield return new WaitForSeconds(2);
            SayToPlayer("Feel free to take a look around I guess.");
        yield return new WaitForSeconds(2);
            SayToPlayer("I tend to mumble a bit to myself a bit when I work, don't mind me.");
        yield return new WaitForSeconds(2);
            WorkPanels.gameObject.SetActive(true);
        StartCoroutine(JibberishMumbule());

    }

    /*
    private void JibberishMumbule()
    {
        if ((ScriptStarted) % 6 == 0)
        {
            SayToPlayer( Gibberish[UnityEngine.Random.Range(0, Gibberish.Count - 1)]);
        }
    }
    *///Old script that didn't use coroutine, left to provide record.
    private IEnumerator JibberishMumbule()
    {
        for (int i = 0; i < 5; i=i)
        {
            SayToPlayer(Gibberish[UnityEngine.Random.Range(0, Gibberish.Count - 1)]);
            yield return new WaitForSeconds(UnityEngine.Random.Range(10,20));
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
                //SayToPlayer("I'm sorry, I have some more work to do");
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

    private void SayToPlayer(string stuffToSay)
    {
        crowSpeaker.Stop();
        crowSpeaker.clip = Caw();
        crowSpeaker.Play();
        SaidToPlayer.Invoke(stuffToSay);
    }

    private void setupGibberish()
    {
        if (SceneManager.GetActiveScene().name != "Lighting")
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
        }
        else
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
