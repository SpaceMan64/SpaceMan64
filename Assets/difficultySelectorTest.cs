using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficultySelectorTest : MonoBehaviour {
    public GameObject raceController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("i"))
        {
            raceController.GetComponent<raceController>().setDifficulty("easy");
        }
        if(Input.GetKeyDown("o"))
        {
            raceController.GetComponent<raceController>().setDifficulty("medium");
        }
        if(Input.GetKeyDown("p"))
        {
            raceController.GetComponent<raceController>().setDifficulty("hard");
        }
	}
}
