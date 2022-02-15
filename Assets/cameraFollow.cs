using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject MainCharacter;

    [SerializeField]
    int distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(MainCharacter.transform.position.x, MainCharacter.transform.position.y,distance);
        transform.position = position;
    }
}
