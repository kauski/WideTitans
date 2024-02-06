using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//updated by jani kauhanen 21may22 - arrow rotation
public class Arrow : MonoBehaviour
{
   
    public Rigidbody2D Body;
    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(Body.velocity.y, Body.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster-mg1" || collision.gameObject.tag == "Oceanlevel-mg1")
        {
            
            Object.Destroy(this.gameObject);
        }
    }
}
