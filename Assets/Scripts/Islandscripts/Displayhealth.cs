using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Displayhealth : MonoBehaviour
{
    private int __health;
    public Text _health;
    void Start()
    {
        _health = transform.GetComponent<Text>();
        __health = Health.Phealth;
        if (__health == 0)
        {
            Updatehealth();
        }
        _health.text = "Health " + __health.ToString();
    }
    public void Updatehealth()
    {
        __health = Health.Phealth;
        _health.text = "Health " + __health.ToString();
        
    }
}
