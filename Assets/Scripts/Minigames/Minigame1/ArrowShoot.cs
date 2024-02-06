using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// author: Henri Hienonen (last edited 1.4.22)

// https://www.youtube.com/watch?v=xWlVV-tE8O0
// https://www.youtube.com/watch?v=Tsha7rp58LI

public class ArrowShoot : MonoBehaviour
{
    [SerializeField] float mouseSpeed;

    public float power;
    public Vector2 minPower;
    public Vector2 maxPower;

    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    Camera cam;
    public ArrowTrajectory at;

    Rigidbody2D rb2d;

    [SerializeField] GameObject arrowPrefab;

    [SerializeField] Vector3 arrowForce;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        at = GetComponent<ArrowTrajectory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                startPoint.z = 15;
            }

            if (Input.GetButton("Fire1"))
            {
                Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                currentPoint.z = 15;
                at.RenderLine(startPoint, currentPoint);
            }

            if (Input.GetButtonUp("Fire1"))
            {
                endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                endPoint.z = 15;
                at.EndLine();
            }

            if (Input.GetButtonUp("Fire1"))
            {
                Shoot();
                
            }
        }
    }

    
    private void FixedUpdate()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction,transform.right).z;
        rb2d.angularVelocity = rotateAmount * mouseSpeed * Time.deltaTime;
    }
    

    void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
        force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
        arrow.GetComponent<Rigidbody2D>().AddRelativeForce(force * power, ForceMode2D.Impulse);

        /*
        force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
        rb2d.AddForce(force * power, ForceMode2D.Impulse);
        */
        
        Destroy(arrow, 5f);
    }
    
}
