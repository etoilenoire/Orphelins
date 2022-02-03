using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoActuel : MonoBehaviour
{
    [SerializeField]
    private int nombrePersoPresent = 0;

    private int persoSelectionne = 0;
    // Start is called before the first frame update
    void Start()
    {
        persoSelectionne = 0;
    }

    public void SetNombrePersoPresent(int nombrePersoPresent)
    {
        this.nombrePersoPresent = nombrePersoPresent;
    }
    
    public int GetNombrePersoPresent()
    {
        return nombrePersoPresent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            print("switch");
            persoSelectionne += 1;
            if (persoSelectionne >= nombrePersoPresent)
                persoSelectionne = 0;
        }
    }

    public int GetPersoSelectionne()
    {
        return persoSelectionne;
    }
}
