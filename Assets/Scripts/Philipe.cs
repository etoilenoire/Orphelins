using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Philipe : MonoBehaviour
{
    private float fire;
    Vector2 velocite;

    Vector3 MousePosition;
    bool aAvale;
    GameObject objetAvale;

    private CircleCollider2D CCollider;
    private float speedX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedX = Input.GetAxis("Horizontal");
        CCollider = GetComponent<CircleCollider2D>();
        CCollider.offset = new Vector2(speedX / 2, 0);

        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //print(MousePosition);
        //Debug.DrawLine(transform.position, MousePosition, Color.green, 50f);

        fire = Input.GetAxis("Fire1");
        
        if(aAvale)
        {
            if (fire == 0)
            {
                aAvale = false;
                objetAvale.SetActive(true);
                //objetAvale.transform.position = transform.position + new Vector3(MousePosition.x - transform.position.x, MousePosition.y - transform.position.y)/5;
                objetAvale.transform.position = this.transform.position + new Vector3(MousePosition.x - transform.position.x, MousePosition.y - transform.position.y)/8;
                velocite = new Vector2(MousePosition.x - transform.position.x, MousePosition.y - transform.position.y);
                objetAvale.GetComponent<Rigidbody2D>().velocity = velocite;
                print(objetAvale.GetComponent<Rigidbody2D>().velocity);
                print(velocite);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Mangeable") && fire == 1 && !aAvale)
        {
            collider.gameObject.SetActive(false);
            objetAvale = collider.gameObject;
            aAvale = true;
            print(objetAvale);
        }
    }
}
