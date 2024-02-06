using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// author: Henri Hienonen (last edited 1.4.22)


// https://www.youtube.com/watch?v=mbzXIOKZurA



public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 0.3f;
    public Transform movePoint;

    //public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
            {

                if (Input.GetKey(KeyCode.D))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }

                //anim.SetBool("moving", false);
            }
            else
            {
                //anim.SetBool("moving", true);
            }
        }    
    }
}
