using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//author jani kauhanen 18may22
//island scene Pmovement animation handling.
public class Animating : MonoBehaviour
{
    
    private Animator Anime;
    // Start is called before the first frame update
    void Start()
    {
        Anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     

        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.A)))

        {
            Anime.SetBool("AnimChange", true);
        }

        else
        {
            Anime.SetBool("AnimChange", false);
        }
    }
}
