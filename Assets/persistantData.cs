using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistantData : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Object.DontDestroyOnLoad(gameObject);
	}

    private string time;
    private bool winner;
    private string track;

    public void setInfo(string _time, bool _winner, string _track)
    {
        time = _time;
        winner = _winner;
    }

    public string getTime()
    {
        return time;
    }

    public string getTrack()
    {
        return track;
    }

    public bool getWinner()
    {
        return winner;
    }
}
