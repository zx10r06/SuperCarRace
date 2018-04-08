using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour {

    ArrayList currentCars = new ArrayList();
    Camera cinematicCamera;
    TrackSelection trackSelection;

    Canvas TitleCanvas;
    Canvas TrackOptions;
    Canvas CarOptions;
    Canvas RCCCanvas;
    Canvas OptionsCanvas;
    Canvas MultiplayerCanvas;

    int raceId = 0;

    string playerCarPrefabName { get;  set; }

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

    private void HideAllCanvas() {
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
        HideAllCanvas();
        TitleCanvas.gameObject.SetActive(true);
    }

    public void SelectTrack() {
        HideAllCanvas();
        TrackOptions.gameObject.SetActive(true);
        trackSelection.SetupTrack();
        ResetRaces();
        ResetCars(true);
    }

    public void SelectCar() {

        if (GameObject.Find("SelectedCar") != null)
        {
            Dropdown ddCar = (Dropdown)GameObject.Find("SelectedCar").GetComponent(typeof(Dropdown));
            playerCarPrefabName = ddCar.options[ddCar.value].text;
        }

        // remove old cars
        foreach (GameObject cc in currentCars)
        {
            Destroy(cc);
        }
        currentCars = new ArrayList();
        GameObject demoCar = CreateCar("DemoCar", playerCarPrefabName, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

        //Set the Camera system to the player car
        RCC_Camera camera = (RCC_Camera)GameObject.Find("RCCCamera").GetComponent(typeof(RCC_Camera));
        camera.SetPlayerCar(demoCar);
        // enable cinematic?

        cinematicCamera.enabled = demoCar;

        HideAllCanvas();
        CarOptions.gameObject.SetActive(true);
    }

    public void StartRace() {
        HideAllCanvas();
        RCCCanvas.gameObject.SetActive(true);
        ResetCars();
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
        //rcV3.vo

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
