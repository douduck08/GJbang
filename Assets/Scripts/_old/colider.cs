using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colider : MonoBehaviour {

    public GameObject Player;


    void OntriggerEnter(colider other)
    {
       
            Destroy(Player);
        
    }
}
