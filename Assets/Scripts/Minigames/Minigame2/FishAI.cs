using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// author: Henri Hienonen (last edited 13.4.2022)
//

public class FishAI : MonoBehaviour
{
    [Range(-400.0f, 400.0f)]
    public float swimSpeed;

    public float waitTime = 2.0f;
    public float agroRange;
    private float distToPlayer;

    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;

    public Rigidbody2D rb2d;
    public Transform groundCheckPos;
    public Transform player;
    public LayerMask fishrail;
    public Collider2D bodyCollider;

    public bool hooked;

    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
        hooked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hooked)
        {
            if (mustPatrol)
            {
                Patrol();
            }

            distToPlayer = Vector2.Distance(transform.position, player.position);

            if (distToPlayer <= agroRange)
            {
                swimSpeed *= 1.1f;
                swimSpeed = Mathf.Clamp(swimSpeed, -300, 300);
            }
            else
            {
                swimSpeed = Mathf.Clamp(swimSpeed, -100, 100);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!hooked)
        {
            if (mustPatrol)
            {
                mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, fishrail);
            }
        }
    }

    void Patrol()
    {
        if (!hooked)
        {
            if (mustTurn || bodyCollider.IsTouchingLayers(fishrail))
            {
                Turn();
            }

            rb2d.velocity = new Vector2(swimSpeed * Time.fixedDeltaTime, rb2d.velocity.y);
        }
    }

    void Turn()
    {
        if (!hooked)
        {
            mustPatrol = false;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            swimSpeed *= -1;
            mustPatrol = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("fish caught");
            Caught();
            hooked = true;
            Object.Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Oceanlevel-mg1")
        {
            Object.Destroy(this.gameObject);
        }
    }

    void Caught()
    {
        if(hooked)
        {
            mustPatrol = false;
            swimSpeed = 0f;
        }
    }

    // public bool enemyAgro;

    /*
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
    }


    public void Attack()
    {
        mustPatrol = false;
        rb2d.velocity = Vector2.zero;
        Wait();
        mustPatrol = true;
    }
    */
}