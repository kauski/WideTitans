using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// author: Henri Hienonen (last edited 14.4.22) //added text events and UI elements janikauhanen 5may22

public class EventList : MonoBehaviour
{
    public GameObject Losedurability;
    public GameObject Losefood;
    public GameObject Losehealth;
    public GameObject Gaindurability;
    public GameObject Gainfood;
    public GameObject Gainhealth;
    public GameObject Scenery;
    public GameObject Textbackground;
    
    public static bool eventPauser;
    public int math;
    public static GameObject popUpUI;
    DisplayDurability displaydurability;
    Displayhealth displayhealth;
    DisplayGold displaygold;
    Displayfood displayfood;
    // Start is called before the first frame update
    void Start()
    {
        Losedurability.SetActive(false);
        Losefood.SetActive(false);
        Losehealth.SetActive(false);
        Gaindurability.SetActive(false);
        Gainfood.SetActive(false);
        Gainhealth.SetActive(false);
        Scenery.SetActive(false);
        Textbackground.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && eventPauser || (Input.GetKeyDown(KeyCode.D)) && eventPauser)
        {
          
            eventPauser = false;
            Time.timeScale = 1;

            displaydurability = GameObject.Find("Canvas").transform.Find("P_Resources").gameObject.transform.Find("Durability").GetComponent<DisplayDurability>();
            displaydurability.UpdateDurability();

            displayhealth = GameObject.Find("Canvas").transform.Find("P_Resources").gameObject.transform.Find("Health").GetComponent<Displayhealth>();
            displayhealth.Updatehealth();

            displaygold = GameObject.Find("Canvas").transform.Find("P_Resources").gameObject.transform.Find("Gold").GetComponent<DisplayGold>();
            displaygold.UpdateGold();

            displayfood = GameObject.Find("Canvas").transform.Find("P_Resources").gameObject.transform.Find("Food").GetComponent<Displayfood>();
            displayfood.Updatefood();
            Losedurability.SetActive(false);
            Losefood.SetActive(false);
            Losehealth.SetActive(false);
            Gaindurability.SetActive(false);
            Gainfood.SetActive(false);
            Gainhealth.SetActive(false);
            Scenery.SetActive(false);
            Textbackground.SetActive(false);
        }

    }

    public static void MiniGameLoader1()
    {
       
        eventPauser = true;
        EventGameTime();
        SceneManager.LoadScene("MINIGAME1-MONSTER", LoadSceneMode.Single);
       
    }

    public void TextEvents()
    {
        /*
        List<string> theEvents = new List<string>();
        theEvents.Insert(1, "time");
        */

        //popUpUI.SetActive(true);

        int randomNumber = Random.Range(1, 7);

        if (randomNumber == 1)
        {
            
            eventPauser = true;
            EventGameTime();
          
            Textbackground.SetActive(true);
            Losedurability.SetActive(true);
            //popup window tähän
            if (Durability.Shipdurability < 16)
            {
               
                Durability.Shipdurability = 0;
                //todo game over
            }
            else
            {
                Durability.Shipdurability -= 15;
            }
        }
        else if (randomNumber == 2)
        {
            Textbackground.SetActive(true);
            Losefood.SetActive(true);
            eventPauser = true;
            EventGameTime();
          
            //popup window tähän
            if (Food.Shipfood < 16)
            {
               
                Food.Shipfood = 0;
                
              

            }
            else
            {
                Food.Shipfood -= 15;
            }
            
        }
       else if (randomNumber == 3)
        {
            Textbackground.SetActive(true);
            Losehealth.SetActive(true);
            eventPauser = true;
            EventGameTime();
            
            if (Health.Phealth < 16)
            {
                Health.Phealth = 0;
               
            }
            else
            {
                Health.Phealth -= 15;
            }
           
        }
       else if (randomNumber == 4)
        {
            Textbackground.SetActive(true);
            Gaindurability.SetActive(true);
            eventPauser = true;
            EventGameTime();
            
            
            if (Durability.Shipdurability < 95)
            {
                Durability.Shipdurability += 5;
            }
            else
            {
                Durability.Shipdurability = 100;
            }
        }
       else if (randomNumber == 5)
        {
            Textbackground.SetActive(true);
            Gainfood.SetActive(true);
            eventPauser = true;
            EventGameTime();
          
            
            if (Food.Shipfood > 94)
            {
                Food.Shipfood = 100;
            }
            else
            {
                Food.Shipfood += 5;
            }
           
        }
       else if (randomNumber == 6)
        {
            Textbackground.SetActive(true);
            Gainhealth.SetActive(true);
            eventPauser = true;
            EventGameTime();
            

            if (Health.Phealth > 94)
            {
                Health.Phealth = 100;
            }
            else
            {
                Health.Phealth += 5;
            }
            
          
        }

       else if (randomNumber == 7)
        {
            Textbackground.SetActive(true);
            eventPauser = true;
            EventGameTime();
           
            Scenery.SetActive(true);
            Durability.Gold += 20;
            Durability.Shipdurability -= 10;
            Health.Phealth -= -20;
        }


    }

    public static void EventGameTime()
    {
        if (eventPauser == true)
        {
            Time.timeScale = 0f;
          
        }
        else if (eventPauser == false)
        {
            Time.timeScale = 1;
          
        }
    }
}
