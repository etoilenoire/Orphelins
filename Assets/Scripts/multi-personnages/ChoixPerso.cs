using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoixPerso : MonoBehaviour
{
    [SerializeField]
    PersoActuel perso;

    [SerializeField]
    int numeroPerso;

    DeplacementPersonnage dp;
    Rigidbody2D rb;

    bool resetVelocite;

    // Start is called before the first frame update
    void Start()
    {
        perso.SetNombrePersoPresent(perso.GetNombrePersoPresent() + 1);
        dp = GetComponent<DeplacementPersonnage>();
        rb = GetComponent<Rigidbody2D>();
        resetVelocite = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(perso.GetPersoSelectionne() != numeroPerso)
        {
            dp.enabled = false;
            if (!resetVelocite)
            {
                //rb.velocity = new Vector2(0, rb.velocity.y);
                resetVelocite = true;
            }
        }
        else
        {
            resetVelocite = false;
            dp.enabled = true;
        }
    }
}
