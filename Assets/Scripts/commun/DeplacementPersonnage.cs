using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementPersonnage : MonoBehaviour
{
    public PhysicsMaterial2D pm2D;

    //Variable vitesse
    private float speedX;
    private float speedY;
    private Vector2 speed;

    //Variable Inspecteur vitesse
    [Range(1, 20), SerializeField]
    public float playerHorizontalSpeed = 1;
    [Range(1, 20), SerializeField]
    private float playerJumpHeight = 1;


    //variable saut
    [Range(1, 5), SerializeField]
    float fallMultiplier = 2.5f;
    [Range(1, 5), SerializeField]
    float smallJumpMultiplier = 2.5f;
    bool stopSaut = false;

    //Variable Objets
    private Rigidbody2D rb;
    private GroundCheck Gc;

    //private Animator animator;
    void Start()
    {
        speed = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();

        Gc = transform.Find("pieds").GetComponent<GroundCheck>();

        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            // animator.SetTrigger("Jump");
        }
    }

    void FixedUpdate()
    {
        //R�cuperer les valeurs de d�placements
        speedX = Input.GetAxis("Horizontal");
        speedY = rb.velocity.y;

        if (Gc.IsGrounded())
        {
            //print(pm2D.friction);
            pm2D.friction = 5;
            //speedY += Input.GetAxis("Jump") * playerJumpHeight;
            speedY += Mathf.Sqrt(-2f * Physics2D.gravity.y * rb.gravityScale * playerJumpHeight) * Input.GetAxis("Jump");
            //animator.ResetTrigger("Jump");
            if (Input.GetAxis("Jump") > 0)
            {
                Gc.grounded = false;
            }
        }

        if (!Gc.IsGrounded())
        {
            pm2D.friction = 0;
            //Descente : 
            if (rb.velocity.y < 0f && !stopSaut)
            {
                speedY += Physics2D.gravity.y * rb.gravityScale * fallMultiplier * Time.deltaTime;
            }
            //On monte et la touche est relach�e : la gravit� est plus forte (on monte donc moins haut)
            else if (!Input.GetButton("Jump"))
            {
                speedY += Physics2D.gravity.y * rb.gravityScale * smallJumpMultiplier * Time.deltaTime;
                stopSaut = true;
            }
        }
        else
        {
            stopSaut = false;
        }

        //Modification des valeurs par la vitesse du joueur
        speedX *= playerHorizontalSpeed;

        //Modifier les valeurs dans un vecteur
        speed.x = speedX;
        speed.y = speedY;

        //Changer la v�locit�
        rb.velocity = speed;
    }


}
