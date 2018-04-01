using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetCars() {

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
        GameObject playerCar = GameObject.Find("E36");
        playerCar.transform.localPosition = new Vector3(0, 0, 0);
        playerCar.transform.localRotation = new Quaternion(0, 0, 0, 0);

        // Target waypoints for this track
        GameObject targetWaypoints = t.transform.Find("WaypointContainers").Find("trafficDown").gameObject;

        // Create AI Cars
        CreateAICar("Paul", "GallardoGT", new Vector3(-3, 0, 0), new Quaternion(0, 0, 0, 0), targetWaypoints);
        CreateAICar("Paul", "Model_Sofie@Driving by BUMSTRUM", new Vector3(3, 0, 0), new Quaternion(0, 0, 0, 0), targetWaypoints);
        CreateAICar("Wade", "Model_Sedan", new Vector3(0, 0, 6), new Quaternion(0, 0, 0, 0), targetWaypoints);
        CreateAICar("Wade", "Model_Misc_Buggy", new Vector3(3, 0, 6), new Quaternion(0, 0, 0, 0), targetWaypoints);

    }

    // AI MANAGER?
    public void CreateAICar(string aiCarName, string PrefabName, Vector3 position, Quaternion rotation, GameObject targetWaypoints = null, string color = null)
    {

        GameObject carsGO = GameObject.Find("Cars");

        Vector3 startPos = new Vector3(carsGO.transform.position.x, carsGO.transform.position.y, carsGO.transform.position.z);

        GameObject newCar = (GameObject)Instantiate(
            Resources.Load(PrefabName),
            new Vector3(0,0,0),
            new Quaternion(0,0,0,0)
        );

        // add the AI Controller
        /*
        WaypointProgressTracker wpt = (WaypointProgressTracker)newCar.GetComponent(typeof(WaypointProgressTracker));
        wpt.circuit = (WaypointCircuit)GameObject.Find("Waypoints").GetComponent(typeof(WaypointCircuit));
        newCar.name = aiCarName;
        */
        if (targetWaypoints != null)
        {
            newCar.AddComponent<RCC_AICarController>();
            RCC_AICarController rccAI = (RCC_AICarController)newCar.GetComponent(typeof(RCC_AICarController));
            rccAI.waypointsContainer = (RCC_AIWaypointsContainer)targetWaypoints.GetComponent(typeof(RCC_AIWaypointsContainer));
        }


        newCar.transform.parent = carsGO.transform;
        newCar.transform.localPosition = position;
        newCar.transform.localRotation = rotation;

        /*
        newCar.transform.SetPositionAndRotation(
            new Vector3(startPos.transform.position.x, startPos.transform.position.y, startPos.transform.position.z),
            new Quaternion(startPos.transform.rotation.x, startPos.transform.rotation.y, startPos.transform.rotation.z, 0)
        );
        */

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

        // add to ai cars array
        //aCars.Add(new aCar(newCar));

        /*
        // Audio Volume
        CarAudio ca = (CarAudio)newCar.GetComponent(typeof(CarAudio));
        ca.pitchMultiplier = defaultSoundVolume;//s.value;
        */


    }

}
