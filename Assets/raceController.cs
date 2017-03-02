using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raceController : MonoBehaviour {

    public GameObject persistantObject;
    public Text totalTime;
    public Text timeRemaining;
    public Text countdown;

    public GameObject easyTrack;
    public GameObject mediumTrack;
    public GameObject hardTrack;

    public GameObject playerMovement;
    private float curDown = 3;
    private bool difficultyChosen = false;
    private string track;
    private bool trackBuilt;

	// Use this for initialization
	void Start () {
        curDown = 3;
    }
	
	// Update is called once per frame
	void Update () {
		if(difficultyChosen)
        {
            curDown -= Time.deltaTime;
            if(curDown > 0)
            {
                countdown.text = "" + curDown.ToString("F0");
            }
            else
            {
                countdown.text = "";
                //playerMovement.GetComponent<FlightController>().raceStart = true;
            }
            
            if(!trackBuilt)
            {
                if(track.Equals("easy"))
                {
                    GameObject track = Instantiate(easyTrack, transform.position, transform.rotation);
                    track.GetComponent<waypointsController>().setVars(persistantObject, totalTime, timeRemaining);
                }
                if (track.Equals("medium"))
                {
                    GameObject track = Instantiate(mediumTrack, transform.position, transform.rotation);
                    track.GetComponent<waypointsController>().setVars(persistantObject, totalTime, timeRemaining);
                }
                if (track.Equals("hard"))
                {
                    GameObject track = Instantiate(hardTrack, transform.position, transform.rotation);
                    track.GetComponent<waypointsController>().setVars(persistantObject, totalTime, timeRemaining);
                }
                trackBuilt = true;
            }

        }
	}

    public void setDifficulty(string _track)
    {
        track = _track;
        difficultyChosen = true;
    }
}
