using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//author jani kauhanen 31mar22 -- updated 1apr22 --5apr22
//shop for repair/food
public class Activateshop : MonoBehaviour
{
    Durability Arep;
    Food Afod;
    DisplayGold playerGold;
    Displayfood Displayfood;
    DisplayDurability Displaydurability;
    public GameObject Shop;
   static public bool area; //deactivate shop area
    private bool shopactive; //active shopping area
    //selection to check which item will be bought.
    public GameObject Select1;
    public GameObject Select2;
    public GameObject Select3;
    public GameObject Select4;
    public GameObject Shopupdate;
    public int Selection; // 0 = repair ship. 1 = food.
    private bool Openshop;
    void Start()
    {
        Shopupdate.SetActive(false);
        Shop.SetActive(false);
        shopactive = false;
        Select1.SetActive(false);
        Select2.SetActive(false);
        Select3.SetActive(false);
        Select4.SetActive(false);
        enabled = false; // update is only called when on shopping area.
        area = false;
        Selection = 0;
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enabled = true; //enables script update upon collision with the player
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enabled = false; //disabes script update upon player collision ends
        
        Shop.SetActive(false);
        shopactive = false;
        Select1.SetActive(false);
        Select2.SetActive(false);
        Select3.SetActive(false);
        Select4.SetActive(false);
        Openshop = false;
    }
    void Update()
    {
        if (area == false || Input.GetKeyDown(KeyCode.E) && shopactive == true)
        {
            Shop.SetActive(false);
            shopactive = false;
            Select1.SetActive(false);
            Select2.SetActive(false);
            Select3.SetActive(false);
            Select4.SetActive(false);
            Openshop = false;
        }

        else if (Input.GetKeyDown(KeyCode.E) && area == true)
        {
            Shop.SetActive(true);
            shopactive = true;
            Select1.SetActive(true);
            Select2.SetActive(true);
            Selection = 0;
            Openshop = true;
        }

        else if (Input.GetKeyDown(KeyCode.S) && Selection == 0 && area == true && Openshop == true)
        {
            Shop.SetActive(true);
            Selection = 1;
            Select1.SetActive(false);
            Select2.SetActive(false);
            Select3.SetActive(true);
            Select4.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.S) && Selection == 1 && area == true && Openshop == true)
        {
            Shop.SetActive(true);
            Selection = 0;
            Select1.SetActive(true);
            Select2.SetActive(true);
            Select3.SetActive(false);
            Select4.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.W) && Selection == 0 && area == true && Openshop == true)
        {
            Shop.SetActive(true);
            Selection = 1;
            Select1.SetActive(false);
            Select2.SetActive(false);
            Select3.SetActive(true);
            Select4.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.W) && Selection == 1 && area == true && Openshop == true)
        {
            Shop.SetActive(true);
            Selection = 0;
            Select1.SetActive(true);
            Select2.SetActive(true);
            Select3.SetActive(false);
            Select4.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Return) && Selection == 0 && Openshop == true)
        {
            Shop.SetActive(true);
            Durability.P_repair(gameObject); //purchase repair on ship
            playerGold = GameObject.Find("Canvas").gameObject.transform.Find("P_Resources").gameObject.transform.Find("Gold").GetComponent<DisplayGold>();
            playerGold.UpdateGold();
            Displaydurability = GameObject.Find("Canvas").gameObject.transform.Find("P_Resources").gameObject.transform.Find("Durability").GetComponent<DisplayDurability>();
            Displaydurability.UpdateDurability();
        }
        else if (Input.GetKeyDown(KeyCode.Return) && Selection == 1 && Openshop == true)
        {
            Shop.SetActive(true);
            Food.P_food(gameObject); //purchases food
            Displayfood = GameObject.Find("Canvas").gameObject.transform.Find("P_Resources").gameObject.transform.Find("Food").GetComponent<Displayfood>();
            Displayfood.Updatefood();
            playerGold = GameObject.Find("Canvas").gameObject.transform.Find("P_Resources").gameObject.transform.Find("Gold").GetComponent<DisplayGold>();
            playerGold.UpdateGold();
        }
    }
}