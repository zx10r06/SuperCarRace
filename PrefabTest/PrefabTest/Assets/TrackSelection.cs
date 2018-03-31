using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackSelection : MonoBehaviour {

    GameObject tracks;

    // Use this for initialization
    void Start()
    {
        tracks = GameObject.Find("Tracks");
        SetupTrack();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Handle Track, Season and TOD selection
    public void SetupTrack() {
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

        GameObject startPos = t.transform.Find("StartPos").gameObject;
        GameObject cars = GameObject.Find("Cars");
        //cars.transform.position = new Vector3(startPos.transform.position.x, startPos.transform.position.y, startPos.transform.position.z);
        //cars.transform.rotation = new Quaternion(startPos.transform.rotation.x, startPos.transform.rotation.y, startPos.transform.rotation.z, 0);
        //cars.transform.Rotate(new Vector3(startPos.transform.rotation.x, startPos.transform.rotation.y, startPos.transform.rotation.z));

        cars.transform.SetPositionAndRotation(
            new Vector3(startPos.transform.position.x, startPos.transform.position.y, startPos.transform.position.z),
            new Quaternion(startPos.transform.rotation.x, startPos.transform.rotation.y, startPos.transform.rotation.z, 0)
            );

        Vector3 newRotation = startPos.transform.rotation.eulerAngles;
        cars.transform.eulerAngles = newRotation;

        GameObject playerCar = GameObject.Find("E36");
        playerCar.transform.localPosition = new Vector3(0, 0, 0);
        playerCar.transform.localRotation = new Quaternion(0, 0, 0, 0);

        //RCC_Demo rd = (RCC_Demo)GameObject.Find("RCCCanvas").GetComponent(typeof(RCC_Demo));
        //rd.Spawn();


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

}
