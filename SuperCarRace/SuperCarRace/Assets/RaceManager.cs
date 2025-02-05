﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour {

    ArrayList currentCars = new ArrayList();
    public Camera cinematicCamera;
    public TrackSelection trackSelection;

    Canvas TitleCanvas;
    Canvas TrackOptions;
    Canvas CarOptions;
    Canvas RCCCanvas;
    Canvas OptionsCanvas;
    Canvas MultiplayerCanvas;

    int raceId = 0;
    public int selectedCarIndex = 0;

    string playerCarPrefabName { get;  set; }

    MultiplayerManager mm;


    // Use this for initialization
    void Start () {

        playerCarPrefabName = "GallardoGT";

        TitleCanvas = (Canvas)GameObject.Find("TitleCanvas").GetComponent(typeof(Canvas));
        TrackOptions = (Canvas)GameObject.Find("TrackOptions").GetComponent(typeof(Canvas));
        CarOptions = (Canvas)GameObject.Find("CarOptions").GetComponent(typeof(Canvas));
        RCCCanvas = (Canvas)GameObject.Find("RCCCanvas").GetComponent(typeof(Canvas));
        OptionsCanvas = (Canvas)GameObject.Find("OptionsCanvas").GetComponent(typeof(Canvas));
        MultiplayerCanvas = (Canvas)GameObject.Find("MultiplayerCanvas").GetComponent(typeof(Canvas));

        cinematicCamera = (Camera)GameObject.Find("Animation").GetComponent(typeof(Camera));
        trackSelection = (TrackSelection)GetComponent(typeof(TrackSelection));

        mm = GameObject.Find("MultiplayerManager").GetComponent<MultiplayerManager>();

        trackSelection.SetupTrack();
        ResetRaces();
        ResetCars(true);

        // Goto Title screen
        TitleScreen();

    }

    void Awake() {



    }
	
	// Update is called once per frame  
	void Update () {
		
	}

    public void HideAllCanvas() {
        TitleCanvas.gameObject.SetActive(false);
        TrackOptions.gameObject.SetActive(false);
        CarOptions.gameObject.SetActive(false);
        RCCCanvas.gameObject.SetActive(false);
        OptionsCanvas.gameObject.SetActive(false);
        MultiplayerCanvas.gameObject.SetActive(false);
    }

    public void SetMasterVolume()
    {
        Slider dd = (Slider)OptionsCanvas.transform.Find("MasterVolumeSlider").GetComponent(typeof(Slider));
        AudioSource musicSource = GameObject.Find("Music").GetComponent<AudioSource>();
        AudioListener.volume = dd.value;
    }

    public void SetMusicVolume() {
        Slider dd = (Slider)OptionsCanvas.transform.Find("MusicVolumeSlider").GetComponent(typeof(Slider));
        AudioSource musicSource = GameObject.Find("Music").GetComponent<AudioSource>();
        musicSource.volume = dd.value;
    }

    public void SelectMultiplayer() {

        if (PhotonNetwork.connected)
        {
            PhotonNetwork.Disconnect();
        }

        RemoveAllCars();

        HideAllCanvas();
        MultiplayerCanvas.gameObject.SetActive(true);
    }

    public void ShowOptions() {
        OptionsCanvas.gameObject.SetActive(true);
    }

    public void HideOptions() {
        OptionsCanvas.gameObject.SetActive(false);
    }

    public void TitleScreen() {
        amSelectingMultiplayerOptions = false;
        HideAllCanvas();
        TitleCanvas.gameObject.SetActive(true);
    }

    public void SelectTrack() {
        HideAllCanvas();
        TrackOptions.gameObject.SetActive(true);
        trackSelection.SetupTrack();
        ResetRaces();

        ResetCars(true);

        if (amSelectingMultiplayerOptions)
        {
            RemoveAllCars();
        }

    }


    public void SelectCar() {


        if (PhotonNetwork.connected && !PhotonNetwork.inRoom)
        {
            mm.CreateRoomWithTrackOptions();
            //mm.PlacePlayerCar();
            return;
        }


        HideAllCanvas();
        CarOptions.gameObject.SetActive(true);

        // remove old cars
        RemoveAllCars();

        if (GameObject.Find("SelectedCar") != null)
        {
            Dropdown ddCar = (Dropdown)GameObject.Find("SelectedCar").GetComponent(typeof(Dropdown));
            selectedCarIndex = ddCar.value;
            playerCarPrefabName = ddCar.options[selectedCarIndex].text;
        }


        if (PhotonNetwork.inRoom)
        {
            mm.PlacePlayerCar();
            return;
        }


        GameObject demoCar = CreateCar("DemoCar", playerCarPrefabName, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        //demoCar.GetComponent<RCC_CarControllerV3>().handbrakeInput = 1;

        //Set the Camera system to the player car
        RCC_Camera camera = (RCC_Camera)GameObject.Find("RCCCamera").GetComponent(typeof(RCC_Camera));
        camera.SetPlayerCar(demoCar);
        // enable cinematic?

        cinematicCamera.enabled = demoCar;



        RCC_CarControllerV3 rcv3 = demoCar.GetComponent<RCC_CarControllerV3>();
        rcv3.handbrakeInput = 1.0f;
        //rcv3.engineRunning = false;

    }

    public void ShowVehicleControls() {
        HideAllCanvas();
        RCCCanvas.gameObject.SetActive(true);
    }

    public bool amSelectingMultiplayerOptions = false;

    public void StartRace() {

        ShowVehicleControls();

        if (amSelectingMultiplayerOptions)
        {
            RemoveAllCars();
            mm.PlacePlayerCar();
        }
        else
        {
            ResetCars();
        }
    }

    public void ResetRaces() {

        foreach (GameObject t in trackSelection.allTracks)
        {
            GameObject races = t.transform.Find("Races").gameObject;
            for (int i = 0; i < races.transform.transform.childCount; i++)
            {
                GameObject race = races.transform.GetChild(i).gameObject;
                race.SetActive(false);
            }
        }

    }

    public void RemoveAllCars() {
        // remove old cars
        foreach (GameObject cc in currentCars)
        {
            Destroy(cc);
        }
        currentCars = new ArrayList();
    }

    public void ResetCars(bool DemoMode = false) {

        // Reset Races
        ResetRaces();

        RemoveAllCars();

        GameObject t = trackSelection.GetSelectedTrack();


        Dropdown ddRace = (Dropdown)TrackOptions.transform.Find("RaceNumber").GetComponent(typeof(Dropdown));
        raceId = ddRace.value;
        GameObject race = t.transform.Find("Races").GetChild(raceId).gameObject;
        race.SetActive(true);

        GameObject startPos = race.transform.Find("StartPos").gameObject;
        GameObject cars = GameObject.Find("Cars");

        cars.transform.SetPositionAndRotation(
            new Vector3(startPos.transform.position.x, startPos.transform.position.y, startPos.transform.position.z),
            new Quaternion(startPos.transform.rotation.x, startPos.transform.rotation.y, startPos.transform.rotation.z, 0)
        );

        Vector3 newRotation = startPos.transform.rotation.eulerAngles;
        cars.transform.eulerAngles = newRotation;

        // Target AI waypoints for this track
        GameObject targetWaypoints = race.transform.Find("WaypointContainers").gameObject.transform.Find("RaceLine").gameObject;

        // Player Car
        GameObject playerCar;
        if (DemoMode)
        {
            playerCar = CreateCar("DemoCar", playerCarPrefabName, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), targetWaypoints);
        }
        else
        {
            playerCar = CreateCar("PlayerCar", playerCarPrefabName, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        }

        //Set the Camera system to the player car
        RCC_Camera camera = (RCC_Camera)GameObject.Find("RCCCamera").GetComponent(typeof(RCC_Camera));
        camera.SetPlayerCar(playerCar);
        // enable cinematic?
        cinematicCamera.enabled = DemoMode;

        // Create AI Cars
        CreateCar("Paul", playerCarPrefabName == "E36" ? "GallardoGT" : "E36", new Vector3(-3.5f, 0, 0), new Quaternion(0, 0, 0, 0), targetWaypoints);
        CreateCar("Chris", "Model_Sofie@Driving by BUMSTRUM", new Vector3(3.5f, 0, 0), new Quaternion(0, 0, 0, 0), targetWaypoints);
        CreateCar("James", "Model_Sedan", new Vector3(0, 0, 12), new Quaternion(0, 0, 0, 0), targetWaypoints);
        CreateCar("Saeedeh", "Model_Misc_Buggy", new Vector3(4, 0, 12), new Quaternion(0, 0, 0, 0), targetWaypoints);

    }

    private GameObject CreateCar(string aiCarName, string PrefabName, Vector3 position, Quaternion rotation, GameObject targetWaypoints = null, string color = null)
    {

        GameObject carsGO = GameObject.Find("Cars");

        GameObject newCar = (GameObject)Instantiate(
            Resources.Load(PrefabName),
            new Vector3(0,0,0),
            new Quaternion(0,0,0,0)
        );

        newCar.name = aiCarName;

        // set rotation
        newCar.transform.parent = carsGO.transform;
        newCar.transform.localPosition = position;
        newCar.transform.localRotation = rotation;

        // add the AI Controller
        if (targetWaypoints != null)
        {
            newCar.AddComponent<RCC_AICarController>();
            RCC_AICarController rccAI = (RCC_AICarController)newCar.GetComponent(typeof(RCC_AICarController));
            rccAI.waypointsContainer = (RCC_AIWaypointsContainer)targetWaypoints.GetComponent(typeof(RCC_AIWaypointsContainer));
        }

        // set color
        if (color != null)
        {
            /*
            GameObject body = (GameObject)newCar.transform.Find("021014SSPC_LD_NoInterior").gameObject.transform.Find("body").gameObject;
            Renderer r = (Renderer)body.GetComponent(typeof(Renderer));
            Material m = (Material)Resources.Load("mat" + color + "Car");
            r.material = m;
            */
        }

        /*
        RCC_CarControllerV3 rccControllerV3 = (RCC_CarControllerV3)newCar.GetComponent(typeof(RCC_CarControllerV3));
        rccControllerV3.lowBeamHeadLightsOn = true;
        rccControllerV3.highBeamHeadLightsOn = true;
        */

        RCC_CarControllerV3 rcV3 = (RCC_CarControllerV3)newCar.GetComponent<RCC_CarControllerV3>();
        //rcV3.handbrakeInput = 1;

        /*
        // Audio Volume
        CarAudio ca = (CarAudio)newCar.GetComponent(typeof(CarAudio));
        ca.pitchMultiplier = defaultSoundVolume;//s.value;
        */

        // add to current cars
        currentCars.Add(newCar);

        return newCar;

    }

}
