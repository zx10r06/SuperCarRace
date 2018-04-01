using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour {

    ArrayList currentCars = new ArrayList();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetCars() {

        // remove old cars
        foreach (GameObject cc in currentCars)
        {
            Destroy(cc);
        }
        currentCars = new ArrayList();

        GameObject tracks = GameObject.Find("Tracks"); ;
        Dropdown ddTrack = (Dropdown)GameObject.Find("TrackNumber").GetComponent(typeof(Dropdown));
        GameObject t = tracks.transform.Find("track" + ddTrack.value.ToString()).gameObject;

        GameObject startPos = t.transform.Find("StartPos").gameObject;
        GameObject cars = GameObject.Find("Cars");

        cars.transform.SetPositionAndRotation(
            new Vector3(startPos.transform.position.x, startPos.transform.position.y, startPos.transform.position.z),
            new Quaternion(startPos.transform.rotation.x, startPos.transform.rotation.y, startPos.transform.rotation.z, 0)
        );

        Vector3 newRotation = startPos.transform.rotation.eulerAngles;
        cars.transform.eulerAngles = newRotation;

        // Player Car
        GameObject playerCar = CreateCar("Dan", "GallardoGT", new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

        //Set the Camera system to the player car
        RCC_Camera camera = (RCC_Camera)GameObject.Find("RCCCamera").GetComponent(typeof(RCC_Camera));
        camera.SetPlayerCar(playerCar);

        // Target AI waypoints for this track
        GameObject targetWaypoints = t.transform.Find("WaypointContainers").Find("trafficDown").gameObject;

        // Create AI Cars
        CreateCar("Paul", "E36", new Vector3(-3, 0, 0), new Quaternion(0, 0, 0, 0), targetWaypoints);
        CreateCar("Chris", "Model_Sofie@Driving by BUMSTRUM", new Vector3(3, 0, 0), new Quaternion(0, 0, 0, 0), targetWaypoints);
        CreateCar("James", "Model_Sedan", new Vector3(0, 0, 6), new Quaternion(0, 0, 0, 0), targetWaypoints);
        CreateCar("Saeedeh", "Model_Misc_Buggy", new Vector3(3, 0, 6), new Quaternion(0, 0, 0, 0), targetWaypoints);

    }

    public GameObject CreateCar(string aiCarName, string PrefabName, Vector3 position, Quaternion rotation, GameObject targetWaypoints = null, string color = null)
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
