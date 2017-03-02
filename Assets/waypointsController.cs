using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waypointsController : MonoBehaviour {


    public GameObject[] waypoints;
    public GameObject nextWapoint;
    public GameObject persistantObject;
    public float countDown;
    public float curDown;
    public float timeBonus;
    public Text timeRemaining;
    public Text totalTime;
    private float curOverTime = 0;
    public string trackName;

	// Use this for initialization
	void Start () {
        nextWapoint = waypoints[0];
        curDown = countDown;
        var main = nextWapoint.GetComponent<waypointCollider>().ps.main;
        main.startColor = new Color(0, 1, 0, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
        timeRemaining.text = ""+curDown.ToString("F2");
        totalTime.text = "Total Time:" + (curOverTime).ToString("F2");
		for(int i = 0; i < waypoints.Length; i++)
        {
            if (i == waypoints.Length-1 && waypoints[i].GetComponent<waypointCollider>().collided)
            {
                float minutes = 0;
                while(curOverTime >= 60)
                {
                    minutes += 1;
                    curOverTime -= 60;
                }
                string score = minutes + ":" + curOverTime;
                persistantObject.GetComponent<persistantData>().setInfo(score, true, trackName);
                Debug.Log("Winner:"+score);
            }
            else if (waypoints[i].GetComponent<waypointCollider>().collided)
            {
                if(nextWapoint == waypoints[i])
                {
                    nextWapoint = waypoints[i+1];
                    var main = nextWapoint.GetComponent<waypointCollider>().ps.main;
                    main.startColor = new Color(0, 1, 0, 0.1f);
                    curDown += timeBonus;
                }
            }
        }
        curDown -= Time.deltaTime;
        curOverTime += Time.deltaTime;
        if(curDown <= 0.0f)
        {
            float minutes = 0;
            while (curOverTime >= 60)
            {
                minutes += 1;
                curOverTime -= 60;
            }
            string score = minutes + ":" + curOverTime;
            persistantObject.GetComponent<persistantData>().setInfo(score, false, trackName);
            Debug.Log("Loser");
        }
	}

    public void setVars(GameObject _persistantObject, Text _totalTime, Text _timeRemaining)
    {
        persistantObject = _persistantObject;
        totalTime = _totalTime;
        timeRemaining = _timeRemaining;
    }
}
