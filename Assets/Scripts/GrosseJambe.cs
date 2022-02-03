using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrosseJambe : MonoBehaviour
{
    private float fire;
    [SerializeField]
    PersoActuel perso;

    [SerializeField]
    int numeroPerso;

    private Rigidbody2D rb;
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
        fire = Input.GetAxis("Fire1");
        CCollider = GetComponent<CircleCollider2D>();
        CCollider.offset = new Vector2(speedX/2, 0);


    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (perso.GetPersoSelectionne() == numeroPerso)
        {
            if (collider.CompareTag("Cassable") && fire == 1)
            {
                collider.gameObject.SetActive(false);
            }
        }
    }

}
