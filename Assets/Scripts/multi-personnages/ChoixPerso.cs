using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChoixPerso : MonoBehaviour
{
    [SerializeField]
    PersoActuel perso;

    [SerializeField]
    int numeroPerso;

    NavMeshAgent nva;

    DeplacementPersonnage dp;
    Rigidbody2D rb;

    bool resetVelocite;

    // Start is called before the first frame update
    void Start()
    {
        perso.SetNombrePersoPresent(perso.GetNombrePersoPresent() + 1);
        dp = GetComponent<DeplacementPersonnage>();
        rb = GetComponent<Rigidbody2D>();
        nva = GetComponent<NavMeshAgent>();

        resetVelocite = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(perso.GetPersoSelectionne() != numeroPerso)
        {
            dp.enabled = false;
            nva.enabled = true;
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
            nva.enabled = false;
        }
    }
}
