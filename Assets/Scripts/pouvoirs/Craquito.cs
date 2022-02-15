using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craquito : MonoBehaviour
{
    private float fire;
    [SerializeField]
    PersoActuel perso;

    [SerializeField]
    int numeroPerso;

    GameObject light;

    // Start is called before the first frame update
    void Start()
    {
        light = transform.parent.gameObject.transform.Find("lumière").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        fire = Input.GetAxis("Fire1");

        if (perso.GetPersoSelectionne() == numeroPerso && fire == 1)
        {
            light.SetActive(true);
        }
        else
        {
            light.SetActive(false);
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (perso.GetPersoSelectionne() == numeroPerso)
        {

            if (collider.CompareTag("Brulable") && fire == 1)
            {
                collider.gameObject.SetActive(false);
            }
        }
    }
}
