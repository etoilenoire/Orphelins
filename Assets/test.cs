using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform destination0;
    public Transform destination1;
    public Transform destination2;

    private float distanceProche;

    [SerializeField]
    PersoActuel perso;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        distanceProche = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (perso.GetPersoSelectionne() == 0)
        {
            agent.SetDestination(destination0.position);
            if(Vector3.Distance(destination0.position, transform.position) < distanceProche)
            {
                agent.SetDestination(transform.position);
            }
        }

        if (perso.GetPersoSelectionne() == 1)
        {
            agent.SetDestination(destination1.position);
            if (Vector3.Distance(destination0.position, transform.position) < distanceProche)
            {
                agent.SetDestination(transform.position);
            }
        }

        if (perso.GetPersoSelectionne() == 2)
        {
            agent.SetDestination(destination2.position);
            if (Vector3.Distance(destination0.position, transform.position) < distanceProche)
            {
                agent.SetDestination(transform.position);
            }
        }
    }
}
