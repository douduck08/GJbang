using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class trigger : MonoBehaviour {

    public int stage = 0;

    public trigger[] stages;
    public Transform[] pages;

    void Update() {
        if (stage == 0 && this.transform.position.x < -10)
        {
            Ending();
        }

        if (stage == 1 && this.transform.position.x < -39)
        {
            this.GetComponent<Obstacle_behavior>().enabled = false;
            pages[0].gameObject.SetActive(true);
            stages[0].enabled = false;
        }
        if (stage == 2 && this.transform.position.x < -67)
        {
            this.GetComponent<Obstacle_behavior>().enabled = false;
            pages[1].gameObject.SetActive(true);
            stages[1].enabled = false;
        }
        if (stage == 3 && this.transform.position.x < -80)
        {
            this.GetComponent<Obstacle_behavior>().enabled = false;
            pages[2].gameObject.SetActive(true);
            stages[2].enabled = false;
        }
    }

    public void StartStage (int stage)
    {
        pages[stage - 2].gameObject.SetActive(false);
        stages[stage - 1].enabled = true;
        stages[stage - 1].GetComponent<Obstacle_behavior>().enabled = true;
    }

    public void Ending ()
    {
        SceneManager.LoadScene("menu");
    }
}
