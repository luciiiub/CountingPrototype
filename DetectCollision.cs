using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectCollisionsX : MonoBehaviour
{
    // Cuando este objeto entra en contacto con un trigger
    private void OnTriggerEnter(Collider other)
    {
        // Destruye objeto 
        Destroy(gameObject);
    }
}



