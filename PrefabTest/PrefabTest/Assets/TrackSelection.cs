using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackSelection : MonoBehaviour {

    GameObject tracks;


    public void SetupTrack() {

        Debug.LogWarning("Setting Track");
        HideAllTracks();

        SetTrackNumber();
        SetSeason();
        SetTimeOfDay();

    }

    private void HideAllTracks() {


        for (int i = 0; i < 3; i++)
        {
            GameObject t = tracks.transform.Find("track" + i.ToString()).gameObject;
            t.SetActive(false);
            for (int j = 0; j < 3; j++)
            {
                GameObject s = (GameObject)t.transform.Find("season" + j.ToString()).gameObject;
                s.SetActive(false);
                for (int k = 0; k < 2; k++)
                {

                    Debug.LogWarning(i.ToString() + j.ToString() + k.ToString());

                    GameObject tod = (GameObject)s.transform.Find("tod" + k.ToString()).gameObject;
                    tod.SetActive(false);
                }
            }
        }
    }

    public void SetTrackNumber()
    {
        Dropdown ddTrack = (Dropdown)GameObject.Find("TrackNumber").GetComponent(typeof(Dropdown));
        GameObject t = tracks.transform.Find("track" + ddTrack.value.ToString()).gameObject;
        t.SetActive(true);
    }

    public void SetSeason()
    {

        Dropdown ddTrack = (Dropdown)GameObject.Find("TrackNumber").GetComponent(typeof(Dropdown));
        Dropdown dd = (Dropdown)GameObject.Find("TrackSeason").GetComponent(typeof(Dropdown));

        GameObject t = tracks.transform.Find("track" + ddTrack.value).gameObject;
        GameObject s = (GameObject)t.transform.Find("season" + dd.value.ToString()).gameObject;
        s.SetActive(true);

    }

    public void SetTimeOfDay()
    {
        Dropdown dd = (Dropdown)GameObject.Find("TrackTimeOfDay").GetComponent(typeof(Dropdown));

        Dropdown ddTrack = (Dropdown)GameObject.Find("TrackNumber").GetComponent(typeof(Dropdown));
        Dropdown ddSeason = (Dropdown)GameObject.Find("TrackSeason").GetComponent(typeof(Dropdown));

        GameObject t = tracks.transform.Find("track" + ddTrack.value).gameObject;
        GameObject s = (GameObject)t.transform.Find("season" + ddSeason.value.ToString()).gameObject;

        GameObject tod = s.transform.Find("tod" + dd.value).gameObject;
        tod.SetActive(true);

    }


    // Use this for initialization
    void Start () {
        tracks = GameObject.Find("Tracks");
        SetupTrack();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
