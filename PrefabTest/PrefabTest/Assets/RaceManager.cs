using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour {

    ArrayList currentCars = new ArrayList();
    Camera cinematicCamera;
    TrackSelection trackSelection;

    Canvas StartCanvas;
    Canvas TrackOptions;
    Canvas CarOptions;
    Canvas RCCCanvas;

    string playerCarPrefabName { get;  set; }

    // Use this for initialization
    void Start () {

        playerCarPrefabName = "GallardoGT";

        StartCanvas = (Canvas)GameObject.Find("StartCanvas").GetComponent(typeof(Canvas));
        TrackOptions = (Canvas)GameObject.Find("TrackOptions").GetComponent(typeof(Canvas));
        CarOptions = (Canvas)GameObject.Find("CarOptions").GetComponent(typeof(Canvas));
        RCCCanvas = (Canvas)GameObject.Find("RCCCanvas").GetComponent(typeof(Canvas));
        StartCanvas.enabled = true;
        TrackOptions.enabled = false;
        CarOptions.enabled = false;
        RCCCanvas.enabled = false;

        cinematicCamera = (Camera)GameObject.Find("Animation").GetComponent(typeof(Camera));

        trackSelection = (TrackSelection)GetComponent(typeof(TrackSelection));
        trackSelection.SetupTrack();

        ResetCars(true);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TitleScreen() {
        StartCanvas.enabled = true;
        TrackOptions.enabled = false;
        CarOptions.enabled = false;
    }

    public void SelectTrack() {
        StartCanvas.enabled = false;
        TrackOptions.enabled = true;
        CarOptions.enabled = false;
        trackSelection.SetupTrack();
        ResetCars(true);
    }

    public void SelectCar() {

        Dropdown ddCar = (Dropdown)GameObject.Find("SelectedCar").GetComponent(typeof(Dropdown));
        playerCarPrefabName = ddCar.options[ddCar.value].text;

        // remove old cars
        foreach (GameObject cc in currentCars)
        {
            Destroy(cc);
        }
        currentCars = new ArrayList();
        GameObject demoCar = CreateCar("Dan", playerCarPrefabName, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

        StartCanvas.enabled = false;
        TrackOptions.enabled = false;
        CarOptions.enabled = true;
    }

    public void StartRace() {
        RCCCanvas.enabled = true;
        CarOptions.enabled = false;
        ResetCars();
    }

    public void ResetCars(bool DemoMode = false) {

        // remove old cars
        foreach (GameObject cc in currentCars)
        {
            Destroy(cc);
        }
        currentCars = new ArrayList();

        GameObject t = trackSelection.GetSelectedTrack();

        GameObject startPos = t.transform.Find("StartPos").gameObject;
        GameObject cars = GameObject.Find("Cars");

        cars.transform.SetPositionAndRotation(
            new Vector3(startPos.transform.position.x, startPos.transform.position.y, startPos.transform.position.z),
            new Quaternion(startPos.transform.rotation.x, startPos.transform.rotation.y, startPos.transform.rotation.z, 0)
        );

        Vector3 newRotation = startPos.transform.rotation.eulerAngles;
        cars.transform.eulerAngles = newRotation;

        // Target AI waypoints for this track
        GameObject targetWaypoints = t.transform.Find("WaypointContainers").Find("trafficDown").gameObject;

        // Player Car
        GameObject playerCar;
        if (DemoMode)
        {
            playerCar = CreateCar("Dan", playerCarPrefabName, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), targetWaypoints);
        }
        else
        {
            playerCar = CreateCar("Dan", playerCarPrefabName, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        }

        //Set the Camera system to the player car
        RCC_Camera camera = (RCC_Camera)GameObject.Find("RCCCamera").GetComponent(typeof(RCC_Camera));
        camera.SetPlayerCar(playerCar);
        // enable cinematic?
        cinematicCamera.enabled = DemoMode;

        // Create AI Cars
        CreateCar("Paul", "E36", new Vector3(-3, 0, 0), new Quaternion(0, 0, 0, 0), targetWaypoints);
        CreateCar("Chris", "Model_Sofie@Driving by BUMSTRUM", new Vector3(3, 0, 0), new Quaternion(0, 0, 0, 0), targetWaypoints);
        CreateCar("James", "Model_Sedan", new Vector3(0, 0, 6), new Quaternion(0, 0, 0, 0), targetWaypoints);
        CreateCar("Saeedeh", "Model_Misc_Buggy", new Vector3(3, 0, 6), new Quaternion(0, 0, 0, 0), targetWaypoints);

    }

    private GameObject CreateCar(string aiCarName, string PrefabName, Vector3 position, Quaternion rotation, GameObject targetWaypoints = null, string color = null)
    {

        GameObject carsGO = GameObject.Find("Cars");

        GameObject newCar = (GameObject)Instantiate(
            Resources.Load(PrefabName),
            new Vector3(0,0,0),
            new Quaternion(0,0,0,0)
        );

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
        // Audio Volume
        CarAudio ca = (CarAudio)newCar.GetComponent(typeof(CarAudio));
        ca.pitchMultiplier = defaultSoundVolume;//s.value;
        */

        // add to current cars
        currentCars.Add(newCar);

        return newCar;

    }

}
