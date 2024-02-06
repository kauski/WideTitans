using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFishing : MonoBehaviour
{

    [SerializeField] float mouseSpeed;

    Transform startingLevel;
    bool lowerHook;
    bool pullHook;
    public GameObject Hook;

    private Vector3 targetPos;
    public float speed = 2.0f;

    Rigidbody2D rb2d;

    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (!FishingTimer.gamePaused)
            {
                if (!Input.GetButton("Fire1") && !pullHook)
                {
                    float distance = transform.position.z - Camera.main.transform.position.z;
                    targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
                    targetPos = Camera.main.ScreenToWorldPoint(targetPos);

                    Vector3 followXonly = new Vector3(targetPos.x, transform.position.y, transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, followXonly, speed * Time.deltaTime);
                }
                else if (Input.GetButtonDown("Fire1"))
                {
                    lowerHook = true;
                    pullHook = false;
                }
                if (Input.GetButtonUp("Fire1"))
                {
                    pullHook = true;
                    lowerHook = false;
                }

                if (lowerHook)
                {
                    gameObject.transform.Translate(0, -0.01f, 0);
                }

                if (pullHook)
                {
                    gameObject.transform.Translate(0, 0.02f, 0);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "surface")
        {
            pullHook = false;
        }
        if (collision.gameObject.tag == "seafloor")
        {
            lowerHook = false;
        }
    }
}
