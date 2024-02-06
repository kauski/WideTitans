using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//author jani kauhanen 21apr22
//comsume food/hp based on distance
public class FoodComsume : MonoBehaviour
{
    [SerializeField]
    private Transform start;
    private float distance;
    bool starter;
    Displayfood Foodie;
    Displayhealth Healthie;
    public float Currentpos;
    private int eat; //amount to reduce food
    private int hp;  //amount to reduce health nor increase.
    private int Adjustdistance; //distance travelled in order to lose food/health
    public Daycounter Countdays;
    public GameObject Deathscreenie;
    public Deathscreen Playerdeath;
    private void Start()
    {
        distance = (start.transform.position - transform.position).magnitude;
        Currentpos = distance;
        eat = 1;
        hp = 1;
        Adjustdistance = 1;
        Deathscreenie.SetActive(false);
        
    }
    private void Update()
    {
        distance = (start.transform.position - transform.position).magnitude;
        if (distance > Currentpos && Food.Shipfood > 0)
        {
            Countdays.Updateday();
            Currentpos = distance + Adjustdistance;
            Food.Shipfood = Food.Shipfood -eat;
            Foodie = GameObject.Find("Canvas").gameObject.transform.Find("P_Resources").gameObject.transform.Find("Food").GetComponent<Displayfood>();
            Foodie.Updatefood();
            if (Health.Phealth < 100)
            {
                
                Healthie = GameObject.Find("Canvas").gameObject.transform.Find("P_Resources").gameObject.transform.Find("Health").GetComponent<Displayhealth>();
                Health.Phealth = Health.Phealth + hp;
                Healthie.Updatehealth();
            }
        }
        //TODO death screen.
        else if (starter == false)
        {
            starter = true;
            Currentpos = distance + Adjustdistance;
        }
        else if (distance > Currentpos && Food.Shipfood == 0 && Health.Phealth > 0)
        {
            Countdays.Updateday();
            Healthie = GameObject.Find("Canvas").gameObject.transform.Find("P_Resources").gameObject.transform.Find("Health").GetComponent<Displayhealth>();
            Currentpos = distance + Adjustdistance;
            Health.Phealth = Health.Phealth - hp;
            Healthie.Updatehealth();
        }
        else if (Food.Shipfood < 1 && Health.Phealth < 1)
        {
            Playerdeath.Death();
        }
    }

}

