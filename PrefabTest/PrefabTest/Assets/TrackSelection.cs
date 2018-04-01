using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackSelection : MonoBehaviour {

    GameObject tracks;
    Material[] Seasons;


    // Use this for initialization
    void Start()
    {

        Seasons = new Material[4];
        Seasons[0] = Resources.Load("Materials/Season0", typeof(Material)) as Material;
        Seasons[1] = Resources.Load("Materials/Season1", typeof(Material)) as Material;
        Seasons[2] = Resources.Load("Materials/Season2", typeof(Material)) as Material;
        Seasons[3] = Resources.Load("Materials/Night", typeof(Material)) as Material;

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

        // Reset Cars

        RaceManager RaceManager = (RaceManager)GameObject.Find("RaceManager").GetComponent(typeof(RaceManager));
        RaceManager.ResetCars();

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


        //cars.transform.position = new Vector3(startPos.transform.position.x, startPos.transform.position.y, startPos.transform.position.z);
        //cars.transform.rotation = new Quaternion(startPos.transform.rotation.x, startPos.transform.rotation.y, startPos.transform.rotation.z, 0);
        //cars.transform.Rotate(new Vector3(startPos.transform.rotation.x, startPos.transform.rotation.y, startPos.transform.rotation.z));




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

        RenderSettings.skybox = Seasons[dd.value];
        RenderSettings.skybox.SetFloat("_Exposure", 1.0f);

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

        if (dd.value == 1) {
            //RenderSettings.skybox = Seasons[3];
            RenderSettings.skybox.SetFloat("_Exposure", 0.2f);
        }

    }

}
