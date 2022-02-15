using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    //Variable gestion sol
    public bool grounded;



    public bool IsGrounded()
    {
        return grounded;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("NonSautable"))
        {
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;

    }
}
