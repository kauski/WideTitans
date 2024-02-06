using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// author: Henri Hienonen (last edited 1.4.22) //removed unncesessary code lines from update, update ui, textbox to unpause/victory/defeat


public class Monster : MonoBehaviour
{
    DisplayDurability Displaydurability;
    DisplayGold Displaygold;
    public int Takedamage;
    public int VictoryGold;
    public Text Pausetext;
    public GameObject Background;
    public bool Endgame;

    public static bool startPause;
    public static bool eventPauser;

    public float Health;
    public float MaxHealth;

    [Range(-300.0f, 300.0f)]
    public float floatSpeed;
    public bool mustFloat;
    public Transform spawnPosition;

    public float timePeriod = 2.0f;
    public float height = 1.0f;
    private float timeSinceStart;

    public Rigidbody2D rb2d;
    private Vector2 pivot;
    //public GameObject FloaterSpawn;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        VictoryGold = 20;
        Health = MaxHealth;
        pivot = transform.position;
        timeSinceStart = (3 * timePeriod) / 4;

        mustFloat = true;

        startPause = true;

        Takedamage = 20; //amount to take dmg
        Pausetext.gameObject.SetActive(true);
        Background.SetActive(true);
        Pausetext.text = "Press mouse 1 and drag to shoot! Press space to start.";
        Endgame = false;

        //animator.Play("rockfly");
    }

    // Update is called once per frame
    void Update()
    {
        if (Endgame == false)
        {
            Vector2 nextPos = transform.position;
            nextPos.y = pivot.y + height + height * Mathf.Sin(((Mathf.PI * 2) / timePeriod) * timeSinceStart);
            timeSinceStart += Time.deltaTime;
            transform.position = nextPos;
        }
        if (mustFloat)
        {
            Float();
        }


        if (startPause && Input.GetKeyDown(KeyCode.Space))
        {
          
            startPause = false;
            Time.timeScale = 1;
            Pausetext.gameObject.SetActive(false);
            Background.SetActive(false);
        }

        if (eventPauser && Input.GetKeyDown(KeyCode.Space))
        {
          
            eventPauser = false;
            Time.timeScale = 1;
            SceneManager.LoadScene("OVERWORLD", LoadSceneMode.Single);
        }
    }

    void Float()
    {
        rb2d.velocity = new Vector2(floatSpeed * Time.fixedDeltaTime, rb2d.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            Health -= 1;
            
            if (Health < 1)
            {
                MonsterDeath();
                Pausetext.gameObject.SetActive(true);
                Background.SetActive(true);
                Pausetext.text = "Victory! You have gained " + VictoryGold.ToString() + " Gold! Press space to continue.";
                Endgame = true;
            }
        }

        if (collision.gameObject.tag == "Player")
        {
            Durability.Shipdurability -= Takedamage;
            if (Durability.Shipdurability < 1)
            {

                SceneManager.LoadScene("OVERWORLD", LoadSceneMode.Single);
            }
            else
            {
                eventPauser = true;
                EventGameTime();
                Background.SetActive(true);
                Pausetext.gameObject.SetActive(true);
                Pausetext.text = "You've lost! Your ship took " + Takedamage.ToString() + " damage! Press space to continue.";

               
                Displaydurability = GameObject.Find("Canvas").gameObject.transform.Find("P_Resources").gameObject.transform.Find("Durability").GetComponent<DisplayDurability>();
                Displaydurability.UpdateDurability();
                Debug.Log($"{Durability.Shipdurability}");
                Endgame = true;
            }
           

        }
    }

    void MonsterDeath()
    {
        Durability.Gold += VictoryGold;
        Displaygold = GameObject.Find("Canvas").gameObject.transform.Find("P_Resources").gameObject.transform.Find("Gold").GetComponent<DisplayGold>();
        Displaygold.UpdateGold();
      
        //Object.Destroy(this.gameObject);
        eventPauser = true;
      //  EventGameTime();

    }

    public void EventGameTime()
    {
        if (eventPauser == true || startPause == true)
        {
            Time.timeScale = 0f;
            
            
        }
        else if (eventPauser == false || startPause == false)
        {
            Time.timeScale = 1;
            
        }
    }
}
