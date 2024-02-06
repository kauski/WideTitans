using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// author: Henri Hienonen (last edited 14.4.22) //added checkpoint saver, adjusted to do method from other script jani kauhanen 5may22


// https://docs.unity3d.com/560/Documentation/Manual/RandomNumbers.html
// https://www.reddit.com/r/Unity3D/comments/dbczm0/comment/f209rlr/?utm_source=reddit&utm_medium=web2x&context=3
// https://www.reddit.com/r/Unity3D/comments/dbczm0/comment/f20r6mm/?utm_source=reddit&utm_medium=web2x&context=3



public class EventDice : MonoBehaviour
{
    public float[] events;
    private Checkpoint Leventcheckpoint;
   
    const int DEFAULT_ENCOUNTER_THRESHOLD = 10;
    private int currentEncounterThreshold = DEFAULT_ENCOUNTER_THRESHOLD;

   public EventList eventlist;

    
    //public Transform pMoveTo;
    public GameObject player;
    Vector3 lastPos;

    public static bool eventPauserGM;

    //string events;

    void Start()
    {
        Leventcheckpoint = GameObject.FindGameObjectWithTag("Checker").GetComponent<Checkpoint>();
        
        //pMoveTo.parent = null;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (player.transform.position != lastPos)
        {
            Chance();
        }
        else
        {
            //Player has not moved
        }

        lastPos = player.transform.position;
    }
    /*
    void movementDetection()
    {
        player.transform.position = Vector3.MoveTowards(transform.position, pMoveTo.position, Time.deltaTime);
    }
    */
    void Chance()
    {
        int value = Random.Range(0, 100000);

        if (value < currentEncounterThreshold)
        {
            Encounter();
            currentEncounterThreshold = DEFAULT_ENCOUNTER_THRESHOLD;
        }
        else
        {
            currentEncounterThreshold += 1;
        }
    }

    void Encounter()
    {

        int randomNumber = Random.Range(0, 3);

        if (randomNumber == 1)
        {
            Leventcheckpoint.Lastcheckpoint = new Vector2(transform.position.x, transform.position.y * 0);


            EventList.MiniGameLoader1();
        }
        else if (randomNumber == 2)
        {
            EventList list = eventlist.GetComponent<EventList>();
            list.TextEvents();
           // eventlist.TextEvents();
            //SceneManager.LoadScene("Minigame2");
           // eventlist.TextEvents();
           
        }
        else if (randomNumber == 3)
        {
            //SceneManager.LoadScene("Minigame2");
            
        }
        else if (randomNumber == 4)
        {
            //SceneManager.LoadScene("Minigame2");
            
        }
        else if (randomNumber == 5)
        {
            //SceneManager.LoadScene("Minigame2");
          
        }

        //int randomIndex = Random.Range(1, events.Length);

        //List<int> possibleEvents = new List<int>();

    }

    public static void EventGameTimeGM()
    {
        if (eventPauserGM == true)
        {
            Time.timeScale = 0f;
            Debug.Log("paused ED");
        }
        else if (eventPauserGM == false)
        {
            Time.timeScale = 1;
            Debug.Log("running ED");
        }
    }

    /*
    public string GetRandomItem(List<string> listToRandomize)
    {
        int randomNum = Random.Range(0, listToRandomize.Count);
        print(randomNum);
        string printRandom = listToRandomize[randomNum];
        print(printRandom);
        return printRandom;
    }
    */
}


//ar element = myArray[Random.Range(0, myArray.Length)];

/*
    float Choose (float[] probs)
    {

        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i= 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
            return i;
            }

            else
            {
            randomPoint -= probs[i];
            }
        }

        return probs.Length - 1;
    }
*/

/*
    void Shuffle (int[] deck)
    {
        for (int i = 0; i < deck.Length; i++)
        {
            int temp = deck[i];
            int randomIndex = Random.Range(0, deck.Length);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }
*/