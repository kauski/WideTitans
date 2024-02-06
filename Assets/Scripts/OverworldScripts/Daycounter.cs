using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//author jani kauhanen 5may22 
public class Daycounter : MonoBehaviour
{
    public static int Day;
    public Text Textday;
    
    void Start()
    {
        Day = Savedays.Daysave;

        Textday.text = "Day " + Day.ToString();
    }

    public void Updateday()
    {
        Day += 1;
        Textday.text = "Day " + Day.ToString();
        Savedays.Daysave = Day;
    }
 
}
