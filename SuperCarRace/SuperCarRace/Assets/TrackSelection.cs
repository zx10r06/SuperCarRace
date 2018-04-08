using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackSelection : MonoBehaviour {

    GameObject tracksGO;
    Material[] Seasons;
    GameObject[] treePrefabs = new GameObject[3];

    public int defaultTrackNumber { get; set; }

    // Use this for initialization
    void Start()
    {

    }

    void Awake() {

        treePrefabs[0] = (GameObject)Resources.Load("Trees/Broadleaf_Mobile_0");
        treePrefabs[1] = (GameObject)Resources.Load("Trees/Broadleaf_Mobile_1");
        treePrefabs[2] = (GameObject)Resources.Load("Trees/Broadleaf_Mobile_2");

        defaultTrackNumber = 0;

        Seasons = new Material[4];
        Seasons[0] = Resources.Load("Materials/Season0", typeof(Material)) as Material;
        Seasons[1] = Resources.Load("Materials/Season1", typeof(Material)) as Material;
        Seasons[2] = Resources.Load("Materials/Season2", typeof(Material)) as Material;
        Seasons[3] = Resources.Load("Materials/Night", typeof(Material)) as Material;

        tracksGO = GameObject.Find("Tracks");


    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject[] allTracks
    {
        get {
            GameObject[] allTracks = new GameObject[tracksGO.transform.childCount];
            for (int i = 0; i< tracksGO.transform.childCount; i++)
            {
                allTracks[i] = tracksGO.transform.GetChild(i).gameObject;
            }
            return allTracks;
        }
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
        GameObject t = tracksGO.transform.Find("track" + GetSelectedTrackNumber().ToString()).gameObject;
        return t;
    }

    public int GetSelectedSeasonNumber() {
        if (GameObject.Find("TrackSeason") != null)
        {
            Dropdown dd = (Dropdown)GameObject.Find("TrackSeason").GetComponent(typeof(Dropdown));
            return dd.value;
        }
        // default season
        //return 0;
        System.Random rnd = new System.Random();
        return rnd.Next(0, 3);
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
            GameObject t = tracksGO.transform.Find("track" + i.ToString()).gameObject;
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

        //string treePrefabName = "Trees/Broadleaf_Mobile_" + GetSelectedSeasonNumber().ToString();
        //GameObject treePrefab = (GameObject)Resources.Load(treePrefabName);
        foreach (Terrain t in Terrain.activeTerrains)
        {
            treeType = t.terrainData.treePrototypes;
            //treeType[0].prefab = treePrefab;
            treeType[0].prefab = treePrefabs[GetSelectedSeasonNumber()];
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
