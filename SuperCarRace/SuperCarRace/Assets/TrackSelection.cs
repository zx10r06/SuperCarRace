using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackSelection : MonoBehaviour {

    GameObject tracks;
    Material[] Seasons;

    public int defaultTrackNumber { get; set; }

    // Use this for initialization
    void Start()
    {



    }

    void Awake() {
        defaultTrackNumber = 0;

        Seasons = new Material[4];
        Seasons[0] = Resources.Load("Materials/Season0", typeof(Material)) as Material;
        Seasons[1] = Resources.Load("Materials/Season1", typeof(Material)) as Material;
        Seasons[2] = Resources.Load("Materials/Season2", typeof(Material)) as Material;
        Seasons[3] = Resources.Load("Materials/Night", typeof(Material)) as Material;

        tracks = GameObject.Find("Tracks");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetSelectedTrackNumber() {
        if (GameObject.Find("TrackNumber") != null)
        {
            Dropdown ddTrack = (Dropdown)GameObject.Find("TrackNumber").GetComponent(typeof(Dropdown));
            defaultTrackNumber = ddTrack.value;
            return ddTrack.value;
        }
        // default track
        return defaultTrackNumber;
    }
    public GameObject GetSelectedTrack() {
        GameObject t = tracks.transform.Find("track" + GetSelectedTrackNumber().ToString()).gameObject;
        return t;
    }

    public int GetSelectedSeasonNumber() {
        if (GameObject.Find("TrackSeason") != null)
        {
            Dropdown dd = (Dropdown)GameObject.Find("TrackSeason").GetComponent(typeof(Dropdown));
            return dd.value;
        }
        // default season
        return 0;
    }
    public GameObject GetSelectedSeason() {
        GameObject s = (GameObject)GetSelectedTrack().transform.Find("season" + GetSelectedSeasonNumber().ToString()).gameObject;
        return s;
    }

    public int GetSelectedTODNumber()
    {
        if (GameObject.Find("TrackTimeOfDay") != null)
        {
            Dropdown dd = (Dropdown)GameObject.Find("TrackTimeOfDay").GetComponent(typeof(Dropdown));
            return dd.value;
        }
        // default TOD
        return 0;
    }
    public GameObject GetSelectedTOD()
    {
        GameObject tod = GetSelectedSeason().transform.Find("tod" + GetSelectedTODNumber().ToString()).gameObject;
        return tod;
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
        GetSelectedTrack().SetActive(true);
    }


    TreePrototype[] treeType;

    public void SetSeason()
    {

        string treePrefabName = "Trees/Broadleaf_Mobile_" + GetSelectedSeasonNumber().ToString();
        GameObject tpf = (GameObject)Resources.Load(treePrefabName);
        foreach (Terrain t in Terrain.activeTerrains)
        {
            treeType = t.terrainData.treePrototypes;
            treeType[0].prefab = tpf;
            t.terrainData.treePrototypes = treeType;
        }

        GetSelectedSeason().SetActive(true);
        // Set Skybox
        RenderSettings.skybox = Seasons[GetSelectedSeasonNumber()];
        if (GetSelectedSeasonNumber() == 1)
        {
            RenderSettings.skybox.SetFloat("_Exposure", 0.65f);
        }
        else
        {
            RenderSettings.skybox.SetFloat("_Exposure", 1.0f);
        }

    }
    public void SetTimeOfDay()
    {
        GetSelectedTOD().SetActive(true);
        // Set Night time exposure
        if (GetSelectedTODNumber() == 1) {
            if (GetSelectedSeasonNumber() == 1)
            {
                RenderSettings.skybox.SetFloat("_Exposure", 0.1f);
            }
            else
            {
                RenderSettings.skybox.SetFloat("_Exposure", 0.2f);
            }
        }

    }

}
