using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	GameObject cameraCar;
	Vector3 cameraCarPos;
	Quaternion cameraCarRot;

	// Use this for initialization
	void Start () {

		cameraCar = GameObject.Find ("CameraCar");
		cameraCarPos = cameraCar.transform.position;
		cameraCarRot = cameraCar.transform.rotation;
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Test() {
		cameraCar.transform.position = cameraCarPos;
		cameraCar.transform.rotation = cameraCarRot;
    
	
	}


}
