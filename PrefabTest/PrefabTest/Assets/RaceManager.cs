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

        GameObject playerCar = GameObject.Find("E36");
        playerCar.transform.localPosition = new Vector3(0, 0, 0);
        playerCar.transform.localRotation = new Quaternion(0, 0, 0, 0);

        GameObject aiCar = GameObject.Find("GallardoGT");
        aiCar.transform.localPosition = new Vector3(-3, 0, 0);
        aiCar.transform.localRotation = new Quaternion(0, 0, 0, 0);

    }
}
