using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour {
    public Obstacle_behavior[] obs;
    public GameObject end;

    int stage = 0;

    void Update() {
        Debug.Log(end.transform.position.x);
        if (stage == 0 && end.transform.position.x < -37)
        {
            for (int i = 0; i < obs.Length; i++)
            {
                obs[i].enabled = false;
            }
            stage += 1;
        } 

    }
}
