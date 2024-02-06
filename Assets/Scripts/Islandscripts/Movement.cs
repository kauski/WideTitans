using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//author jani kauhanen
public class Movement : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal;
    float vertical;
    public float Speed = 1.0f;
    public bool Right = true;
    public bool Facing;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        body.velocity = new Vector2(horizontal * Speed, vertical * Speed);


        if (Input.GetKey(KeyCode.D) && Facing == false)
        {

            Flip();
            Facing = true;
        }
        if (Input.GetKey(KeyCode.A) && Facing == true)
        {

            Flip();
            Facing = false;
        }
        void Flip()
        {
            Right = !Right;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }


    }
}
